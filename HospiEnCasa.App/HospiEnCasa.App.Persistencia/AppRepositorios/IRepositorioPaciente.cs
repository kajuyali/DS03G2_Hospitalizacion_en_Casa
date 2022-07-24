using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Persistencia.Models;

namespace HospiEnCasa.App.Persistencia.AppRepositorios
{
    public interface IRepositorioPaciente
    {
        Paciente Crear(Paciente paciente);
        IEnumerable<PacientesPer> ObtenerPacientes();
        PacientesPer ObtenerPaciente(int IdPaciente);
        int Contar();
        MedicosPer ObtenerMedicoAsignado(int IdPaciente);
        PacientesPer Actualizar(PacientesPer paciente);
    }
}


