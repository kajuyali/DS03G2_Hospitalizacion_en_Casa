#pragma checksum "C:\Users\javie\Documents\GitHub\DS03G2_Hospitalizacion_en_CasavF\HospiEnCasa.App\HospiEnCasa.App.FrontEnd\Pages\Pacientes\ListaPacientes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5503f2639d07186746aa1cba44aefd15a66c249"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(HospiEnCasa.App.FrontEnd.Pages.Pacientes.Pages_Pacientes_ListaPacientes), @"mvc.1.0.razor-page", @"/Pages/Pacientes/ListaPacientes.cshtml")]
namespace HospiEnCasa.App.FrontEnd.Pages.Pacientes
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
#line 1 "C:\Users\javie\Documents\GitHub\DS03G2_Hospitalizacion_en_CasavF\HospiEnCasa.App\HospiEnCasa.App.FrontEnd\Pages\_ViewImports.cshtml"
using HospiEnCasa.App.FrontEnd;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5503f2639d07186746aa1cba44aefd15a66c249", @"/Pages/Pacientes/ListaPacientes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ec2ef1a6b80933c0953a4a826bd81b49cbeca92", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Pacientes_ListaPacientes : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Pacientes/DetallePaciente", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("ml-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\javie\Documents\GitHub\DS03G2_Hospitalizacion_en_CasavF\HospiEnCasa.App\HospiEnCasa.App.FrontEnd\Pages\Pacientes\ListaPacientes.cshtml"
  
    ViewData["Title"] = "Lista de Pacientes";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""container bg-white w-auto p-3 m-5"">
        <table
          id=""table""
          class=""table table-striped table-bordered h-75""
          style=""width: 100%""
        >
          <thead>
            <tr>
              <th>Documento</th>
              <th>Nombres</th>
              <th>Apellidos</th>
              <th>Telefono</th>
              <th>Ciudad</th>
              <th>Genero</th>
              <th>Fecha de Nacimiento</th>
              <th>Acciones</th>
            </tr>
          </thead>
          <tbody>
");
#nullable restore
#line 25 "C:\Users\javie\Documents\GitHub\DS03G2_Hospitalizacion_en_CasavF\HospiEnCasa.App\HospiEnCasa.App.FrontEnd\Pages\Pacientes\ListaPacientes.cshtml"
             foreach (var paciente in Model.Pacientes)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("              <tr>\r\n                <td>");
#nullable restore
#line 28 "C:\Users\javie\Documents\GitHub\DS03G2_Hospitalizacion_en_CasavF\HospiEnCasa.App\HospiEnCasa.App.FrontEnd\Pages\Pacientes\ListaPacientes.cshtml"
               Write(paciente.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 29 "C:\Users\javie\Documents\GitHub\DS03G2_Hospitalizacion_en_CasavF\HospiEnCasa.App\HospiEnCasa.App.FrontEnd\Pages\Pacientes\ListaPacientes.cshtml"
               Write(paciente.Nombres);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 30 "C:\Users\javie\Documents\GitHub\DS03G2_Hospitalizacion_en_CasavF\HospiEnCasa.App\HospiEnCasa.App.FrontEnd\Pages\Pacientes\ListaPacientes.cshtml"
               Write(paciente.Apellidos);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 31 "C:\Users\javie\Documents\GitHub\DS03G2_Hospitalizacion_en_CasavF\HospiEnCasa.App\HospiEnCasa.App.FrontEnd\Pages\Pacientes\ListaPacientes.cshtml"
               Write(paciente.Telefono);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 32 "C:\Users\javie\Documents\GitHub\DS03G2_Hospitalizacion_en_CasavF\HospiEnCasa.App\HospiEnCasa.App.FrontEnd\Pages\Pacientes\ListaPacientes.cshtml"
               Write(paciente.Ciudad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td style=\"text-transform: capitalize;\">");
#nullable restore
#line 33 "C:\Users\javie\Documents\GitHub\DS03G2_Hospitalizacion_en_CasavF\HospiEnCasa.App\HospiEnCasa.App.FrontEnd\Pages\Pacientes\ListaPacientes.cshtml"
                                                   Write(paciente.Genero);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 34 "C:\Users\javie\Documents\GitHub\DS03G2_Hospitalizacion_en_CasavF\HospiEnCasa.App\HospiEnCasa.App.FrontEnd\Pages\Pacientes\ListaPacientes.cshtml"
               Write(paciente.FechaNacimiento);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"d-fle align-items-center\">\r\n                  ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5503f2639d07186746aa1cba44aefd15a66c2497408", async() => {
                WriteLiteral("<i class=\"fa fa-cog\" aria-hidden=\"true\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-IdPaciente", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 36 "C:\Users\javie\Documents\GitHub\DS03G2_Hospitalizacion_en_CasavF\HospiEnCasa.App\HospiEnCasa.App.FrontEnd\Pages\Pacientes\ListaPacientes.cshtml"
                                                                     WriteLiteral(paciente.IdPaciente);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["IdPaciente"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-IdPaciente", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["IdPaciente"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                  <a href=\"#\" class=\"ml-4\"><i class=\"fa fa-trash-o\" aria-hidden=\"true\"></i></a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 40 "C:\Users\javie\Documents\GitHub\DS03G2_Hospitalizacion_en_CasavF\HospiEnCasa.App\HospiEnCasa.App.FrontEnd\Pages\Pacientes\ListaPacientes.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("          </tbody>\r\n        </table>\r\n      </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HospiEnCasa.App.FrontEnd.Pages.Pacientes.ListaPacientes> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<HospiEnCasa.App.FrontEnd.Pages.Pacientes.ListaPacientes> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<HospiEnCasa.App.FrontEnd.Pages.Pacientes.ListaPacientes>)PageContext?.ViewData;
        public HospiEnCasa.App.FrontEnd.Pages.Pacientes.ListaPacientes Model => ViewData.Model;
    }
}
#pragma warning restore 1591
