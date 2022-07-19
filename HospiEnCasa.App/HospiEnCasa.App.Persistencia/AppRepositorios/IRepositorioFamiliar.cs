using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Persistencia.Models;

namespace HospiEnCasa.App.Persistencia.AppRepositorios
{
    public interface IRepositorioFamiliar
    {
//        Familiar ObtenerFamiliar(int id); // Traer familiar desde Documento (=id)
        Familiar Crear(Familiar familiar);
//        Familiar Actualizar(Familiar familiar);
//        void Eliminar(int id);
        
    }
}
