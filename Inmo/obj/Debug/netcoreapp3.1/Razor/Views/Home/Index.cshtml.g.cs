#pragma checksum "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6360e1d71c8ec8051b285262bda749b13f3026d0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\_ViewImports.cshtml"
using Inmo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\_ViewImports.cshtml"
using Inmo.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6360e1d71c8ec8051b285262bda749b13f3026d0", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c2ee7eff59543f3e8dcfeb6c5619c630d566651", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-lg-3 col-6\">\r\n        <!-- small box -->\r\n        <div class=\"small-box bg-info\">\r\n            <div class=\"inner\">\r\n                <h3>");
#nullable restore
#line 11 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Home\Index.cshtml"
               Write(ViewBag.Disponibles);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>

                <p>
                    Disponibles
                </p>
            </div>
            <div class=""icon"">
                <i class=""ion ion-home""></i>
            </div>
            <a href=""#"" class=""small-box-footer statDisponible"">Mas info <i class=""fas fa-arrow-circle-right""></i></a>
        </div>
    </div>
    <!-- ./col -->
    <div class=""col-lg-3 col-6"">
        <!-- small box -->
        <div class=""small-box bg-success"">
            <div class=""inner"">
                <h3>");
#nullable restore
#line 28 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Home\Index.cshtml"
               Write(ViewBag.Total);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<sup style=""font-size: 20px""></sup></h3>

                <p>Inmuebles alquilados</p>
            </div>
            <div class=""icon"">
                <i class=""ion ion-stats-bars""></i>
            </div>
            <a href=""#"" class=""small-box-footer statAlquilados"">Mas info <i class=""fas fa-arrow-circle-right""></i></a>
        </div>
    </div>
    <!-- ./col -->
    <div class=""col-lg-3 col-6"">
        <!-- small box -->
        <div class=""small-box bg-warning"">
            <div class=""inner"">
                <h3>");
#nullable restore
#line 43 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Home\Index.cshtml"
               Write(ViewBag.Caja);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>

                <p>Caja diaria</p>
            </div>
            <div class=""icon"">
                <i class=""ion ion-cash""></i>
            </div>
            <a href=""#"" class=""small-box-footer"">Mas info <i class=""fas fa-arrow-circle-right""></i></a>
        </div>
    </div>
    <!-- ./col -->
    <div class=""col-lg-3 col-6"">
        <!-- small box -->
        <div class=""small-box bg-danger"">
            <div class=""inner"">
                <h3>");
#nullable restore
#line 58 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Home\Index.cshtml"
               Write(ViewBag.Vencidos);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>

                <p>Pagos vencidos</p>
            </div>
            <div class=""icon"">
                <i class=""ion ion-alert-circled""></i>
            </div>
            <a href=""#"" class=""small-box-footer"">Mas info <i class=""fas fa-arrow-circle-right""></i></a>
        </div>
    </div>
    <!-- ./col -->
</div>




<div id=""listado"" class=""listado"">

</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n    <script>\r\n        $(document).ready(function () {\r\n            $(\".statDisponible\").click(function (e) {\r\n                e.preventDefault()\r\n                $.ajax({\r\n                    url: \"");
#nullable restore
#line 85 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Home\Index.cshtml"
                     Write(Url.Action("Disponibles", "Home"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
                    type: ""GET"",
                    
                    error: function (response) {
                        console.log(""Fallo: "");
                    },
                    success: function (response) {
                        console.log(""Exito!"");
                        
                        $(""#listado"").html(response).fadeIn(2000);
                    }
                });
            })




            $("".test"").click(function (e) {
                e.preventDefault()
                $.ajax({
                    url: """);
#nullable restore
#line 105 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Home\Index.cshtml"
                     Write(Url.Action("Alquilados", "Home"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
                    type: ""GET"",
                    
                    error: function (response) {
                        console.log(""Fallo: "");
                    },
                    success: function (response) {
                        console.log(""Exito!"");
                        
                        $(""#listado"").html(response).fadeIn(2000);
                    }
                });
            })




        });
    </script>

");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
