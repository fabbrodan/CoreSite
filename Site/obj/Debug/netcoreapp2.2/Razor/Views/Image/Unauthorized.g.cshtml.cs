#pragma checksum "C:\Users\DAS\Documents\Visual Studio 2017\Projects\Site\Site\Views\Image\Unauthorized.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5411321360a3f72e23d9a72b4001498c890b634a"
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
#line 1 "C:\Users\DAS\Documents\Visual Studio 2017\Projects\Site\Site\Views\_ViewImports.cshtml"
using Site;

#line default
#line hidden
#line 2 "C:\Users\DAS\Documents\Visual Studio 2017\Projects\Site\Site\Views\_ViewImports.cshtml"
using Site.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5411321360a3f72e23d9a72b4001498c890b634a", @"/Views/Image/Unauthorized.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"70e3a3f90f6d4c226913e942091a3f82dd825d74", @"/Views/_ViewImports.cshtml")]
    public class Views_Image_Unauthorized : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\DAS\Documents\Visual Studio 2017\Projects\Site\Site\Views\Image\Unauthorized.cshtml"
  
    ViewData["Title"] = "Unauthorized";

#line default
#line hidden
            BeginContext(50, 205, true);
            WriteLiteral("\r\n<h1>Unauthorized</h1>\r\n\r\n<div class=\"container\">\r\n    <h3>You have to login to access this page!</h3>\r\n    <p>Please use <a href=\"https://localhost:5001/Home/Login\">this page</a> to login</p>\r\n</div>\r\n\r\n");
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
