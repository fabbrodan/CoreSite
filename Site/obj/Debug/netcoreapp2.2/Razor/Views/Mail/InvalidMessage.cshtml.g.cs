#pragma checksum "C:\Users\admin\Documents\Visual Studio 2019\Projects\EsterSite\Site\Views\Mail\InvalidMessage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75220163a3b46c0c966bd0cf5d83c17800839e2c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Mail_InvalidMessage), @"mvc.1.0.view", @"/Views/Mail/InvalidMessage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Mail/InvalidMessage.cshtml", typeof(AspNetCore.Views_Mail_InvalidMessage))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"75220163a3b46c0c966bd0cf5d83c17800839e2c", @"/Views/Mail/InvalidMessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"70e3a3f90f6d4c226913e942091a3f82dd825d74", @"/Views/_ViewImports.cshtml")]
    public class Views_Mail_InvalidMessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 259, true);
            WriteLiteral(@"<div class=""container"">
    <h1>Oooops!</h1>
</div>
<div class=""container"">
    <h3>You tried to send a message that contained something inappropriate.</h3>
    <h4>Please fuck off with that.</h4>
    <p style=""font-size:xx-small"">Thank you.</p>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
