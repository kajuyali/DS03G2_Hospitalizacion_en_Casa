#pragma checksum "C:\Users\pc\Desktop\Hospitalizacion\HospiEnCasa.App\HospiEnCasa.App.FrontEnd\Pages\Pacientes\ConsultarPaciente.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "53f7d24bb6e4bc04ddb9dbd179122fded5054e94"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(HospiEnCasa.App.FrontEnd.Pages.Pacientes.Pages_Pacientes_ConsultarPaciente), @"mvc.1.0.razor-page", @"/Pages/Pacientes/ConsultarPaciente.cshtml")]
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
#line 1 "C:\Users\pc\Desktop\Hospitalizacion\HospiEnCasa.App\HospiEnCasa.App.FrontEnd\Pages\_ViewImports.cshtml"
using HospiEnCasa.App.FrontEnd;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53f7d24bb6e4bc04ddb9dbd179122fded5054e94", @"/Pages/Pacientes/ConsultarPaciente.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ec2ef1a6b80933c0953a4a826bd81b49cbeca92", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Pacientes_ConsultarPaciente : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\pc\Desktop\Hospitalizacion\HospiEnCasa.App\HospiEnCasa.App.FrontEnd\Pages\Pacientes\ConsultarPaciente.cshtml"
  
    ViewData["Title"] = "Consultar Paciente";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

        <div class=""card p-2 m-5 w-50"">
          <div class=""card-body"">
            <div class=""input-group mb-3"">
              <input type=""text"" class=""form-control"" placeholder=""Escribe una cedula a consultar"" aria-label=""Recipient's username"" aria-describedby=""button-addon2"">
              <div class=""input-group-append"">
                <button class=""btn btn-outline-secondary"" type=""button"" id=""button-addon2"" data-toggle=""modal"" data-target=""#exampleModalScrollable"">Buscar</button>
              </div>
            </div>
          </div>
        </div>
        
        <div class=""modal fade"" id=""exampleModalScrollable"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalScrollableTitle"" aria-hidden=""true"">
          <div class=""modal-dialog modal-dialog-scrollable"" role=""document"">
            <div class=""modal-content"">
              <div class=""modal-header"">
                <h5 class=""modal-title text-center"" id=""exampleModalScrollableTitle"">HospiEnCasa</h5>
             ");
            WriteLiteral(@"   <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                  <span aria-hidden=""true"">&times;</span>
                </button>
              </div>
              <div class=""modal-body"">
                <div class=""card"">
                  <div class=""card-body"">
                    <h5 class=""card-title"">Datos del paciente</h5>
                    <p class=""card-text"">
                        <div");
            BeginWriteAttribute("class", " class=\"", 1599, "\"", 1607, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                          <p>Nombre: Francisco</p>
                          <p>Apellido: Perez</p>
                          <p>Documento: 1234567</p>
                          <p>Fecha de nacimiento: 21/10/1998</p>
                          <p>Genero: Masculino</p>
                          <p>Direccion: CR 16 Calle 55-12 C</p>
                          <p>Telefono:32154687</p>
                          <p>Familiar Asignado: Pastor Lopez</p>
                          <p>Correo: correo@correo.com</p>
                        </div>
                    </p>
                  </div>
                </div>
              </div>
              <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
              </div>
            </div>
          </div>
        </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HospiEnCasa.App.FrontEnd.Pages.Pacientes.ConsultarPaciente> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<HospiEnCasa.App.FrontEnd.Pages.Pacientes.ConsultarPaciente> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<HospiEnCasa.App.FrontEnd.Pages.Pacientes.ConsultarPaciente>)PageContext?.ViewData;
        public HospiEnCasa.App.FrontEnd.Pages.Pacientes.ConsultarPaciente Model => ViewData.Model;
    }
}
#pragma warning restore 1591
