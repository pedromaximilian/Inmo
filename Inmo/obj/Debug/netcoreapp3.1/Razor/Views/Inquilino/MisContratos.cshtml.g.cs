#pragma checksum "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Inquilino\MisContratos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "77d1d4b2447e6828cd09881c99154b5425980561"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Inquilino_MisContratos), @"mvc.1.0.view", @"/Views/Inquilino/MisContratos.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"77d1d4b2447e6828cd09881c99154b5425980561", @"/Views/Inquilino/MisContratos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c2ee7eff59543f3e8dcfeb6c5619c630d566651", @"/Views/_ViewImports.cshtml")]
    public class Views_Inquilino_MisContratos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Inmo.Models.Contrato>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Inquilino\MisContratos.cshtml"
  
    ViewData["Title"] = "MisContratos";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Mis Contratos</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n\r\n            <th>\r\n                ");
#nullable restore
#line 14 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Inquilino\MisContratos.cshtml"
           Write(Html.DisplayNameFor(model => model.InmuebleId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n            <th>\r\n                ");
#nullable restore
#line 18 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Inquilino\MisContratos.cshtml"
           Write(Html.DisplayNameFor(model => model.FechaInicio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 21 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Inquilino\MisContratos.cshtml"
           Write(Html.DisplayNameFor(model => model.FechaFin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 24 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Inquilino\MisContratos.cshtml"
           Write(Html.DisplayNameFor(model => model.Monto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 27 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Inquilino\MisContratos.cshtml"
           Write(Html.DisplayNameFor(model => model.NombreGarante));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 30 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Inquilino\MisContratos.cshtml"
           Write(Html.DisplayNameFor(model => model.DniGarante));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 33 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Inquilino\MisContratos.cshtml"
           Write(Html.DisplayNameFor(model => model.TelefonoGarante));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 36 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Inquilino\MisContratos.cshtml"
           Write(Html.DisplayNameFor(model => model.MailGarante));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 39 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Inquilino\MisContratos.cshtml"
           Write(Html.DisplayNameFor(model => model.Estado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 45 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Inquilino\MisContratos.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 50 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Inquilino\MisContratos.cshtml"
               Write(Html.DisplayFor(modelItem => item.InmuebleId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 54 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Inquilino\MisContratos.cshtml"
               Write(Html.DisplayFor(modelItem => item.FechaInicio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 57 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Inquilino\MisContratos.cshtml"
               Write(Html.DisplayFor(modelItem => item.FechaFin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 60 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Inquilino\MisContratos.cshtml"
               Write(Html.DisplayFor(modelItem => item.Monto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 63 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Inquilino\MisContratos.cshtml"
               Write(Html.DisplayFor(modelItem => item.NombreGarante));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 66 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Inquilino\MisContratos.cshtml"
               Write(Html.DisplayFor(modelItem => item.DniGarante));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 69 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Inquilino\MisContratos.cshtml"
               Write(Html.DisplayFor(modelItem => item.TelefonoGarante));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 72 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Inquilino\MisContratos.cshtml"
               Write(Html.DisplayFor(modelItem => item.MailGarante));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 75 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Inquilino\MisContratos.cshtml"
               Write(Html.DisplayFor(modelItem => item.Estado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <a class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 2311, "\"", 2374, 1);
#nullable restore
#line 78 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Inquilino\MisContratos.cshtml"
WriteAttributeValue("", 2318, Url.Action("Details", "Contrato", new { id = item.Id }), 2318, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <i class=\"fi-xnluxl-info\"></i>\r\n\r\n                    </a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 84 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Inquilino\MisContratos.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n    <script>\r\n\r\n        $(\"body > div\").removeClass(\"container\");\r\n        $(\"body > div\").addClass(\"container-fluid\");\r\n    </script>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Inmo.Models.Contrato>> Html { get; private set; }
    }
}
#pragma warning restore 1591