#pragma checksum "C:\Users\millz\Desktop\container\Pack\project 04\Project\Views\PharmacistDashboard\PatientDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b0fd144eb1f55879df0ca74c1ca2924ae31e411e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(digitalhealthza.Pages.PharmacistDashboard.Views_PharmacistDashboard_PatientDetails), @"mvc.1.0.view", @"/Views/PharmacistDashboard/PatientDetails.cshtml")]
namespace digitalhealthza.Pages.PharmacistDashboard
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
#line 1 "C:\Users\millz\Desktop\container\Pack\project 04\Project\Views\_ViewImports.cshtml"
using digitalhealthza;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\millz\Desktop\container\Pack\project 04\Project\Views\_ViewImports.cshtml"
using Project.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\millz\Desktop\container\Pack\project 04\Project\Views\_ViewImports.cshtml"
using Project.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\millz\Desktop\container\Pack\project 04\Project\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0fd144eb1f55879df0ca74c1ca2924ae31e411e", @"/Views/PharmacistDashboard/PatientDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a619c5f951c1604ddc8de9a4b74f8e82abf9242a", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_PharmacistDashboard_PatientDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DisplayPatientViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/delete.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\millz\Desktop\container\Pack\project 04\Project\Views\PharmacistDashboard\PatientDetails.cshtml"
  
    Layout = "PharmacistLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0fd144eb1f55879df0ca74c1ca2924ae31e411e5050", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<div class=\"card-header\">\r\n    <h3 class=\"card-title\">");
#nullable restore
#line 9 "C:\Users\millz\Desktop\container\Pack\project 04\Project\Views\PharmacistDashboard\PatientDetails.cshtml"
                      Write(Model.Patient.PatientName);

#line default
#line hidden
#nullable disable
            WriteLiteral("     ");
#nullable restore
#line 9 "C:\Users\millz\Desktop\container\Pack\project 04\Project\Views\PharmacistDashboard\PatientDetails.cshtml"
                                                     Write(Model.Patient.PatientSurname);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
</div>
<section class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-6"">
                <h1>Patient Details</h1>
            </div>
            <div class=""col-sm-6"">
                <ol class=""breadcrumb float-sm-right"">
                    <li class=""breadcrumb-item"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0fd144eb1f55879df0ca74c1ca2924ae31e411e7107", async() => {
                WriteLiteral("Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>
                    <li class=""breadcrumb-item active""> Patient Details</li>
                </ol>
            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>
<section class=""content"" style="" padding-left: 16px; padding-right: 16px;"">
    <div class=""row"">
        <div class=""col-md-6"">
            <div class=""card card-primary"">

                <div class=""card-body"">

                    <label>Gender:</label>
                    <p>");
#nullable restore
#line 34 "C:\Users\millz\Desktop\container\Pack\project 04\Project\Views\PharmacistDashboard\PatientDetails.cshtml"
                  Write(Model.Patient.Gender);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <label>ID Number:</label>\r\n                    <p>");
#nullable restore
#line 36 "C:\Users\millz\Desktop\container\Pack\project 04\Project\Views\PharmacistDashboard\PatientDetails.cshtml"
                  Write(Model.Patient.IDNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <label>Email:</label>\r\n                    <p>");
#nullable restore
#line 38 "C:\Users\millz\Desktop\container\Pack\project 04\Project\Views\PharmacistDashboard\PatientDetails.cshtml"
                  Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <label>Contact Number:</label>\r\n                    <p>");
#nullable restore
#line 40 "C:\Users\millz\Desktop\container\Pack\project 04\Project\Views\PharmacistDashboard\PatientDetails.cshtml"
                  Write(Model.Patient.ContactNo);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>

                </div>
                <!-- /.card-body -->
            </div>
            <!-- /.card -->
        </div>

        <div class=""col-md-6"">
            <div class=""card card-primary"">

                <div class=""card-body"">

                    <label>Address :</label>
                    <p>");
#nullable restore
#line 54 "C:\Users\millz\Desktop\container\Pack\project 04\Project\Views\PharmacistDashboard\PatientDetails.cshtml"
                  Write(Model.Patient.AddressLine1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 55 "C:\Users\millz\Desktop\container\Pack\project 04\Project\Views\PharmacistDashboard\PatientDetails.cshtml"
                      if (Model.Patient.AddressLine2 != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p>");
#nullable restore
#line 57 "C:\Users\millz\Desktop\container\Pack\project 04\Project\Views\PharmacistDashboard\PatientDetails.cshtml"
                          Write(Model.Patient.AddressLine2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p> ");
#nullable restore
#line 57 "C:\Users\millz\Desktop\container\Pack\project 04\Project\Views\PharmacistDashboard\PatientDetails.cshtml"
                                                               }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <p>");
#nullable restore
#line 59 "C:\Users\millz\Desktop\container\Pack\project 04\Project\Views\PharmacistDashboard\PatientDetails.cshtml"
                  Write(Model.Surburb.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <p>");
#nullable restore
#line 60 "C:\Users\millz\Desktop\container\Pack\project 04\Project\Views\PharmacistDashboard\PatientDetails.cshtml"
                  Write(Model.city.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p><span></span>\r\n                    <p>");
#nullable restore
#line 61 "C:\Users\millz\Desktop\container\Pack\project 04\Project\Views\PharmacistDashboard\PatientDetails.cshtml"
                  Write(Model.Province.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
            </div>
            <!-- /.card-body -->
        </div>
        <!-- /.card -->
    </div>

    <script src=""https://cdn.jsdelivr.net/npm/sweetalert2@9""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js""></script>

");
            WriteLiteral("\r\n    ");
#nullable restore
#line 74 "C:\Users\millz\Desktop\container\Pack\project 04\Project\Views\PharmacistDashboard\PatientDetails.cshtml"
Write(await Html.PartialAsync("_notificationPartial"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</section>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">

    function openSuccessModal(strMessage) {
        var myDiv = document.getElementById(""MyModalSuccessAlertBody"");
        /*myDiv.innerHTML = strMessage;*/
        myDiv.innerHTML = strMessage;
        $('#myModalSuccess').modal('show');
    }
        $(document).ready(function () {
            var msg =");
#nullable restore
#line 88 "C:\Users\millz\Desktop\container\Pack\project 04\Project\Views\PharmacistDashboard\PatientDetails.cshtml"
                Write(TempData["SuccessMessage"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n            if (msg)\r\n                openSuccessModal(msg);\r\n        });\r\n\r\n    </script>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DisplayPatientViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
