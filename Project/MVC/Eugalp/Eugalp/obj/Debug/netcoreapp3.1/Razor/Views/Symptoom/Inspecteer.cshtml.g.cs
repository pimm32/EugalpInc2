#pragma checksum "C:\Users\pim-a\source\EugalpInc\Project\MVC\Eugalp\Eugalp\Views\Symptoom\Inspecteer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11f94e2d4bd75308526f1ed216ad658890b5d088"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Symptoom_Inspecteer), @"mvc.1.0.view", @"/Views/Symptoom/Inspecteer.cshtml")]
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
#line 1 "C:\Users\pim-a\source\EugalpInc\Project\MVC\Eugalp\Eugalp\Views\_ViewImports.cshtml"
using Eugalp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\pim-a\source\EugalpInc\Project\MVC\Eugalp\Eugalp\Views\_ViewImports.cshtml"
using Eugalp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11f94e2d4bd75308526f1ed216ad658890b5d088", @"/Views/Symptoom/Inspecteer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2664604b76cbc80d2f1f8ea9a3d2ca4369d0a522", @"/Views/_ViewImports.cshtml")]
    public class Views_Symptoom_Inspecteer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Eugalp.Models.ViewModels.SymptoomViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h3>Symptoom Toevoegen</h3>\r\n\r\n    <h4>Symptoom</h4>\r\n    <hr/>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 8 "C:\Users\pim-a\source\EugalpInc\Project\MVC\Eugalp\Eugalp\Views\Symptoom\Inspecteer.cshtml"
       Write(Html.DisplayFor(x => Model.naam));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dt class=\"col-sm-1\">\r\n            ");
#nullable restore
#line 11 "C:\Users\pim-a\source\EugalpInc\Project\MVC\Eugalp\Eugalp\Views\Symptoom\Inspecteer.cshtml"
       Write(Html.DisplayFor(x=> Model.besmettingsgraadFactor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dt class=\"col-sm-1\">\r\n            ");
#nullable restore
#line 14 "C:\Users\pim-a\source\EugalpInc\Project\MVC\Eugalp\Eugalp\Views\Symptoom\Inspecteer.cshtml"
       Write(Html.DisplayFor(x => Model.herkenbaarheidsgraadFactor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dt class=\"col-sm-1\">\r\n            ");
#nullable restore
#line 17 "C:\Users\pim-a\source\EugalpInc\Project\MVC\Eugalp\Eugalp\Views\Symptoom\Inspecteer.cshtml"
       Write(Html.DisplayFor(x => Model.sterftegraadFactor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dt class=\"col-sm-1\">\r\n            ");
#nullable restore
#line 20 "C:\Users\pim-a\source\EugalpInc\Project\MVC\Eugalp\Eugalp\Views\Symptoom\Inspecteer.cshtml"
       Write(Html.DisplayFor(x => Model.ernst));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dt class=\"col-sm-1\">\r\n            ");
#nullable restore
#line 23 "C:\Users\pim-a\source\EugalpInc\Project\MVC\Eugalp\Eugalp\Views\Symptoom\Inspecteer.cshtml"
       Write(Html.DisplayFor(x => Model.prijs));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dt class=\"col-sm-1\">\r\n            ");
#nullable restore
#line 26 "C:\Users\pim-a\source\EugalpInc\Project\MVC\Eugalp\Eugalp\Views\Symptoom\Inspecteer.cshtml"
       Write(Html.DisplayFor(x => Model.categorie));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dt class=\"col-sm-1\">\r\n            ");
#nullable restore
#line 29 "C:\Users\pim-a\source\EugalpInc\Project\MVC\Eugalp\Eugalp\Views\Symptoom\Inspecteer.cshtml"
       Write(Html.DisplayFor(x => Model.niveau));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Eugalp.Models.ViewModels.SymptoomViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591