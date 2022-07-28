using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Persistencia.Models;

namespace HospiEnCasa.App.Persistencia.AppRepositorios
{
    public interface IRepositorioSigno
    {
        SignosPaciente CrearSignoPaciente(SignosPaciente signoPaciente);
        SignosVitale ObtenerSigno(int idSigno);
        ListaSignosPaciente ObtenerSignosPaciente(int idPaciente);
        IEnumerable<SignosList> ObtenerHistorialSignosPaciente(int IdPaciente);
    }
}