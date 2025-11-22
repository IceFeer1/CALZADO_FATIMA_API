using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Models;      // Necesario para usar la clase Cliente
using WinFormsApp1.Services;    // Necesario para usar ClienteService

namespace WinFormsApp1
{
    public partial class FrmClientes : Form
    {

        // Instanciamos el servicio y definimos variables de estado al inicio de la clase.
        ClienteService _service = new ClienteService();
        int _idSeleccionado = 0; // Almacena el ID del cliente seleccionado para Update/Delete

        public FrmClientes()
        {
            InitializeComponent();

            // Inicialización de botones
            buttonActualizar.Enabled = false;
            buttonEliminar.Enabled = false;

            // 1. CONEXIÓN DEL CARGADOR DE DATOS AL EVENTO LOAD
            this.Load += new EventHandler(FrmClientes_Load);

            // 2. CORRECCIÓN: CONEXIÓN DEL EVENTO CellClick al método que carga los datos
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
        }

        private async void FrmClientes_Load(object sender, EventArgs e)
        {
            // Configuración visual del DataGridView
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;

            await CargarDatos();
        }

        private async Task CargarDatos()
        {
            try
            {
                var lista = await _service.ObtenerTodos();
                dataGridView1.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}. Asegúrate que la API esté corriendo.", "Error de Conexión");
            }
        }

        private void Limpiar()
        {
            // Limpia todos los TextBoxes
            textBoxNombre.Text = "";
            textBoxApellido.Text = "";
            textBoxDireccion.Text = "";
            textBoxTelefono.Text = "";

            _idSeleccionado = 0;
            buttonGuardar.Enabled = true;
            buttonActualizar.Enabled = false;
            buttonEliminar.Enabled = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            // Método vacío
        }

        // CORRECCIÓN: Se agregó el modificador 'async'
        private async void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación");
                return;
            }

            var cliente = new Cliente
            {
                NombreCliente = textBoxNombre.Text,
                ApellidoCliente = textBoxApellido.Text,
                DireccionCliente = textBoxDireccion.Text,
                TelefonoCliente = textBoxTelefono.Text
            };

            bool resultado = await _service.Guardar(cliente); // 'await' ahora es válido

            if (resultado)
            {
                MessageBox.Show("Cliente guardado con éxito.");
                Limpiar();
                await CargarDatos(); // 'await' ahora es válido
            }
            else
            {
                MessageBox.Show("Error al guardar. Revisa la API y la conexión.", "Error");
            }
        }

        // CORRECCIÓN: Se agregó el modificador 'async'
        private async void buttonActualizar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == 0)
            {
                MessageBox.Show("No hay un cliente seleccionado para actualizar.", "Error");
                return;
            }
            if (string.IsNullOrEmpty(textBoxNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación");
                return;
            }

            var cliente = new Cliente
            {
                IdCliente = _idSeleccionado, // CLAVE: Enviamos el ID para actualizar
                NombreCliente = textBoxNombre.Text,
                ApellidoCliente = textBoxApellido.Text,
                DireccionCliente = textBoxDireccion.Text,
                TelefonoCliente = textBoxTelefono.Text
            };

            bool resultado = await _service.Actualizar(cliente); // 'await' ahora es válido

            if (resultado)
            {
                MessageBox.Show("Cliente actualizado con éxito.");
                Limpiar();
                await CargarDatos(); // 'await' ahora es válido
            }
            else
            {
                MessageBox.Show("Error al actualizar. Verifica que el ID exista en la API.", "Error");
            }
        }

        // CORRECCIÓN: Se agregó el modificador 'async'
        private async void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un cliente para eliminar.", "Error");
                return;
            }

            var confirmacion = MessageBox.Show("¿Estás seguro de que quieres eliminar este cliente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                bool resultado = await _service.Eliminar(_idSeleccionado); // 'await' ahora es válido
                if (resultado)
                {
                    MessageBox.Show("Cliente eliminado con éxito.");
                    Limpiar();
                    await CargarDatos(); // 'await' ahora es válido
                }
                else
                {
                    MessageBox.Show("Error al eliminar. La API no pudo procesar la solicitud.", "Error");
                }
            }
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            // Método vacío
        }

        private void textBoxApellido_TextChanged(object sender, EventArgs e)
        {
            // Método vacío
        }

        private void textBoxDireccion_TextChanged(object sender, EventArgs e)
        {
            // Método vacío
        }

        private void textBoxTelefono_TextChanged(object sender, EventArgs e)
        {
            // Método vacío
        }

        // CORRECCIÓN: Se cambió a CellClick (el evento más confiable) y se mantuvo el nombre CellContentClick 
        // para la lógica de selección.
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Limpiar primero para resetear el estado de los botones
                Limpiar();

                // Obtener la fila seleccionada
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Asignar el ID y los valores a los TextBoxes
                _idSeleccionado = Convert.ToInt32(row.Cells["IdCliente"].Value);
                textBoxNombre.Text = row.Cells["NombreCliente"].Value.ToString();
                // Usamos '?' para manejar posibles valores DBNull o nulos sin que rompa el programa.
                textBoxApellido.Text = row.Cells["ApellidoCliente"].Value?.ToString();
                textBoxDireccion.Text = row.Cells["DireccionCliente"].Value?.ToString();
                textBoxTelefono.Text = row.Cells["TelefonoCliente"].Value?.ToString();

                // Cambiar el estado de los botones
                buttonGuardar.Enabled = false;
                buttonActualizar.Enabled = true;
                buttonEliminar.Enabled = true;
            }
        }

        // Mantener este método vacío, ya que la lógica se movió a CellClick.
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}