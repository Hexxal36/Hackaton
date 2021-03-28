#include <Dictionary.h>
#include <NodeArray.h>

#include <WiFi.h>
#include <HTTPClient.h>
#include <BLEDevice.h>
#include <BLEServer.h>
#include <BLE2902.h>

#define SERVICE_UUID        "4fafc201-1fb5-459e-8fcc-c5c9c331914b"
#define CHARACTERISTIC_UUID "beb5483e-36e1-4688-b7f5-ea07361b26a8"
#define _DICT_CRC 32

BLEServer* pServer = NULL;
BLECharacteristic* pCharacteristic = NULL;
bool deviceConnected = false;
uint8_t value = 0;

const char* ssid = "********";
const char* password = "********";

const char* serverName = "https://webhook.site/65bd6ecf-1adf-484b-af86-b2c560c3d448";

class MyServerCallbacks: public BLEServerCallbacks {
    void onConnect(BLEServer* pServer) {
      deviceConnected = true;
      BLEDevice::startAdvertising();
    };
};

static String CreateDeviceJson(){
  Dictionary *dict1 = new Dictionary();
  double rng3 = random(200)*1.0, rng4 = random(1, 15)*1.0;
  dict1->insert("Latitude", (String)rng3);
  dict1->insert("Longtitude", (String)rng3);
  dict1->insert("Description", "lorem ipsum");
  dict1->insert("Location", "random location");
  dict1->insert("Name", "Device 1");
  return dict1->json();
  }
static int POSTrequest(String post_json){
  if(WiFi.status()== WL_CONNECTED){
        Serial.println(post_json);
        HTTPClient http;
        http.begin(serverName);
        http.addHeader("Content-Type", "application/json");
        int httpResponseCode = http.POST(post_json);
        http.end();
        return httpResponseCode;
      }
  }
class MyCallbacks: public BLECharacteristicCallbacks {
    void onWrite(BLECharacteristic *pCharacteristic) {
      std::string value = pCharacteristic->getValue();
      String val = "";
      for(int i = 0; i < value.length(); i++)
        val+= value[i];
      Serial.println("Received Value!");
      Serial.println(POSTrequest(val));
      Serial.println(POSTrequest(CreateDeviceJson()));
      delay(10000);
   }
   void onRead(BLECharacteristic *pCharacteristic) {
      std::string value = pCharacteristic->getValue();
      Serial.println("fdf Value!");
   }
};

void setup() {
  Serial.begin(115200);
  WiFi.begin(ssid, password);
  while(WiFi.status()!= WL_CONNECTED){}
  Serial.println("Connected to internet!");
  BLEDevice::init("ESP32");
  pServer = BLEDevice::createServer();
  pServer->setCallbacks(new MyServerCallbacks());
  BLEService *pService = pServer->createService(SERVICE_UUID);
  
  pCharacteristic = pService->createCharacteristic(
                      CHARACTERISTIC_UUID,
                      BLECharacteristic::PROPERTY_READ |
                      BLECharacteristic::PROPERTY_WRITE|
                      BLECharacteristic::PROPERTY_NOTIFY
                      );
                      
  pCharacteristic->addDescriptor(new BLE2902());
  pCharacteristic->setCallbacks(new MyCallbacks());
  pService->start();
  
  BLEAdvertising *pAdvertising = BLEDevice::getAdvertising();
  pAdvertising->addServiceUUID(SERVICE_UUID);
  pAdvertising->setScanResponse(false);
  pAdvertising->setMinPreferred(0x0);
  BLEDevice::startAdvertising();
}
void loop(){}
