
function initMap() {
    if (!('remove' in Element.prototype)) {
        Element.prototype.remove = function () {
            if (this.parentNode) {
                this.parentNode.removeChild(this);
            }
        };
      }

      mapboxgl.accessToken = 'pk.eyJ1IjoidG9uaWFudG9ub3YxODA0IiwiYSI6ImNrZWwwamtkbjBqY28yc2s3aHZhcnN5eWgifQ.4jMquaCkayTIYSB3L9sAhg';
var map = new mapboxgl.Map({
        container: 'map',
style: 'mapbox://styles/toniantonov1804/ckflf8znv70hd1anrjcyfih7g',

center: [27.91621,43.20656],
pitch: 60, // pitch in degrees
bearing: -60, // bearing in degrees
zoom: 12
});

// Add geolocate control to the map.
map.addControl(
new mapboxgl.GeolocateControl({
        positionOptions: {
        enableHighAccuracy: true
},
trackUserLocation: true
})

);

// Add zoom and rotation controls to the map.
map.addControl(new mapboxgl.NavigationControl());
//first our official patners


var request = new XMLHttpRequest();
request.open("GET","data.json", false);
request.send(null);
var stores = JSON.parse(request.responseText);


      /**
       Apply an unique value for each store
      */
      stores.features.forEach(function(store, i){
        store.properties.id = i;
      });

      /**
       * Wait until the map loads to make changes to the map.
      */
      map.on('load', function (e) {
        /**
         * This is where your '.addLayer()' used to be, instead
         * add only the source without styling a layer
        */
        map.addSource("places", {
            "type": "geojson",
            "data": stores
        });

        /**
         Create a geocoder
        */
        var geocoder = new MapboxGeocoder({
        accessToken: mapboxgl.accessToken,
            mapboxgl: mapboxgl,
            marker: true,
            bbox: [22.121388, 41.376864, 28.0277023 ,44.263464]
        });

        /**
         add all things on the page
         -markers
         -search box
        */
        buildLocationList(stores);
        map.addControl(geocoder, 'top-left');
        addMarkers();

        /**
         * Listen for when a geocoder result is returned. When one is returned:
         * - Calculate distances
         * - Sort stores by distance
         * - Rebuild the listings
         * - Adjust the map camera
         * - Open a popup for the closest store
         * - Highlight the listing for the closest store.
        */
        geocoder.on('result', function(ev) {

          /* Get the coordinate of the search result */
          var searchResult = ev.result.geometry;

          /**
           * Calculate distances:
           * For each store, use turf.disance to calculate the distance
           * in miles between the searchResult and the store. Assign the
           * calculated value to a property called `distance`.
          */
          var options = {units: 'kilometers' };
          stores.features.forEach(function(store){
        Object.defineProperty(store.properties, 'distance', {
            value: turf.distance(searchResult, store.geometry, options),
            writable: true,
            enumerable: true,
            configurable: true
        });
          });

          /**
           * Sort stores by distance from closest to the `searchResult`
           * to furthest.
          */
          stores.features.sort(function(a,b){
            if (a.properties.distance > b.properties.distance) {
              return 1;
            }
            if (a.properties.distance < b.properties.distance) {
              return -1;
            }
            return 0; // a must be equal to b
          });

          /**
           * Rebuild the listings:
           * Remove the existing listings and build the location
           * list again using the newly sorted stores.
          */
          var listings = document.getElementById('listings');
          while (listings.firstChild) {
        listings.removeChild(listings.firstChild);
          }
          buildLocationList(stores);

          /* Open a popup for the closest store. */
          createPopUp(stores.features[0]);

          /** Highlight the listing for the closest store. */
          var activeListing = document.getElementById('listing-' + stores.features[0].properties.id);
          activeListing.classList.add('active');

          /**
           * Adjust the map camera:
           * Get a bbox that contains both the geocoder result and
           * the closest store. Fit the bounds to that bbox.
          */
          var bbox = getBbox(stores, 0, searchResult);
          map.fitBounds(bbox, {
        padding: 100
          });
        });
      });

      /**
       * Using the coordinates (lng, lat) for
       * (1) the search result and
       * (2) the closest store
       * construct a bbox that will contain both points
      */
      function getBbox(sortedStores, storeIdentifier, searchResult) {
        var lats = [sortedStores.features[storeIdentifier].geometry.coordinates[1], searchResult.coordinates[1]]
        var lons = [sortedStores.features[storeIdentifier].geometry.coordinates[0], searchResult.coordinates[0]]
        var sortedLons = lons.sort(function(a,b){
            if (a > b) { return 1; }
            if (a.distance < b.distance) { return -1; }
            return 0;
          });
        var sortedLats = lats.sort(function(a,b){
            if (a > b) { return 1; }
            if (a.distance < b.distance) { return -1; }
            return 0;
          });
        return [
          [sortedLons[0], sortedLats[0]],
          [sortedLons[1], sortedLats[1]]
        ];
      }

      /**
       * Add a marker to the map for every store listing.
      **/
      function addMarkers() {
        /* For each feature in the GeoJSON object above: */
        stores.features.forEach(function (marker) {
            /* Create a div element for the marker. */
            var el = document.createElement('div');
            /* Assign a unique `id` to the marker. */
            el.id = "marker-" + marker.properties.id;
            /* Assign the `marker` class to each marker for styling. */
            el.className = 'marker';

            /**
             * Create a marker using the div element
             * defined above and add it to the map.
            **/
            new mapboxgl.Marker(el, { offset: [0, -23] })
                .setLngLat(marker.geometry.coordinates)
                .addTo(map);

            /**
             * Listen to the element and when it is clicked, do three things:
             * 1. Fly to the point
             * 2. Close all other popups and display popup for clicked store
             * 3. Highlight listing in sidebar (and remove highlight for all other listings)
            **/
            el.addEventListener('click', function (e) {
                flyToStore(marker);
                createPopUp(marker);
                var activeItem = document.getElementsByClassName('active');
                e.stopPropagation();
                if (activeItem[0]) {
                    activeItem[0].classList.remove('active');
                }
                var listing = document.getElementById('listing-' + marker.properties.id);
                listing.classList.add('active');
            });
        });
      }

      /**
       * Add a listing for each store to the sidebar.
      **/
      function buildLocationList(data) {
        data.features.forEach(function (store, i) {
            /**
             * Create a shortcut for `store.properties`,
             * which will be used several times below.
            **/









            var prop = store.properties;

            /* Add a new listing section to the sidebar. */
            var listings = document.getElementById('listings');
            var listing = listings.appendChild(document.createElement('div'));
            /* Assign a unique `id` to the listing. */
            listing.id = "listing-" + prop.id;
            /* Assign the `item` class to each listing for styling. */
            listing.className = 'item';

            /* Add the link to the individual listing created above. */
            var link = listing.appendChild(document.createElement('a'));
            link.href = '#';
            link.className = 'title';
            link.id = "link-" + prop.id;
            link.innerHTML = prop.address;

            /* Add details to the individual listing. */
            var details = listing.appendChild(document.createElement('div'));
            details.innerHTML = prop.city;
            if (prop.phone) {
                details.innerHTML += ' · ' + prop.phoneFormatted;
            }
            if (prop.distance) {
                var roundedDistance = Math.round(prop.distance * 100) / 100;
                details.innerHTML += '<p><strong>' + roundedDistance + ' kilometers away</strong></p>';
            }

            /**
             * Listen to the element and when it is clicked, do four things:
             * 1. Update the `currentFeature` to the store associated with the clicked link
             * 2. Fly to the point
             * 3. Close all other popups and display popup for clicked store
             * 4. Highlight listing in sidebar (and remove highlight for all other listings)
            **/
            link.addEventListener('click', function (e) {
                for (var i = 0; i < data.features.length; i++) {
                    if (this.id === "link-" + data.features[i].properties.id) {
                        var clickedListing = data.features[i];
                        flyToStore(clickedListing);
                        createPopUp(clickedListing);
                    }
                }
                var activeItem = document.getElementsByClassName('active');
                if (activeItem[0]) {
                    activeItem[0].classList.remove('active');
                }
                this.parentNode.classList.add('active');
            });
        });
      }

      /**
       * using mapbox js to move camera smoothy to a
       * a given center point.
      **/
      function flyToStore(currentFeature) {
        map.flyTo({
            center: currentFeature.geometry.coordinates,
            zoom: 15
        });
      }

      /**
       create a pop up
      **/
      function createPopUp(currentFeature) {
        var popUps = document.getElementsByClassName('mapboxgl-popup');
        if (popUps[0]) popUps[0].remove();

        var popup = new mapboxgl.Popup({closeOnClick: false})
          .setLngLat(currentFeature.geometry.coordinates)
          .setHTML('<h3>'+currentFeature.properties.address+'</h3>' +
            '<h4>' +'Качество на водата: '+ currentFeature.properties.phone + '</h4>'+
            '<h4>' +'Налягане на водата: '+ currentFeature.properties.crossStreet + '</h4>')
          .addTo(map);
}
}