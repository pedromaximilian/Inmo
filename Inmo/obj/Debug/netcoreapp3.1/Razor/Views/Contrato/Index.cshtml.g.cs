#pragma checksum "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Contrato\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9fac5e9f404efdd226674347d68acfca6be9eb3b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contrato_Index), @"mvc.1.0.view", @"/Views/Contrato/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fac5e9f404efdd226674347d68acfca6be9eb3b", @"/Views/Contrato/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c2ee7eff59543f3e8dcfeb6c5619c630d566651", @"/Views/_ViewImports.cshtml")]
    public class Views_Contrato_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Inmo.Models.Contrato>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Contrato\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Contratos</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9fac5e9f404efdd226674347d68acfca6be9eb3b4015", async() => {
                WriteLiteral("Agregar Contrato");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\" id=\"tabla\" style=\"width:100%\">\r\n    <thead>\r\n        <tr>\r\n\r\n\r\n            <th>\r\n                ");
#nullable restore
#line 18 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Contrato\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Inmueble.Direccion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 21 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Contrato\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Inquilino.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 24 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Contrato\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FechaInicio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 27 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Contrato\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FechaFin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n\r\n            <th>\r\n                ");
#nullable restore
#line 32 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Contrato\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Estado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 38 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Contrato\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 44 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Contrato\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Inmueble.Direccion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 47 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Contrato\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Inquilino.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 50 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Contrato\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.FechaInicio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 53 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Contrato\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.FechaFin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 57 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Contrato\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Estado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <a class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 1580, "\"", 1643, 1);
#nullable restore
#line 60 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Contrato\Index.cshtml"
WriteAttributeValue("", 1587, Url.Action("Details", "Contrato", new { id = item.Id }), 1587, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <i class=\"fi-xnluxl-info\"></i>\r\n                    </a>\r\n                    <a class=\"btn btn-info\"");
            BeginWriteAttribute("href", " href=\"", 1772, "\"", 1835, 1);
#nullable restore
#line 63 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Contrato\Index.cshtml"
WriteAttributeValue("", 1779, Url.Action("Renovar", "Contrato", new { id = item.Id }), 1779, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <i class=\"fi-xnluxl-reload\"></i>\r\n                    </a>\r\n                    <a class=\"btn btn-danger\"");
            BeginWriteAttribute("href", " href=\"", 1968, "\"", 2033, 1);
#nullable restore
#line 66 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Contrato\Index.cshtml"
WriteAttributeValue("", 1975, Url.Action("Rescindir", "Contrato", new { id = item.Id }), 1975, 58, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <i class=\"fi-xnpuxl-home\"></i>\r\n                    </a>\r\n\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 72 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Contrato\Index.cshtml"
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