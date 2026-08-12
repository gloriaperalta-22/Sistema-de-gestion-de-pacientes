using SistemaGestionPacientes.Logica;
using SistemaGestionPacientes.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGestionPacientes
{
    public partial class Form1 : Form
    {
        private GestorPacientes gestor = new GestorPacientes();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            combo_Sexo.DataSource = Enum.GetValues(typeof(Sexo));

            
            combo_Estado.DataSource = Enum.GetValues(typeof(Estado));

           
            combo_Sexo.SelectedIndex = -1;
            combo_Estado.SelectedIndex = -1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txt_cedula.Clear();
            txt_Nombre.Clear();
            txt_Edad.Clear();
            txt_Diasnotico.Clear();
            combo_Sexo.SelectedIndex = -1; 
            combo_Estado.SelectedIndex = -1;

            txt_cedula.Focus(); 
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // 1. Validar que no haya campos vacíos
            if (string.IsNullOrWhiteSpace(txt_cedula.Text) || string.IsNullOrWhiteSpace(txt_Nombre.Text))
            {
                MessageBox.Show("Por favor, llene al menos la Cédula y el Nombre.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            Paciente nuevoPaciente = new Paciente();

            nuevoPaciente.ID = txt_cedula.Text;         
            nuevoPaciente.Nombre = txt_Nombre.Text;
            nuevoPaciente.Edad = int.Parse(txt_Edad.Text);
            nuevoPaciente.Diagnostico = txt_Diasnotico.Text;
            nuevoPaciente.FechaIngreso = dtp_FechaIngreso.Value;


            nuevoPaciente.SexPaciente = (Sexo)Enum.Parse(typeof(Sexo), combo_Sexo.SelectedItem.ToString());
            nuevoPaciente.EstadoPaciente = (Estado)Enum.Parse(typeof(Estado), combo_Estado.SelectedItem.ToString());

            // 3. Enviar el paciente al gestor (Backend)
            gestor.RegistrarPaciente(nuevoPaciente);

            // 4. Mostrar mensaje de éxito, limpiar casillas y actualizar tabla
            MessageBox.Show("Paciente registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnLimpiar_Click(sender, e); 
            ActualizarTabla();
        }

        private void ActualizarTabla()
        {
           
            data_Lista.DataSource = null;
            data_Lista.DataSource = gestor.ObtenerTodos(); 
        }

        private void data_Lista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0)
            {
                // Tomamos toda la fila a la que se le hizo clic
                DataGridViewRow fila = data_Lista.Rows[e.RowIndex];

                // Devolvemos los datos a las cajas de texto usando los nombres de las columnas
                txt_cedula.Text = fila.Cells["ID"].Value.ToString();
                txt_Nombre.Text = fila.Cells["Nombre"].Value.ToString();
                txt_Edad.Text = fila.Cells["Edad"].Value.ToString();

                // El '?' previene que el programa explote si por alguna razón el diagnóstico se guardó vacío
                txt_Diasnotico.Text = fila.Cells["Diagnostico"].Value?.ToString();

                // Para los ComboBox, la propiedad Text es la forma más segura de re-seleccionar la opción
                combo_Sexo.Text = fila.Cells["SexPaciente"].Value.ToString();
                combo_Estado.Text = fila.Cells["EstadoPaciente"].Value.ToString();
                dtp_FechaIngreso.Value = Convert.ToDateTime(fila.Cells["FechaIngreso"].Value);
            }
        }

        private void btnActulizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_cedula.Text))
                {
                    MessageBox.Show("Por favor, selecciona un paciente de la tabla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string id = txt_cedula.Text;
                string nombre = txt_Nombre.Text;
                int edad = int.Parse(txt_Edad.Text);
                Sexo sexo = (Sexo)Enum.Parse(typeof(Sexo), combo_Sexo.SelectedItem.ToString());
                Estado estado = (Estado)Enum.Parse(typeof(Estado), combo_Estado.SelectedItem.ToString());

                // Llamada al método exacto del backend
                gestor.ModificarPaciente(id, nombre, edad, sexo, estado, dtp_FechaIngreso.Value );

                MessageBox.Show("Paciente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarTabla();
                btnLimpiar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_cedula.Text))
                {
                    MessageBox.Show("Por favor, selecciona un paciente para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmacion = MessageBox.Show("¿Estás seguro de eliminar a este paciente?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    // Llamada al método exacto del backend
                    gestor.EliminarPaciente(txt_cedula.Text);

                    MessageBox.Show("Paciente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarTabla();
                    btnLimpiar_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string idBuscado = txt_Buscar.Text;

                if (string.IsNullOrWhiteSpace(idBuscado))
                {
                    ActualizarTabla();
                    return;
                }

                // Como ConsultarPorId devuelve un solo objeto, lo envolvemos en una lista para mostrarlo en la tabla
                Paciente encontrado = gestor.ConsultarPorId(idBuscado);
                data_Lista.DataSource = null;
                data_Lista.DataSource = new List<Paciente> { encontrado };
            }
            catch (Exception)
            {
                MessageBox.Show("No se encontró ningún paciente con ese ID.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarTabla();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}