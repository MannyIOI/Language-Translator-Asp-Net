#pragma checksum "C:\Users\hp\source\repos\WebApplication1\Language\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aba83760130a25585d57738d086e3351e6cc7534"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\hp\source\repos\WebApplication1\Language\Views\_ViewImports.cshtml"
using Language;

#line default
#line hidden
#line 2 "C:\Users\hp\source\repos\WebApplication1\Language\Views\_ViewImports.cshtml"
using Language.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aba83760130a25585d57738d086e3351e6cc7534", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9766af7a177797e933f1bea8323fb1a1ca5bb2b3", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Translation>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Home/Translate"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/vendor/jquery/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\hp\source\repos\WebApplication1\Language\Views\Home\Index.cshtml"
  
	ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(62, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(415, 68, true);
            WriteLiteral("<br /><br /><br /><br /><br />\r\n<div class=\"row col-lg-offset-3\">\r\n\t");
            EndContext();
            BeginContext(483, 1256, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d82a969bb164ca5af6cbe6c14c303e4", async() => {
                BeginContext(528, 132, true);
                WriteLiteral("\r\n\t\t<div class=\"col-md-3\">\r\n\t\t\t<div class=\"row\">\r\n\t\t\t\t<select name=\"fromLangId\" id=\"fromLangId\" class=\"form-item col-lg-offset-1\">\r\n");
                EndContext();
#line 20 "C:\Users\hp\source\repos\WebApplication1\Language\Views\Home\Index.cshtml"
                       List<Language> languages = (List<Language>)ViewData["languages"];

#line default
#line hidden
                BeginContext(736, 5, true);
                WriteLiteral("\t\t\t\t\t");
                EndContext();
#line 21 "C:\Users\hp\source\repos\WebApplication1\Language\Views\Home\Index.cshtml"
                     foreach (Language language in languages) {

#line default
#line hidden
                BeginContext(786, 6, true);
                WriteLiteral("\t\t\t\t\t\t");
                EndContext();
                BeginContext(792, 68, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e44235b6b1b940bdb71b2d3531d3f710", async() => {
                    BeginContext(830, 21, false);
#line 22 "C:\Users\hp\source\repos\WebApplication1\Language\Views\Home\Index.cshtml"
                                                        Write(language.LanguageName);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 22 "C:\Users\hp\source\repos\WebApplication1\Language\Views\Home\Index.cshtml"
                           WriteLiteral(language.LanguageId);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(860, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 23 "C:\Users\hp\source\repos\WebApplication1\Language\Views\Home\Index.cshtml"
					}

#line default
#line hidden
                BeginContext(870, 43, true);
                WriteLiteral("\t\t\t\t</select>\r\n\t\t\t\t<div class=\"col-md-6\">\r\n");
                EndContext();
                BeginContext(1010, 426, true);
                WriteLiteral(@"
				</div>
			</div>
			<textarea rows=""5"" style=""font-size: x-large;"" class=""form-control"" name =""fromWord"" id=""fromWord""></textarea>
		</div>
		<div class=""col-sm-1"" style=""width: 10px; margin: 0; padding: 0;"">
			<br/><br />
			<i class=""fa fa-exchange"" aria-hidden=""true""></i>
		</div>
		<div class=""col-md-3"">
			<div class=""row"">
				<select name=""toLangId"" id=""toLangId"" class=""form-item col-lg-offset-6"">
");
                EndContext();
#line 39 "C:\Users\hp\source\repos\WebApplication1\Language\Views\Home\Index.cshtml"
                     foreach (Language language in languages) {

#line default
#line hidden
                BeginContext(1486, 6, true);
                WriteLiteral("\t\t\t\t\t\t");
                EndContext();
                BeginContext(1492, 68, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fcefd2d78dfe438ab3dc49cb88d3a8ff", async() => {
                    BeginContext(1530, 21, false);
#line 40 "C:\Users\hp\source\repos\WebApplication1\Language\Views\Home\Index.cshtml"
                                                        Write(language.LanguageName);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 40 "C:\Users\hp\source\repos\WebApplication1\Language\Views\Home\Index.cshtml"
                           WriteLiteral(language.LanguageId);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1560, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 41 "C:\Users\hp\source\repos\WebApplication1\Language\Views\Home\Index.cshtml"
					}

#line default
#line hidden
                BeginContext(1570, 115, true);
                WriteLiteral("\t\t\t\t</select>\r\n\t\t\t\t\r\n\t\t\t</div>\r\n\t\t\t<textarea rows=\"5\" style=\"font-size: x-large;\" class=\"form-control\" id=\"toWord\">");
                EndContext();
                BeginContext(1686, 22, false);
#line 45 "C:\Users\hp\source\repos\WebApplication1\Language\Views\Home\Index.cshtml"
                                                                                       Write(ViewData["translated"]);

#line default
#line hidden
                EndContext();
                BeginContext(1708, 24, true);
                WriteLiteral("</textarea>\r\n\t\t</div>\r\n\t");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1739, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
            BeginContext(1749, 56, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "07d7def04f6c4b36915e7610ea4b89e3", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1805, 590, true);
            WriteLiteral(@"
<script>
	$(document).ready(
		function () {
			$(""#fromWord"").on(""input"", function () {

				//alert($(""#toWord"").val());
				//$(""#toWord"").val(""alkdjfkl"");
				var options = {};
				options.url = ""/Home/GetTranslationJSON"";
				options.type = ""GET"";
				options.data = { ""fromWord"": $(""#fromWord"").val(), ""fromLangId"": $(""#fromLangId"").val(), ""toLangId"": $(""#toLangId"").val() };

				options.dataType = ""json"";
				options.success = function (data) {
					//alert(""here "" + data);
					$(""#toWord"").val(data[0]);
				};
				$.ajax(options);
			})
		}
	);
</script>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Translation> Html { get; private set; }
    }
}
#pragma warning restore 1591