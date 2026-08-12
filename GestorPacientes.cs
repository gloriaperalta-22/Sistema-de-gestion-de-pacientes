using System;
using System.Collections.Generic;
using System.Linq;
using SistemaGestionPacientes.Modelos;

namespace SistemaGestionPacientes.Logica
{
    
    // EXCEPCIÓN PERSONALIZADA
    public class PacienteNoEncontradoException : Exception
    {
        public PacienteNoEncontradoException(string mensaje) : base(mensaje) { }
    }

    // CLASE PRINCIPAL
    public class GestorPacientes
    {
        private readonly List<Paciente> _listaPacientes;

        public GestorPacientes()
        {
            _listaPacientes = new List<Paciente>();
        }

        // OPERACIÓN: ALTA
        public void RegistrarPaciente(Paciente nuevoPaciente)
        {
            if (nuevoPaciente == null)
                throw new ArgumentNullException(nameof(nuevoPaciente), "El objeto paciente recibido es nulo.");

            if (_listaPacientes.Any(p => p.ID == nuevoPaciente.ID))
                throw new InvalidOperationException($"No se puede registrar: El ID {nuevoPaciente.ID} ya existe en el sistema.");

            _listaPacientes.Add(nuevoPaciente);
        }

        // OPERACIÓN: CONSULTA (Lectura general)
        public List<Paciente> ObtenerTodos()
        {

            return new List<Paciente>(_listaPacientes);
        }

        // OPERACIÓN: CONSULTA (Lectura específica)

        public Paciente ConsultarPorId(string id)
        {
            var paciente = _listaPacientes.FirstOrDefault(p => p.ID == id);
            
            if (paciente == null)
                throw new PacienteNoEncontradoException($"Error de búsqueda: No se encontró ningún paciente asociado al ID '{id}'.");

            return paciente;
        }

        // OPERACIÓN: MODIFICACIÓN
        public void ModificarPaciente(string id, string nuevoNombre, int nuevaEdad, Sexo nuevoSexo, Estado nuevoEstado)
        {
            var paciente = ConsultarPorId(id);

            paciente.Nombre = nuevoNombre;
            paciente.Edad = nuevaEdad;
            paciente.SexPaciente = nuevoSexo;
            paciente.EstadoPaciente = nuevoEstado;
        }

        // OPERACIÓN: BAJA
        public void EliminarPaciente(string id)
        {
            var paciente = ConsultarPorId(id);
            _listaPacientes.Remove(paciente);
        }
    }
}
