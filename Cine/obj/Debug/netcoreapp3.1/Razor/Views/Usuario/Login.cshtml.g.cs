#pragma checksum "C:\Users\gerol\source\repos\PracticaAsp.Net\Cine\Views\Usuario\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd408877e8ca53babeac006952f4870affc110f7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_Login), @"mvc.1.0.view", @"/Views/Usuario/Login.cshtml")]
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
#line 1 "C:\Users\gerol\source\repos\PracticaAsp.Net\Cine\Views\_ViewImports.cshtml"
using Cine;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\gerol\source\repos\PracticaAsp.Net\Cine\Views\_ViewImports.cshtml"
using Cine.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd408877e8ca53babeac006952f4870affc110f7", @"/Views/Usuario/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3910a2e986b83a933ad7446afaf00ef46549eaf4", @"/Views/_ViewImports.cshtml")]
    
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\gerol\source\repos\PracticaAsp.Net\Cine\Views\Usuario\Login.cshtml"
  
    Layout = "_LayoutEnBlanco";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bd408877e8ca53babeac006952f4870affc110f74380", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n    $(\'#myModal\').on(\'shown.bs.modal\', function () {\r\n    $(\'#myInput\').trigger(\'focus\')\r\n})\r\n</script>\r\n \r\n\r\n");
#nullable restore
#line 15 "C:\Users\gerol\source\repos\PracticaAsp.Net\Cine\Views\Usuario\Login.cshtml"
 using (Html.BeginForm("Login", "Usuario"))
{


#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""myModal fade animated rollIn"" tabindex=""-1"" role=""dialog"">
            <div class=""modal-dialog modal-dialog-centered"" role=""document"">
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <h5 class=""modal-title"">Login</h5>
                    </div>
                    ");
#nullable restore
#line 24 "C:\Users\gerol\source\repos\PracticaAsp.Net\Cine\Views\Usuario\Login.cshtml"
               Write(Html.ValidationSummary(true, "", new { @class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"modal-body\">\r\n                    \r\n                    ");
#nullable restore
#line 27 "C:\Users\gerol\source\repos\PracticaAsp.Net\Cine\Views\Usuario\Login.cshtml"
               Write(Html.TextBoxFor(x => x.NombreUsuario, new { @class = "form-control", @placeholder = "Usuario", @label = "Usuario", @describedby = "basic-addon1" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 28 "C:\Users\gerol\source\repos\PracticaAsp.Net\Cine\Views\Usuario\Login.cshtml"
               Write(Html.ValidationMessageFor(x => x.NombreUsuario, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <br />\r\n                    <br /> \r\n                    ");
#nullable restore
#line 31 "C:\Users\gerol\source\repos\PracticaAsp.Net\Cine\Views\Usuario\Login.cshtml"
               Write(Html.PasswordFor(x => x.Password, new { @class = "form-control", @placeholder = "Password", @label = "Password", @describedby = "basic-addon1" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 32 "C:\Users\gerol\source\repos\PracticaAsp.Net\Cine\Views\Usuario\Login.cshtml"
               Write(Html.ValidationMessageFor(x => x.Password, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
                    <div class=""modal-footer"">
                        <button type=""submit"" class=""btn btn-primary"" onclick=""alertando()"">Ingresar</button>
                        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"" name=""btnCrear""");
            BeginWriteAttribute("onclick", " onclick=\"", 1730, "\"", 1789, 5);
            WriteAttributeValue("", 1740, "location.href", 1740, 13, true);
            WriteAttributeValue(" ", 1753, "=", 1754, 2, true);
            WriteAttributeValue(" ", 1755, "\'", 1756, 2, true);
#nullable restore
#line 36 "C:\Users\gerol\source\repos\PracticaAsp.Net\Cine\Views\Usuario\Login.cshtml"
WriteAttributeValue("", 1757, Url.Action("Crear", "Usuario"), 1757, 31, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1788, "\'", 1788, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Crear Cuenta</button>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 41 "C:\Users\gerol\source\repos\PracticaAsp.Net\Cine\Views\Usuario\Login.cshtml"
    
}

#line default
#line hidden
#nullable disable
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
        
 
    }

#pragma warning restore 1591
