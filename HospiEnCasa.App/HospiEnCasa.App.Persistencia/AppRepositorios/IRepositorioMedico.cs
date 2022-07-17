using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Persistencia.Models;

namespace HospiEnCasa.App.Persistencia.AppRepositorios
{
    public interface IRepositorioMedico
    {
        IEnumerable<MedicosPer> ObtenerMedicos();
        Medico Crear(Medico medico);
        Medico Actualizar(Medico medico);
        void Eliminar(int id);

    }
}