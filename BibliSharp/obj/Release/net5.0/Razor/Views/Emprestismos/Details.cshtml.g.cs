#pragma checksum "C:\Users\Lepa\source\repos\BibliSharp\BibliSharp\Views\Emprestismos\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "067a655e1172d1adcf533230ee5fc45da9fb7f9d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Emprestismos_Details), @"mvc.1.0.view", @"/Views/Emprestismos/Details.cshtml")]
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
#line 1 "C:\Users\Lepa\source\repos\BibliSharp\BibliSharp\Views\_ViewImports.cshtml"
using BibliSharp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lepa\source\repos\BibliSharp\BibliSharp\Views\_ViewImports.cshtml"
using BibliSharp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"067a655e1172d1adcf533230ee5fc45da9fb7f9d", @"/Views/Emprestismos/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06fd161a984c685913b55231ae59265c5a339a7e", @"/Views/_ViewImports.cshtml")]
    public class Views_Emprestismos_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BibliSharp.Models.DetailsEmprestismoViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Lepa\source\repos\BibliSharp\BibliSharp\Views\Emprestismos\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Detalhes</h1>\r\n\r\n<div>\r\n    <h4>Emprestismo</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Users\Lepa\source\repos\BibliSharp\BibliSharp\Views\Emprestismos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Aluno));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\Lepa\source\repos\BibliSharp\BibliSharp\Views\Emprestismos\Details.cshtml"
       Write(Html.DisplayFor(model => model.Aluno));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "C:\Users\Lepa\source\repos\BibliSharp\BibliSharp\Views\Emprestismos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Livro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\Users\Lepa\source\repos\BibliSharp\BibliSharp\Views\Emprestismos\Details.cshtml"
       Write(Html.DisplayFor(model => model.Livro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "C:\Users\Lepa\source\repos\BibliSharp\BibliSharp\Views\Emprestismos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Emprestismo.DataRetirada));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "C:\Users\Lepa\source\repos\BibliSharp\BibliSharp\Views\Emprestismos\Details.cshtml"
       Write(Html.DisplayFor(model => model.Emprestismo.DataRetirada));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "C:\Users\Lepa\source\repos\BibliSharp\BibliSharp\Views\Emprestismos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Emprestismo.CriadoPor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "C:\Users\Lepa\source\repos\BibliSharp\BibliSharp\Views\Emprestismos\Details.cshtml"
       Write(Html.DisplayFor(model => model.Emprestismo.CriadoPor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "C:\Users\Lepa\source\repos\BibliSharp\BibliSharp\Views\Emprestismos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Emprestismo.DataLimite));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "C:\Users\Lepa\source\repos\BibliSharp\BibliSharp\Views\Emprestismos\Details.cshtml"
       Write(Html.DisplayFor(model => model.Emprestismo.DataLimite));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "C:\Users\Lepa\source\repos\BibliSharp\BibliSharp\Views\Emprestismos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Emprestismo.DataEntrega));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "C:\Users\Lepa\source\repos\BibliSharp\BibliSharp\Views\Emprestismos\Details.cshtml"
       Write(Html.DisplayFor(model => model.Emprestismo.DataEntrega));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 51 "C:\Users\Lepa\source\repos\BibliSharp\BibliSharp\Views\Emprestismos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Emprestismo.AlteradoPor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 54 "C:\Users\Lepa\source\repos\BibliSharp\BibliSharp\Views\Emprestismos\Details.cshtml"
       Write(Html.DisplayFor(model => model.Emprestismo.AlteradoPor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 59 "C:\Users\Lepa\source\repos\BibliSharp\BibliSharp\Views\Emprestismos\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { /* id = Model.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "067a655e1172d1adcf533230ee5fc45da9fb7f9d8746", async() => {
                WriteLiteral("Voltar a Lista");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BibliSharp.Models.DetailsEmprestismoViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591