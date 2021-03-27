#pragma checksum "C:\Users\1\source\repos\Hackaton\Hackaton\Server\Areas\Admin\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f906463182ac5d6e4820535eba77c91d5f61da7a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Dashboard_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Dashboard/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\1\source\repos\Hackaton\Hackaton\Server\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\1\source\repos\Hackaton\Hackaton\Server\Areas\Admin\Views\_ViewImports.cshtml"
using Hackaton.Server.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\1\source\repos\Hackaton\Hackaton\Server\Areas\Admin\Views\_ViewImports.cshtml"
using Hackaton.Server.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\1\source\repos\Hackaton\Hackaton\Server\Areas\Admin\Views\_ViewImports.cshtml"
using Hackaton.Server.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\1\source\repos\Hackaton\Hackaton\Server\Areas\Admin\Views\_ViewImports.cshtml"
using Hackaton.Server.Areas.Admin.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f906463182ac5d6e4820535eba77c91d5f61da7a", @"/Areas/Admin/Views/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9482a2b1ff3afd5142d84691b249d13abcbebd46", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DashboardVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\1\source\repos\Hackaton\Hackaton\Server\Areas\Admin\Views\Dashboard\Index.cshtml"
  
    ViewData["Title"] = "Dashboard";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-12 grid-margin"">
        <div class=""card"">
            <div class=""card-body"">
                <h4 class=""card-title"">Последни логове</h4>
                <div class=""table-responsive"">
                    <table class=""table"">
                        <thead>
                            <tr>
                                <th> № на Устройство </th>
                                <th> Разтворен кислород </th>
                                <th> ОРП </th>
                                <th> Ph </th>
                                <th> Налягане </th>
                                <th> Дата на създаване </th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 25 "C:\Users\1\source\repos\Hackaton\Hackaton\Server\Areas\Admin\Views\Dashboard\Index.cshtml"
                             foreach (var info in Model.Information)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 28 "C:\Users\1\source\repos\Hackaton\Hackaton\Server\Areas\Admin\Views\Dashboard\Index.cshtml"
                                   Write(info.DeviceId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 29 "C:\Users\1\source\repos\Hackaton\Hackaton\Server\Areas\Admin\Views\Dashboard\Index.cshtml"
                                   Write(info.DissolvedOxygen);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 30 "C:\Users\1\source\repos\Hackaton\Hackaton\Server\Areas\Admin\Views\Dashboard\Index.cshtml"
                                   Write(info.ORP);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 31 "C:\Users\1\source\repos\Hackaton\Hackaton\Server\Areas\Admin\Views\Dashboard\Index.cshtml"
                                   Write(info.PH);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 32 "C:\Users\1\source\repos\Hackaton\Hackaton\Server\Areas\Admin\Views\Dashboard\Index.cshtml"
                                   Write(info.WaterPressure);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 33 "C:\Users\1\source\repos\Hackaton\Hackaton\Server\Areas\Admin\Views\Dashboard\Index.cshtml"
                                   Write(info.CreatedAt.ToString("dd/mm/yy HH:MM"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 35 "C:\Users\1\source\repos\Hackaton\Hackaton\Server\Areas\Admin\Views\Dashboard\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DashboardVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
