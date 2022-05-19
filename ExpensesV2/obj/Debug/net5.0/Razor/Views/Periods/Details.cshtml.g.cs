#pragma checksum "/media/vmartinez/X-Files1/Documents/Expenses/ExpensesV2/Views/Periods/Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc7c5676d3eb137385acd83ee595c9e8c00da3c9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Periods_Details), @"mvc.1.0.view", @"/Views/Periods/Details.cshtml")]
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
#line 1 "/media/vmartinez/X-Files1/Documents/Expenses/ExpensesV2/Views/_ViewImports.cshtml"
using Expenses;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/media/vmartinez/X-Files1/Documents/Expenses/ExpensesV2/Views/_ViewImports.cshtml"
using Expenses.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc7c5676d3eb137385acd83ee595c9e8c00da3c9", @"/Views/Periods/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74d0af1943369cfa4d737c81da3e3ddc4e8dbb94", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Periods_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Expenses.Models.Period>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Entries", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n");
#nullable restore
#line 3 "/media/vmartinez/X-Files1/Documents/Expenses/ExpensesV2/Views/Periods/Details.cshtml"
  
    ViewData["Title"] = "Balance";
    int balance;

    balance = Model.ListEntries.Sum(x => x.Amount) - Model.ListExpenses.Sum(x => x.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div>\n    <h4 class=\"text-info\">Periodo</h4>\n    <hr />\n    <dl class=\"row\">\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 15 "/media/vmartinez/X-Files1/Documents/Expenses/ExpensesV2/Views/Periods/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 18 "/media/vmartinez/X-Files1/Documents/Expenses/ExpensesV2/Views/Periods/Details.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 21 "/media/vmartinez/X-Files1/Documents/Expenses/ExpensesV2/Views/Periods/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DateStart));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 24 "/media/vmartinez/X-Files1/Documents/Expenses/ExpensesV2/Views/Periods/Details.cshtml"
       Write(Html.DisplayFor(model => model.DateStart));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 27 "/media/vmartinez/X-Files1/Documents/Expenses/ExpensesV2/Views/Periods/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DateStop));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 30 "/media/vmartinez/X-Files1/Documents/Expenses/ExpensesV2/Views/Periods/Details.cshtml"
       Write(Html.DisplayFor(model => model.DateStop));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 33 "/media/vmartinez/X-Files1/Documents/Expenses/ExpensesV2/Views/Periods/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IsActive));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 36 "/media/vmartinez/X-Files1/Documents/Expenses/ExpensesV2/Views/Periods/Details.cshtml"
       Write(Html.DisplayFor(model => model.IsActive));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n    </dl>\n</div>\n\n<h2 class=\"text-info text-right\">\n    Balance ");
#nullable restore
#line 42 "/media/vmartinez/X-Files1/Documents/Expenses/ExpensesV2/Views/Periods/Details.cshtml"
       Write(balance.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</h2>\n\n<hr />\n<h2 class=\"text-success\">Ingresos</h2>\n<p>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc7c5676d3eb137385acd83ee595c9e8c00da3c97261", async() => {
                WriteLiteral("Agregar ingreso");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-periodId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 48 "/media/vmartinez/X-Files1/Documents/Expenses/ExpensesV2/Views/Periods/Details.cshtml"
                                                            WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["periodId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-periodId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["periodId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n</p>\n");
#nullable restore
#line 51 "/media/vmartinez/X-Files1/Documents/Expenses/ExpensesV2/Views/Periods/Details.cshtml"
Write(await Html.PartialAsync("_ListEntries", Model.ListEntries));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n<hr />\n<h2 class=\"text-danger\">Gastos</h2>\n<p>\n    ");
#nullable restore
#line 56 "/media/vmartinez/X-Files1/Documents/Expenses/ExpensesV2/Views/Periods/Details.cshtml"
Write(await Html.PartialAsync("_AgregarIngreso", new Expenses.Models.Expense()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            WriteLiteral("</p>\n");
#nullable restore
#line 59 "/media/vmartinez/X-Files1/Documents/Expenses/ExpensesV2/Views/Periods/Details.cshtml"
Write(await Html.PartialAsync("_ListExpenses", Model.ListExpenses));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n\n<h2 class=\"text-info text-right\">\n    Balance ");
#nullable restore
#line 63 "/media/vmartinez/X-Files1/Documents/Expenses/ExpensesV2/Views/Periods/Details.cshtml"
       Write(balance.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</h2>\n\n<hr />\n<div>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc7c5676d3eb137385acd83ee595c9e8c00da3c910847", async() => {
                WriteLiteral("Regresar a la lista");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</div>\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n");
#nullable restore
#line 71 "/media/vmartinez/X-Files1/Documents/Expenses/ExpensesV2/Views/Periods/Details.cshtml"
      
    await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Expenses.Models.Period> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
