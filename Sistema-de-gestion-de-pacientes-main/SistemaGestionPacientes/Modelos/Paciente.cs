using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGestionPacientes.Modelos
{
    public class Paciente
    {
        public string ID { get; set; }  
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public Sexo SexPaciente { get; set; }
        public Estado EstadoPaciente { get; set; }


        public bool ValidarEdad(string textoEdad)
        {
            int edad;
            bool funciono = int.TryParse(textoEdad, out edad);

            if (funciono && edad > 0 && edad <= 120)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidarId (string idNuevo, List<Paciente> listaPacientes) 
        {
            foreach (Paciente paciente in listaPacientes)
            {
                if (paciente.ID == idNuevo)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidarNombre(string nombre)
        {
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
