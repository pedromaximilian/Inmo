#pragma checksum "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "da88c38ec50e4560a9017adc2b162dbc3d1c5e51"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Propietario_Details), @"mvc.1.0.view", @"/Views/Propietario/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da88c38ec50e4560a9017adc2b162dbc3d1c5e51", @"/Views/Propietario/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c2ee7eff59543f3e8dcfeb6c5619c630d566651", @"/Views/_ViewImports.cshtml")]
    public class Views_Propietario_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Inmo.Models.Propietario>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\Details.cshtml"
  
    ViewData["Title"] = "Propietario";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<div class=""row"">
    <div class=""col-md-12 col-lg-6  mx-auto"">


        <div class=""card card-primary"">
            <div class=""card-header"">
                <h3 class=""card-title"">Propietario</h3>
            </div>

            <!-- aca inicia el form !-->
            <div class=""card-body"">

                <div>

                    <dl class=""row"">

                        <dt class=""col-sm-2"">
                            ");
#nullable restore
#line 26 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\Details.cshtml"
                       Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 29 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\Details.cshtml"
                       Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 32 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\Details.cshtml"
                       Write(Html.DisplayNameFor(model => model.Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 35 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\Details.cshtml"
                       Write(Html.DisplayFor(model => model.Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 38 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\Details.cshtml"
                       Write(Html.DisplayNameFor(model => model.Dni));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 41 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\Details.cshtml"
                       Write(Html.DisplayFor(model => model.Dni));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 44 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\Details.cshtml"
                       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 47 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\Details.cshtml"
                       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 50 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\Details.cshtml"
                       Write(Html.DisplayNameFor(model => model.Telefono));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 53 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\Details.cshtml"
                       Write(Html.DisplayFor(model => model.Telefono));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n\r\n                    </dl>\r\n                </div>\r\n\r\n            </div>\r\n            <!-- /.card-body -->\r\n\r\n\r\n            <div class=\"card-footer\">\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 65 "C:\Users\pedro\OneDrive\Documentos\GitHub\Inmo\Inmo\Views\Propietario\Details.cshtml"
               Write(Html.ActionLink("Editar", "Edit", new { id = Model.Id }, new { @class = "btn btn-warning" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "da88c38ec50e4560a9017adc2b162dbc3d1c5e518833", async() => {
                WriteLiteral("regresar a la lista");
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
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <!-- aca inicia el form !-->\r\n        </div>\r\n\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Inmo.Models.Propietario> Html { get; private set; }
    }
}
#pragma warning restore 1591
