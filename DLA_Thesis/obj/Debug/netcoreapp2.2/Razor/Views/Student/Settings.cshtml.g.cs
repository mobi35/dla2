#pragma checksum "C:\Users\Adrian Radores\Desktop\DLA\DLA_Thesis\Views\Student\Settings.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8bf133e85a759c25815ce527d543a86f3b834ef8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_Settings), @"mvc.1.0.view", @"/Views/Student/Settings.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Student/Settings.cshtml", typeof(AspNetCore.Views_Student_Settings))]
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
#line 1 "C:\Users\Adrian Radores\Desktop\DLA\DLA_Thesis\Views\_ViewImports.cshtml"
using DLA_Thesis;

#line default
#line hidden
#line 2 "C:\Users\Adrian Radores\Desktop\DLA\DLA_Thesis\Views\_ViewImports.cshtml"
using DLA_Thesis.Models;

#line default
#line hidden
#line 3 "C:\Users\Adrian Radores\Desktop\DLA\DLA_Thesis\Views\_ViewImports.cshtml"
using DLA_Thesis.Data.Model;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8bf133e85a759c25815ce527d543a86f3b834ef8", @"/Views/Student/Settings.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf7e3b34e2e060632a06c52427a34d454a7ba707", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_Settings : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("enrollment-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Adrian Radores\Desktop\DLA\DLA_Thesis\Views\Student\Settings.cshtml"
  
    ViewData["Title"] = "Settings";
    Layout = "~/Views/Shared/adminLayout.cshtml";

#line default
#line hidden
            BeginContext(97, 2415, true);
            WriteLiteral(@"

<script>
    var username =  sessionStorage.getItem(""username"");
    $.ajax({

        url: '/Student/GetStudent',
        type: 'get',
        data: {username:username},
        success: function (e) {

            $('#lrn').val(e.lrn);
            $('input[name=""FirstName""]').val(e.firstName);
            $('input[name=""MiddleName""]').val(e.middleName);
            $('input[name=""LastName""]').val(e.lastName);
            $('input[name=""NameExtension""]').val(e.nameExtension);
            $('input[name=""Address""]').val(e.address);
            $('input[name=""Barangay""]').val(e.barangay);
            $('input[name=""City""]').val(e.city);
            $('input[name=""Phonenumber""]').val(e.phonenumber);
            $('input[name=""EmailAddress""]').val(e.emailAddress);


                $('input[name=""FatherFirstName""]').val(e.fatherFirstName);
            $('input[name=""FatherLastName""]').val(e.fatherLastName);
            $('input[name=""FatherOccupation""]').val(e.fatherOccupation);
      ");
            WriteLiteral(@"      $('input[name=""FatherNumber""]').val(e.fatherNumber);

                $('input[name=""MotherFirstName""]').val(e.motherFirstName);
            $('input[name=""MotherLastName""]').val(e.motherLastName);
            $('input[name=""MotherOccupation""]').val(e.motherOccupation);
            $('input[name=""MotherNumber""]').val(e.motherNumber);

                $('input[name=""GuardianFirstName""]').val(e.guardianFirstName);
            $('input[name=""GuardianLastName""]').val(e.guardianLastName);
            $('input[name=""GuardianNumber""]').val(e.guardianNumber);
            $('input[name=""GuardianOccupation""]').val(e.guardianOccupation);
             $('input[name=""Grade""]').val(e.grade);

        }

    });

</script>

<br />
<br />
<br />
<br />
<div class=""content"">

    <div class=""row"">
        <div class=""col-md-12"">
            <div style=""padding:2%;"" class=""card"">





                <style>


                    small {
                        color: red;
          ");
            WriteLiteral(@"          }
                </style>

                <br />
                <br />
           

                <div class=""features"">
                    <div id=""container"" class=""container"">



                

                        <h3>Learner's Detail</h3>

                        <div id=""success""></div>





                        ");
            EndContext();
            BeginContext(2512, 9553, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8bf133e85a759c25815ce527d543a86f3b834ef87054", async() => {
                BeginContext(2569, 9489, true);
                WriteLiteral(@"

                            <div class=""row features_row"">
                                <div class=""col-lg-12 feature_col"">
                                    <label> LRN </label>
                                    <input id=""lrn"" readonly class=""form-control"" name=""LRN"" type=""text"" />
                              
                                </div>

                            </div>


                            <div class=""row features_row"">

                                <!-- Features Item -->
                                <div class=""col-lg-3 feature_col"">
                                    <label> First Name </label>
                                    <input name=""FirstName"" class=""form-control"" type=""text"" />    <small id=""fname""></small>
                                </div>
                                <!-- Features Item -->
                                <div class=""col-lg-3 feature_col"">
                                    <label> Middle Name </label>
  ");
                WriteLiteral(@"                                  <input name=""MiddleName"" class=""form-control"" type=""text"" />     <small id=""mname""></small>
                                </div>
                                <!-- Features Item -->
                                <div class=""col-lg-3 feature_col"">
                                    <label> Last Name </label>
                                    <input name=""LastName"" class=""form-control"" type=""text"" />     <small id=""lname""></small>
                                </div>

                                <!-- Features Item -->
                                <div class=""col-lg-3 feature_col"">
                                    <label> Name Extension </label>
                                    <input name=""NameExtension"" class=""form-control"" type=""text"" />     <small id=""nename""></small>
                                </div>

                            </div>

                            <div class=""row features_row"">

                                ");
                WriteLiteral(@"<!-- Features Item -->
                                <div class=""col-lg-6 feature_col"">
                                    <label> Street Address </label>
                                    <input name=""Address"" class=""form-control"" type=""text"" />  <small id=""address""></small>
                                </div>
                                <!-- Features Item -->
                                <!-- Features Item -->
                                <div class=""col-lg-3 feature_col"">
                                    <label> Barangay </label>
                                    <input name=""Barangay"" class=""form-control"" type=""text"" />  <small id=""barangay""></small>
                                </div>

                                <!-- Features Item -->
                                <div class=""col-lg-3 feature_col"">
                                    <label> City/Municipality </label>
                                    <input name=""City"" class=""form-control"" type=""text"" />");
                WriteLiteral(@"  <small id=""city""></small>
                                </div>

                            </div>


                            <div class=""row features_row"">


                                <div class=""col-lg-3 feature_col"">
                                    <label> Phone Number </label>
                                    <input name=""Phonenumber"" class=""form-control"" type=""text"" /> <small id=""cpnumber""></small>
                                </div>
                                <div class=""col-lg-6 feature_col"">
                                    <label> Email </label>
                                    <input readonly name=""EmailAddress"" class=""form-control"" type=""text"" /> <small id=""email""></small>
                                </div>

                                <div class=""col-lg-3  feature_col"">
                                    <label> Grade This school year </label>
                                    <input readonly name=""CurrentGrade"" class=""form-control"" ");
                WriteLiteral(@"type=""text"" />
                                </div>



                                <!-- Features Item -->


                            </div>




                            <br />
                            <h3>Parent's Detail</h3>

                            <div class=""row features_row"">

                                <!-- Features Item -->
                                <div class=""col-lg-3 feature_col"">
                                    <label> Father's First Name </label>
                                    <input name=""FatherFirstName"" class=""form-control"" type=""text"" /> <small id=""fatherfname""></small>
                                </div>
                                <!-- Features Item -->
                                <!-- Features Item -->
                                <div class=""col-lg-3 feature_col"">
                                    <label> Father's Last Name  </label>
                                    <input name=""FatherLastName"" class=""form");
                WriteLiteral(@"-control"" type=""text"" /> <small id=""fatherlname""></small>
                                </div>

                                <!-- Features Item -->
                                <div class=""col-lg-3 feature_col"">
                                    <label> Father's Occupation  </label>
                                    <input name=""FatherOccupation"" class=""form-control"" type=""text"" /> <small id=""fatheroccupation""></small>
                                </div>

                                <div class=""col-lg-3 feature_col"">
                                    <label> Father's Phone Number  </label>
                                    <input name=""FatherNumber"" class=""form-control"" type=""text"" /> <small id=""fathercpnumber""></small>
                                </div>

                            </div>



                            <div class=""row features_row"">

                                <!-- Features Item -->
                                <div class=""col-lg-3 feat");
                WriteLiteral(@"ure_col"">
                                    <label> Mother's First Name </label>
                                    <input name=""MotherFirstName"" class=""form-control"" type=""text"" /> <small id=""motherfname""></small>
                                </div>
                                <!-- Features Item -->
                                <!-- Features Item -->
                                <div class=""col-lg-3 feature_col"">
                                    <label> Mother's Last Name  </label>
                                    <input name=""MotherLastName"" class=""form-control"" type=""text"" /> <small id=""motherlname""></small>
                                </div>

                                <!-- Features Item -->
                                <div class=""col-lg-3 feature_col"">
                                    <label> Mother's Occupation  </label>
                                    <input name=""MotherOccupation"" class=""form-control"" type=""text"" /> <small id=""motheroccupation""><");
                WriteLiteral(@"/small>
                                </div>

                                <div class=""col-lg-3 feature_col"">
                                    <label> Mother's Phone Number  </label>
                                    <input name=""MotherNumber"" class=""form-control"" type=""text"" /> <small id=""mothercpnumber""></small>
                                </div>

                            </div>


                            <div class=""row features_row"">

                                <!-- Features Item -->
                                <div class=""col-lg-3 feature_col"">
                                    <label> Guardian First Name </label>
                                    <input name=""GuardianFirstName"" class=""form-control"" type=""text"" /> <small id=""guardianfname""></small>
                                </div>
                                <!-- Features Item -->
                                <!-- Features Item -->
                                <div class=""col-lg-3 featu");
                WriteLiteral(@"re_col"">
                                    <label> Guardian Last Name  </label>
                                    <input name=""GuardianLastName"" class=""form-control"" type=""text"" /> <small id=""guardianlname""></small>
                                </div>

                                <!-- Features Item -->
                                <div class=""col-lg-3 feature_col"">
                                    <label> Guardian's Occupation  </label>
                                    <input name=""GuardianNumber"" class=""form-control"" type=""text"" /> <small id=""guardianoccupation""></small>
                                </div>

                                <div class=""col-lg-3 feature_col"">
                                    <label> Guardian's Phone Number  </label>
                                    <input name=""GuardianOccupation"" class=""form-control"" type=""text"" /> <small id=""guardiancpnumber""></small>
                                </div>

                            </div>


");
                WriteLiteral(@"
                            <br />
                         

                         
                          
                            <br />
                            <input class=""btn btn-primary"" type=""submit"" value=""Update"" />
                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(12065, 9126, true);
            WriteLiteral(@"


                    </div>
                </div>


                <script>
                     $('#updatedetails').addClass('active');

                    document.getElementById('enrollment-form').onsubmit = function () {


                        var form = $(this);


                        $.ajax({
                            type: ""POST"",
                            processData: false,
                            contentType: false,
                            url: '/Student/UpdateAccount',
                            data: new FormData(this),
                            success: function (data) {



                                if (data.split(',').includes(""lrn_error"")) {
                                    $('#lrn').html(""LRN should be 12 numerical character"");
                                } else if (data.split(',').includes(""lrn_number_only"")) {
                                    $('#lrn').html(""Number only"");
                                } else if (data.");
            WriteLiteral(@"split(',').includes(""lrn_exist"")) {
                                    $('#lrn').html(""LRN already existed"");
                                } else {
                                    $('#lrn').html("""");
                                }



                                if (data.split(',').includes(""fname"")) {
                                    $('#fname').html(""First name is required"");
                                } else {
                                    $('#fname').html("""");
                                }

                                if (data.split(',').includes(""mname"")) {
                                    $('#mname').html(""Middle name is required"");
                                } else {
                                    $('#mname').html("""");
                                }

                                if (data.split(',').includes(""lname"")) {
                                    $('#lname').html(""Last name is required"");
                              ");
            WriteLiteral(@"  } else {
                                    $('#lname').html("""");
                                }



                                if (data.split(',').includes(""address"")) {
                                    $('#address').html(""Address is required"");
                                } else {
                                    $('#address').html("""");
                                }

                                if (data.split(',').includes(""barangay"")) {
                                    $('#barangay').html(""Barangay is required"");
                                } else {
                                    $('#barangay').html("""");
                                }

                                if (data.split(',').includes(""city"")) {
                                    $('#city').html(""City is required"");
                                } else {
                                    $('#city').html("""");
                                }


                              ");
            WriteLiteral(@"  if (data.split(',').includes(""cpnumber"")) {
                                    $('#cpnumber').html(""Cp number is required"");
                                } else {
                                    $('#cpnumber').html("""");
                                }




                                if (data.split(',').includes(""fatherfname"")) {
                                    $('#fatherfname').html(""Father's first name is required"");
                                } else {
                                    $('#fatherfname').html("""");
                                }


                                if (data.split(',').includes(""fatherlname"")) {
                                    $('#fatherlname').html(""Father's last name is required"");
                                } else {
                                    $('#fatherlname').html("""");
                                }







                                if (data.split(',').includes(""motherfname"")) {
              ");
            WriteLiteral(@"                      $('#motherfname').html(""Mother's first name is required"");
                                } else {
                                    $('#motherfname').html("""");
                                }


                                if (data.split(',').includes(""motherlname"")) {
                                    $('#motherlname').html(""Mother's last name is required"");
                                } else {
                                    $('#motherlname').html("""");
                                }


                                if (data.split(',').includes(""motheroccupation"")) {
                                    $('#motheroccupation').html("""");
                                } else {
                                    $('#motheroccupation').html("""");
                                }


                                if (data.split(',').includes(""mothercpnumber"")) {
                                    $('#mothercpnumber').html("""");
                  ");
            WriteLiteral(@"              } else {
                                    $('#mothercpnumber').html("""");
                                }



                                if (data.split(',').includes(""guardianfname"")) {
                                    $('#guardianfname').html("""");
                                } else {
                                    $('#guardianfname').html("""");
                                }




                                if (data.split(',').includes(""guardianlname"")) {
                                    $('#guardianlname').html("""");
                                } else {
                                    $('#guardianlname').html("""");
                                }



                                if (data.split(',').includes(""guardianoccupation"")) {
                                    $('#guardianoccupation').html("""");
                                } else {
                                    $('#guardianoccupation').html("""");
                  ");
            WriteLiteral(@"              }




                                if (data.split(',').includes(""guardiancpnumber"")) {
                                    $('#guardiancpnumber').html("""");
                                } else {
                                    $('#guardiancpnumber').html("""");
                                }


                                if (data.split(',').includes(""bc"")) {
                                    $('#bc').html("""");
                                } else {
                                    $('#bc').html("""");
                                }

                                if (data.split(',').includes(""f137"")) {
                                    $('#f137').html("""");
                                } else {
                                    $('#f137').html("""");
                                }

                                if (data.split(',').includes(""f138"")) {
                                    $('#f138').html("""");
                                ");
            WriteLiteral(@"} else {
                                    $('#f138').html("""");
                                }

                                if (data.split(',').includes(""goodmoral"")) {
                                    $('#goodmoral').html("""");
                                } else {
                                    $('#goodmoral').html("""");
                                }


                                if (data.split(',').includes(""image"")) {
                                    $('#image').html("""");
                                } else {
                                    $('#image').html("""");
                                }

                                alert(data);

                                if (data.split(',').includes(""email_exist"")) {
                                    $('#email').html(""Email already exist"");
                                }
                                else if (data.split(',').includes(""email"")) {
                                    $('#ema");
            WriteLiteral(@"il').html(""Email is required"");
                                } else if (data.split(',').includes(""invalid_email"")) {
                                    $('#email').html(""This is not a valid email"");
                                } else {
                                    $('#email').html("""");
                                }



                                if (data == ""success"") {
                                    $('#success').html(""  <div class='alert alert-success'>Successfully Updated</div>"");
                               



                                }


                                document.getElementById(""container"").scrollIntoView();

                            }
                        });

                        return false;

                    }



                </script>






            </div>
        </div>
    </div>
</div>
           ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
