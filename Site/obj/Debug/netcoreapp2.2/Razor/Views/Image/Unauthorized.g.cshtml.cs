#pragma checksum "C:\Users\admin\Documents\Visual Studio 2019\Projects\EsterSite\Site\Views\Image\Unauthorized.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27591879a51b86c8265498e08493363f9571afcf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Image_Unauthorized), @"mvc.1.0.view", @"/Views/Image/Unauthorized.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Image/Unauthorized.cshtml", typeof(AspNetCore.Views_Image_Unauthorized))]
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
#line 1 "C:\Users\admin\Documents\Visual Studio 2019\Projects\EsterSite\Site\Views\_ViewImports.cshtml"
using Site;

#line default
#line hidden
#line 2 "C:\Users\admin\Documents\Visual Studio 2019\Projects\EsterSite\Site\Views\_ViewImports.cshtml"
using Site.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27591879a51b86c8265498e08493363f9571afcf", @"/Views/Image/Unauthorized.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"70e3a3f90f6d4c226913e942091a3f82dd825d74", @"/Views/_ViewImports.cshtml")]
    public class Views_Image_Unauthorized : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\admin\Documents\Visual Studio 2019\Projects\EsterSite\Site\Views\Image\Unauthorized.cshtml"
  
    ViewData["Title"] = "Unauthorized - ";

#line default
#line hidden
            BeginContext(51, 183, true);
            WriteLiteral("<div class=\"container\">\r\n\r\n    <h1>Unauthorized</h1>\r\n    <h3>You have to login to access this page!</h3>\r\n    <p>Please use <a href=\"/Home/Login\">this page</a> to login</p>\r\n\r\n</div>");
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
