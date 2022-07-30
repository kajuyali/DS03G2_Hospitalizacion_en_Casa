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
        MedicosPer ObtenerMedico(int id);
        Medico Crear(Medico medico);
        MedicosPer Actualizar(MedicosPer medico);
        void Eliminar(int id);
        int Contar();
        IEnumerable<PacientesPer> ObtenerPacientesAsignados(int IdMedico);
        MedicosPer ObtenerMedicoById(int IdPersona);
    }
}