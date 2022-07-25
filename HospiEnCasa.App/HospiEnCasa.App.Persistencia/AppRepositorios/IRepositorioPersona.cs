using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Persistencia.Models;

namespace HospiEnCasa.App.Persistencia.AppRepositorios
{
    public interface IRepositorioPersona
    {
        IEnumerable<Persona> ObtenerTodos();
        Persona Crear(Persona persona);
        void ActualizarFamiliar(FamiliaresPer familiar);
        void ActualizarPaciente(PacientesPer paciente);
        void Eliminar(int id);
        Persona ObtenerPorId(int id);
    }
}
