#pragma checksum "C:\Users\Adrian Radores\Desktop\lyn\dla\DLA_Thesis\Views\Home\Admin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7fc46486f451599895d71712e67070d485811797"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Admin), @"mvc.1.0.view", @"/Views/Home/Admin.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Admin.cshtml", typeof(AspNetCore.Views_Home_Admin))]
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
#line 1 "C:\Users\Adrian Radores\Desktop\lyn\dla\DLA_Thesis\Views\_ViewImports.cshtml"
using DLA_Thesis;

#line default
#line hidden
#line 2 "C:\Users\Adrian Radores\Desktop\lyn\dla\DLA_Thesis\Views\_ViewImports.cshtml"
using DLA_Thesis.Models;

#line default
#line hidden
#line 3 "C:\Users\Adrian Radores\Desktop\lyn\dla\DLA_Thesis\Views\_ViewImports.cshtml"
using DLA_Thesis.Data.Model;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7fc46486f451599895d71712e67070d485811797", @"/Views/Home/Admin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf7e3b34e2e060632a06c52427a34d454a7ba707", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Admin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Dashboard>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Adrian Radores\Desktop\lyn\dla\DLA_Thesis\Views\Home\Admin.cshtml"
  
    Layout = "adminLayout";
    ViewData["Title"] = "Admin";

#line default
#line hidden
            BeginContext(88, 595, true);
            WriteLiteral(@"



<div class=""col-lg-3 col-md-6 col-sm-6"">
    <div class=""card card-stats"">
        <div class=""card-body "">
            <div class=""row"">
                <div class=""col-5 col-md-4"">
                    <div class=""icon-big text-center icon-warning"">
                        <i class=""nc-icon nc-globe text-warning""></i>
                    </div>
                </div>
                <div class=""col-7 col-md-8"">
                    <div class=""numbers"">
                        <p class=""card-category"">Number of student</p>
                        <p class=""card-title"">");
            EndContext();
            BeginContext(684, 21, false);
#line 22 "C:\Users\Adrian Radores\Desktop\lyn\dla\DLA_Thesis\Views\Home\Admin.cshtml"
                                         Write(Model.NumberOfStudent);

#line default
#line hidden
            EndContext();
            BeginContext(705, 817, true);
            WriteLiteral(@"
                        <p>
                    </div>
                </div>
            </div>
        </div>
        <div class=""card-footer "">
            <hr>
            
        </div>
    </div>
</div>
<div class=""col-lg-3 col-md-6 col-sm-6"">
    <div class=""card card-stats"">
        <div class=""card-body "">
            <div class=""row"">
                <div class=""col-5 col-md-4"">
                    <div class=""icon-big text-center icon-warning"">
                        <i class=""nc-icon nc-money-coins text-success""></i>
                    </div>
                </div>
                <div class=""col-7 col-md-8"">
                    <div class=""numbers"">
                        <p class=""card-category"">Number of Teachers</p>
                        <p class=""card-title"">");
            EndContext();
            BeginContext(1523, 21, false);
#line 46 "C:\Users\Adrian Radores\Desktop\lyn\dla\DLA_Thesis\Views\Home\Admin.cshtml"
                                         Write(Model.NumberOfTeacher);

#line default
#line hidden
            EndContext();
            BeginContext(1544, 788, true);
            WriteLiteral(@"
<p>
                    </div>
                </div>
            </div>
        </div>
        <div class=""card-footer "">
            <hr>
           
        </div>
    </div>
</div>
<div class=""col-lg-3 col-md-6 col-sm-6"">
    <div class=""card card-stats"">
        <div class=""card-body "">
            <div class=""row"">
                <div class=""col-5 col-md-4"">
                    <div class=""icon-big text-center icon-warning"">
                        <i class=""nc-icon nc-vector text-danger""></i>
                    </div>
                </div>
                <div class=""col-7 col-md-8"">
                    <div class=""numbers"">
                        <p class=""card-category"">Number of Employees</p>
                        <p class=""card-title""> ");
            EndContext();
            BeginContext(2333, 23, false);
#line 70 "C:\Users\Adrian Radores\Desktop\lyn\dla\DLA_Thesis\Views\Home\Admin.cshtml"
                                          Write(Model.NumberOfEmployees);

#line default
#line hidden
            EndContext();
            BeginContext(2356, 789, true);
            WriteLiteral(@"
<p>
                    </div>
                </div>
            </div>
        </div>
        <div class=""card-footer "">
            <hr>
          
        </div>
    </div>
</div>
<div class=""col-lg-3 col-md-6 col-sm-6"">
    <div class=""card card-stats"">
        <div class=""card-body "">
            <div class=""row"">
                <div class=""col-5 col-md-4"">
                    <div class=""icon-big text-center icon-warning"">
                        <i class=""nc-icon nc-favourite-28 text-primary""></i>
                    </div>
                </div>
                <div class=""col-7 col-md-8"">
                    <div class=""numbers"">
                        <p class=""card-category"">Total Payments</p>
                        <p class=""card-title""> ");
            EndContext();
            BeginContext(3146, 19, false);
#line 94 "C:\Users\Adrian Radores\Desktop\lyn\dla\DLA_Thesis\Views\Home\Admin.cshtml"
                                          Write(Model.TotalPayments);

#line default
#line hidden
            EndContext();
            BeginContext(3165, 1104, true);
            WriteLiteral(@"
                        <p>
                    </div>
                </div>
            </div>
        </div>
        <div class=""card-footer "">
            <hr>
         
        </div>
    </div>
</div>



<script src=""https://cdn.jsdelivr.net/npm/chart.js@2.8.0""></script>
<div class=""row"">
    <div class=""col-md-6"">
        <div class=""card "">
            <div class=""card-header "">
                <h5 class=""card-title"">Payments</h5>
               
            </div>
            <div class=""card-body "">
                <canvas id=""chart"" width=""400"" height=""250""></canvas>
                <script>
                    var ccc = document.getElementById('chart').getContext('2d');
                    var chart = new Chart(ccc, {
                        type: 'bar',
                        data: {
                            labels: [""Jan"",""Feb"",""Mar"",""April"",""May"",""June"",""Jul"",""Aug"",""Sep"",""Oct"",""Nov"",""Dec""],
                            datasets: [{
                           ");
            WriteLiteral("     label: \'Total Payment\',\r\n                                data: JSON.parse(\'");
            EndContext();
            BeginContext(4270, 51, false);
#line 127 "C:\Users\Adrian Radores\Desktop\lyn\dla\DLA_Thesis\Views\Home\Admin.cshtml"
                                             Write(Html.Raw(Json.Serialize(Model.PaymentsChartValues)));

#line default
#line hidden
            EndContext();
            BeginContext(4321, 2176, true);
            WriteLiteral(@"'),
                                backgroundColor: [
                                    'rgba(255, 99, 132, 0.2)',
                                    'rgba(54, 162, 235, 0.2)',
                                    'rgba(255, 206, 86, 0.2)',
                                    'rgba(75, 192, 192, 0.2)',
                                    'rgba(153, 102, 255, 0.2)',
                                    'rgba(255, 159, 64, 0.2)'
                                ],
                                borderColor: [
                                    'rgba(255, 99, 132, 1)',
                                    'rgba(54, 162, 235, 1)',
                                    'rgba(255, 206, 86, 1)',
                                    'rgba(75, 192, 192, 1)',
                                    'rgba(153, 102, 255, 1)',
                                    'rgba(255, 159, 64, 1)'
                                ],
                                borderWidth: 1
                            }]
           ");
            WriteLiteral(@"             },
                        options: {
                            scales: {
                                yAxes: [{
                                    ticks: {
                                        beginAtZero: true
                                    }
                                }]
                            }
                        }
                    });
                </script>
            </div>
           
        </div>
    </div>
    <div class=""col-md-6"">
        <div class=""card card-chart"">
            <div class=""card-header"">
                <h5 class=""card-title"">Enrolled per subject</h5>
            </div>

            <script src=""https://cdn.jsdelivr.net/npm/chart.js@2.8.0""></script>
            <div class=""card-body"">
                <canvas id=""myChart"" width=""400"" height=""250""></canvas>
                <script>
                    var ctx = document.getElementById('myChart').getContext('2d');
                    var myChart = new Chart");
            WriteLiteral("(ctx, {\r\n                        type: \'pie\',\r\n                        data: {\r\n                            labels: JSON.parse(\'");
            EndContext();
            BeginContext(6498, 61, false);
#line 176 "C:\Users\Adrian Radores\Desktop\lyn\dla\DLA_Thesis\Views\Home\Admin.cshtml"
                                           Write(Html.Raw(Json.Serialize(Model.EnrolledPerSubjectLabelGrade7)));

#line default
#line hidden
            EndContext();
            BeginContext(6559, 153, true);
            WriteLiteral("\'),\r\n                            datasets: [{\r\n                                label: \'# of Subject\',\r\n                                data: JSON.parse(\'");
            EndContext();
            BeginContext(6713, 62, false);
#line 179 "C:\Users\Adrian Radores\Desktop\lyn\dla\DLA_Thesis\Views\Home\Admin.cshtml"
                                             Write(Html.Raw(Json.Serialize(Model.EnrolledPerSubjectValuesGrade7)));

#line default
#line hidden
            EndContext();
            BeginContext(6775, 2212, true);
            WriteLiteral(@"'),
                                backgroundColor: [
                                    'rgba(255, 99, 132, 0.2)',
                                    'rgba(54, 162, 235, 0.2)',
                                    'rgba(255, 206, 86, 0.2)',
                                    'rgba(75, 192, 192, 0.2)',
                                    'rgba(153, 102, 255, 0.2)',
                                    'rgba(255, 159, 64, 0.2)'
                                ],
                                borderColor: [
                                    'rgba(255, 99, 132, 1)',
                                    'rgba(54, 162, 235, 1)',
                                    'rgba(255, 206, 86, 1)',
                                    'rgba(75, 192, 192, 1)',
                                    'rgba(153, 102, 255, 1)',
                                    'rgba(255, 159, 64, 1)'
                                ],
                                borderWidth: 1
                            }]
           ");
            WriteLiteral(@"             },
                        options: {
                            scales: {
                                yAxes: [{
                                    ticks: {
                                        beginAtZero: true
                                    }
                                }]
                            }
                        }
                    });
                </script>
            </div>
          


        </div>
    </div>





    <div class=""col-md-6"">
        <div class=""card card-chart"">
            <div class=""card-header"">
                <h5 class=""card-title"">Enrolled per subject</h5>
            </div>

            <script src=""https://cdn.jsdelivr.net/npm/chart.js@2.8.0""></script>
            <div class=""card-body"">
                <canvas id=""grade8Chart"" width=""400"" height=""250""></canvas>
                <script>
                    var grade8Chart = document.getElementById('grade8Chart').getContext('2d');
              ");
            WriteLiteral("      var chart8 = new Chart(grade8Chart, {\r\n                        type: \'pie\',\r\n                        data: {\r\n                            labels: JSON.parse(\'");
            EndContext();
            BeginContext(8988, 61, false);
#line 235 "C:\Users\Adrian Radores\Desktop\lyn\dla\DLA_Thesis\Views\Home\Admin.cshtml"
                                           Write(Html.Raw(Json.Serialize(Model.EnrolledPerSubjectLabelGrade8)));

#line default
#line hidden
            EndContext();
            BeginContext(9049, 153, true);
            WriteLiteral("\'),\r\n                            datasets: [{\r\n                                label: \'# of Subject\',\r\n                                data: JSON.parse(\'");
            EndContext();
            BeginContext(9203, 62, false);
#line 238 "C:\Users\Adrian Radores\Desktop\lyn\dla\DLA_Thesis\Views\Home\Admin.cshtml"
                                             Write(Html.Raw(Json.Serialize(Model.EnrolledPerSubjectValuesGrade8)));

#line default
#line hidden
            EndContext();
            BeginContext(9265, 2216, true);
            WriteLiteral(@"'),
                                backgroundColor: [
                                    'rgba(255, 99, 132, 0.2)',
                                    'rgba(54, 162, 235, 0.2)',
                                    'rgba(255, 206, 86, 0.2)',
                                    'rgba(75, 192, 192, 0.2)',
                                    'rgba(153, 102, 255, 0.2)',
                                    'rgba(255, 159, 64, 0.2)'
                                ],
                                borderColor: [
                                    'rgba(255, 99, 132, 1)',
                                    'rgba(54, 162, 235, 1)',
                                    'rgba(255, 206, 86, 1)',
                                    'rgba(75, 192, 192, 1)',
                                    'rgba(153, 102, 255, 1)',
                                    'rgba(255, 159, 64, 1)'
                                ],
                                borderWidth: 1
                            }]
           ");
            WriteLiteral(@"             },
                        options: {
                            scales: {
                                yAxes: [{
                                    ticks: {
                                        beginAtZero: true
                                    }
                                }]
                            }
                        }
                    });
                </script>
            </div>
        


        </div>
    </div>








    <div class=""col-md-6"">
        <div class=""card card-chart"">
            <div class=""card-header"">
                <h5 class=""card-title"">Enrolled per subject</h5>
            </div>

            <script src=""https://cdn.jsdelivr.net/npm/chart.js@2.8.0""></script>
            <div class=""card-body"">
                <canvas id=""grade9Chart"" width=""400"" height=""250""></canvas>
                <script>
                    var grade9Chart = document.getElementById('grade9Chart').getContext('2d');
          ");
            WriteLiteral("          var chart9 = new Chart(grade9Chart, {\r\n                        type: \'pie\',\r\n                        data: {\r\n                            labels: JSON.parse(\'");
            EndContext();
            BeginContext(11482, 61, false);
#line 297 "C:\Users\Adrian Radores\Desktop\lyn\dla\DLA_Thesis\Views\Home\Admin.cshtml"
                                           Write(Html.Raw(Json.Serialize(Model.EnrolledPerSubjectLabelGrade9)));

#line default
#line hidden
            EndContext();
            BeginContext(11543, 153, true);
            WriteLiteral("\'),\r\n                            datasets: [{\r\n                                label: \'# of Subject\',\r\n                                data: JSON.parse(\'");
            EndContext();
            BeginContext(11697, 62, false);
#line 300 "C:\Users\Adrian Radores\Desktop\lyn\dla\DLA_Thesis\Views\Home\Admin.cshtml"
                                             Write(Html.Raw(Json.Serialize(Model.EnrolledPerSubjectValuesGrade9)));

#line default
#line hidden
            EndContext();
            BeginContext(11759, 2199, true);
            WriteLiteral(@"'),
                                backgroundColor: [
                                    'rgba(255, 99, 132, 0.2)',
                                    'rgba(54, 162, 235, 0.2)',
                                    'rgba(255, 206, 86, 0.2)',
                                    'rgba(75, 192, 192, 0.2)',
                                    'rgba(153, 102, 255, 0.2)',
                                    'rgba(255, 159, 64, 0.2)'
                                ],
                                borderColor: [
                                    'rgba(255, 99, 132, 1)',
                                    'rgba(54, 162, 235, 1)',
                                    'rgba(255, 206, 86, 1)',
                                    'rgba(75, 192, 192, 1)',
                                    'rgba(153, 102, 255, 1)',
                                    'rgba(255, 159, 64, 1)'
                                ],
                                borderWidth: 1
                            }]
           ");
            WriteLiteral(@"             },
                        options: {
                            scales: {
                                yAxes: [{
                                    ticks: {
                                        beginAtZero: true
                                    }
                                }]
                            }
                        }
                    });
                </script>
            </div>


        </div>
    </div>


    <div class=""col-md-6"">
        <div class=""card card-chart"">
            <div class=""card-header"">
                <h5 class=""card-title"">Enrolled per subject</h5>
            </div>

            <script src=""https://cdn.jsdelivr.net/npm/chart.js@2.8.0""></script>
            <div class=""card-body"">
                <canvas id=""grade10Chart"" width=""400"" height=""250""></canvas>
                <script>
                    var grade10Chart = document.getElementById('grade10Chart').getContext('2d');
                    var chart");
            WriteLiteral("10 = new Chart(grade10Chart, {\r\n                        type: \'pie\',\r\n                        data: {\r\n                            labels: JSON.parse(\'");
            EndContext();
            BeginContext(13959, 62, false);
#line 352 "C:\Users\Adrian Radores\Desktop\lyn\dla\DLA_Thesis\Views\Home\Admin.cshtml"
                                           Write(Html.Raw(Json.Serialize(Model.EnrolledPerSubjectLabelGrade10)));

#line default
#line hidden
            EndContext();
            BeginContext(14021, 153, true);
            WriteLiteral("\'),\r\n                            datasets: [{\r\n                                label: \'# of Subject\',\r\n                                data: JSON.parse(\'");
            EndContext();
            BeginContext(14175, 63, false);
#line 355 "C:\Users\Adrian Radores\Desktop\lyn\dla\DLA_Thesis\Views\Home\Admin.cshtml"
                                             Write(Html.Raw(Json.Serialize(Model.EnrolledPerSubjectValuesGrade10)));

#line default
#line hidden
            EndContext();
            BeginContext(14238, 2214, true);
            WriteLiteral(@"'),
                                backgroundColor: [
                                    'rgba(255, 99, 132, 0.2)',
                                    'rgba(54, 162, 235, 0.2)',
                                    'rgba(255, 206, 86, 0.2)',
                                    'rgba(75, 192, 192, 0.2)',
                                    'rgba(153, 102, 255, 0.2)',
                                    'rgba(255, 159, 64, 0.2)'
                                ],
                                borderColor: [
                                    'rgba(255, 99, 132, 1)',
                                    'rgba(54, 162, 235, 1)',
                                    'rgba(255, 206, 86, 1)',
                                    'rgba(75, 192, 192, 1)',
                                    'rgba(153, 102, 255, 1)',
                                    'rgba(255, 159, 64, 1)'
                                ],
                                borderWidth: 1
                            }]
           ");
            WriteLiteral(@"             },
                        options: {
                            scales: {
                                yAxes: [{
                                    ticks: {
                                        beginAtZero: true
                                    }
                                }]
                            }
                        }
                    });
                </script>
            </div>
         

        </div>
    </div>





    <div class=""col-md-6"">
        <div class=""card card-chart"">
            <div class=""card-header"">
                <h5 class=""card-title"">Enrolled per subject</h5>
            </div>

            <script src=""https://cdn.jsdelivr.net/npm/chart.js@2.8.0""></script>
            <div class=""card-body"">
                <canvas id=""grade11Chart"" width=""400"" height=""250""></canvas>
                <script>
                    var grade11Chart = document.getElementById('grade11Chart').getContext('2d');
              ");
            WriteLiteral("      var chart11 = new Chart(grade11Chart, {\r\n                        type: \'pie\',\r\n                        data: {\r\n                            labels: JSON.parse(\'");
            EndContext();
            BeginContext(16453, 62, false);
#line 410 "C:\Users\Adrian Radores\Desktop\lyn\dla\DLA_Thesis\Views\Home\Admin.cshtml"
                                           Write(Html.Raw(Json.Serialize(Model.EnrolledPerSubjectLabelGrade11)));

#line default
#line hidden
            EndContext();
            BeginContext(16515, 153, true);
            WriteLiteral("\'),\r\n                            datasets: [{\r\n                                label: \'# of Subject\',\r\n                                data: JSON.parse(\'");
            EndContext();
            BeginContext(16669, 63, false);
#line 413 "C:\Users\Adrian Radores\Desktop\lyn\dla\DLA_Thesis\Views\Home\Admin.cshtml"
                                             Write(Html.Raw(Json.Serialize(Model.EnrolledPerSubjectValuesGrade11)));

#line default
#line hidden
            EndContext();
            BeginContext(16732, 2212, true);
            WriteLiteral(@"'),
                                backgroundColor: [
                                    'rgba(255, 99, 132, 0.2)',
                                    'rgba(54, 162, 235, 0.2)',
                                    'rgba(255, 206, 86, 0.2)',
                                    'rgba(75, 192, 192, 0.2)',
                                    'rgba(153, 102, 255, 0.2)',
                                    'rgba(255, 159, 64, 0.2)'
                                ],
                                borderColor: [
                                    'rgba(255, 99, 132, 1)',
                                    'rgba(54, 162, 235, 1)',
                                    'rgba(255, 206, 86, 1)',
                                    'rgba(75, 192, 192, 1)',
                                    'rgba(153, 102, 255, 1)',
                                    'rgba(255, 159, 64, 1)'
                                ],
                                borderWidth: 1
                            }]
           ");
            WriteLiteral(@"             },
                        options: {
                            scales: {
                                yAxes: [{
                                    ticks: {
                                        beginAtZero: true
                                    }
                                }]
                            }
                        }
                    });
                </script>
            </div>
         


        </div>
    </div>



    <div class=""col-md-6"">
        <div class=""card card-chart"">
            <div class=""card-header"">
                <h5 class=""card-title"">Enrolled per subject</h5>
            </div>

            <script src=""https://cdn.jsdelivr.net/npm/chart.js@2.8.0""></script>
            <div class=""card-body"">
                <canvas id=""grade12Chart"" width=""400"" height=""250""></canvas>
                <script>
                    var grade12Chart = document.getElementById('grade12Chart').getContext('2d');
                ");
            WriteLiteral("    var chart12 = new Chart(grade12Chart, {\r\n                        type: \'pie\',\r\n                        data: {\r\n                            labels: JSON.parse(\'");
            EndContext();
            BeginContext(18945, 62, false);
#line 467 "C:\Users\Adrian Radores\Desktop\lyn\dla\DLA_Thesis\Views\Home\Admin.cshtml"
                                           Write(Html.Raw(Json.Serialize(Model.EnrolledPerSubjectLabelGrade12)));

#line default
#line hidden
            EndContext();
            BeginContext(19007, 153, true);
            WriteLiteral("\'),\r\n                            datasets: [{\r\n                                label: \'# of Subject\',\r\n                                data: JSON.parse(\'");
            EndContext();
            BeginContext(19161, 63, false);
#line 470 "C:\Users\Adrian Radores\Desktop\lyn\dla\DLA_Thesis\Views\Home\Admin.cshtml"
                                             Write(Html.Raw(Json.Serialize(Model.EnrolledPerSubjectValuesGrade12)));

#line default
#line hidden
            EndContext();
            BeginContext(19224, 1571, true);
            WriteLiteral(@"'),
                                backgroundColor: [
                                    'rgba(255, 99, 132, 0.2)',
                                    'rgba(54, 162, 235, 0.2)',
                                    'rgba(255, 206, 86, 0.2)',
                                    'rgba(75, 192, 192, 0.2)',
                                    'rgba(153, 102, 255, 0.2)',
                                    'rgba(255, 159, 64, 0.2)'
                                ],
                                borderColor: [
                                    'rgba(255, 99, 132, 1)',
                                    'rgba(54, 162, 235, 1)',
                                    'rgba(255, 206, 86, 1)',
                                    'rgba(75, 192, 192, 1)',
                                    'rgba(153, 102, 255, 1)',
                                    'rgba(255, 159, 64, 1)'
                                ],
                                borderWidth: 1
                            }]
           ");
            WriteLiteral(@"             },
                        options: {
                            scales: {
                                yAxes: [{
                                    ticks: {
                                        beginAtZero: true
                                    }
                                }]
                            }
                        }
                    });
                </script>
            </div>
          

        </div>
    </div>




    <div class=""col-md-6"">

    </div>


</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Dashboard> Html { get; private set; }
    }
}
#pragma warning restore 1591
