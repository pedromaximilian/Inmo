#pragma checksum "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\MisInmuebles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "551b16c3f72a96e9bb2e86e59f82fa5c09f123af"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Propietario_MisInmuebles), @"mvc.1.0.view", @"/Views/Propietario/MisInmuebles.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"551b16c3f72a96e9bb2e86e59f82fa5c09f123af", @"/Views/Propietario/MisInmuebles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c2ee7eff59543f3e8dcfeb6c5619c630d566651", @"/Views/_ViewImports.cshtml")]
    public class Views_Propietario_MisInmuebles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Inmo.Models.Inmueble>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\MisInmuebles.cshtml"
  
    ViewData["Title"] = "Inmuebles";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Inmuebles</h1>\r\n\r\n\r\n<table class=\"table\" id=\"tabla\" style=\"width:100%\">\r\n    <thead>\r\n        <tr>\r\n            \r\n            \r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\MisInmuebles.cshtml"
           Write(Html.DisplayNameFor(model => model.Direccion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\MisInmuebles.cshtml"
           Write(Html.DisplayNameFor(model => model.Ambientes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\MisInmuebles.cshtml"
           Write(Html.DisplayNameFor(model => model.Uso));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\MisInmuebles.cshtml"
           Write(Html.DisplayNameFor(model => model.Tipo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\MisInmuebles.cshtml"
           Write(Html.DisplayNameFor(model => model.Precio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\MisInmuebles.cshtml"
           Write(Html.DisplayNameFor(model => model.Estado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 37 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\MisInmuebles.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            \r\n            \r\n            <td>\r\n                ");
#nullable restore
#line 42 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\MisInmuebles.cshtml"
           Write(Html.DisplayFor(modelItem => item.Direccion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 45 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\MisInmuebles.cshtml"
           Write(Html.DisplayFor(modelItem => item.Ambientes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 48 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\MisInmuebles.cshtml"
           Write(Html.DisplayFor(modelItem => item.Uso));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 51 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\MisInmuebles.cshtml"
           Write(Html.DisplayFor(modelItem => item.Tipo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 54 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\MisInmuebles.cshtml"
           Write(Html.DisplayFor(modelItem => item.Precio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 57 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\MisInmuebles.cshtml"
           Write(Html.DisplayFor(modelItem => item.Estado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                \r\n                <a class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 1612, "\"", 1675, 1);
#nullable restore
#line 61 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\MisInmuebles.cshtml"
WriteAttributeValue("", 1619, Url.Action("Details", "Inmueble", new { id = item.Id }), 1619, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <i class=\"fi-xnluxl-info\"></i>\r\n\r\n                </a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 67 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\MisInmuebles.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Inmo.Models.Inmueble>> Html { get; private set; }
    }
}
#pragma warning restore 1591
