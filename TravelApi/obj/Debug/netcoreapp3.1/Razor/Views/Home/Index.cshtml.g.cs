#pragma checksum "C:\Users\andre\desktop\projects\portfolio\csharp\travelapi.solution\travelapi\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6bbce851bcdf0b9651357b0f2e20cee234d95ac3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\andre\desktop\projects\portfolio\csharp\travelapi.solution\travelapi\Views\_ViewImports.cshtml"
using travelapi;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\andre\desktop\projects\portfolio\csharp\travelapi.solution\travelapi\Views\_ViewImports.cshtml"
using travelapi.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bbce851bcdf0b9651357b0f2e20cee234d95ac3", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"087fc01808a826beab4a1cc30ccc5a4f8d6b33f7", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\andre\desktop\projects\portfolio\csharp\travelapi.solution\travelapi\Views\Home\Index.cshtml"
  
  Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("  <div class=jumbotron>\r\n    <h1 class=\"display-4\">Travel Reviews</h1>\r\n  </div>\r\n  <img src=\"https://www.ltteps.org/wp-content/uploads/2019/06/travel-editor-favorite-products.jpg\" class=\"img-fluid\">\r\n\r\n<div class=\"footer\">\r\n");
#nullable restore
#line 10 "C:\Users\andre\desktop\projects\portfolio\csharp\travelapi.solution\travelapi\Views\Home\Index.cshtml"
   if (User.Identity.IsAuthenticated)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"link\">\r\n      ");
#nullable restore
#line 13 "C:\Users\andre\desktop\projects\portfolio\csharp\travelapi.solution\travelapi\Views\Home\Index.cshtml"
 Write(Html.ActionLink("Log out", "Index", "Account"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 15 "C:\Users\andre\desktop\projects\portfolio\csharp\travelapi.solution\travelapi\Views\Home\Index.cshtml"
    }
  else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"link\">\r\n      ");
#nullable restore
#line 19 "C:\Users\andre\desktop\projects\portfolio\csharp\travelapi.solution\travelapi\Views\Home\Index.cshtml"
 Write(Html.ActionLink("Create an account", "Register", "Account"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"link\">\r\n      ");
#nullable restore
#line 22 "C:\Users\andre\desktop\projects\portfolio\csharp\travelapi.solution\travelapi\Views\Home\Index.cshtml"
 Write(Html.ActionLink("Log in", "Login", "Account"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 24 "C:\Users\andre\desktop\projects\portfolio\csharp\travelapi.solution\travelapi\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
