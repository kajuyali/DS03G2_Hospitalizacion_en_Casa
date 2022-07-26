using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Persistencia.Models;

namespace HospiEnCasa.App.Persistencia.AppRepositorios
{
    public interface IRepositorioFamiliar
    {
        Familiar Crear(Familiar familiar);
        FamiliaresPer ObtenerFamiliar(int IdPaciente);
        FamiliaresPer Actualizar(FamiliaresPer familiar);
        void Eliminar(int id);   
    }
}
