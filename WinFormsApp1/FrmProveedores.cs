using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Models;      // Para usar la clase Proveedor
using WinFormsApp1.Services;    // Para usar ProveedorService

namespace WinFormsApp1
{
    public partial class FrmProveedores : Form
    {
        // 1. INSTANCIACIÓN Y VARIABLES DE ESTADO
        // -------------------------------------
        ProveedorService _service = new ProveedorService();
        int _idSeleccionado = 0; // Almacena el ID del Proveedor seleccionado

        public FrmProveedores()
        {
            InitializeComponent();

            // Inicialización de botones
            buttonActualizar.Enabled = false;
            buttonEliminar.Enabled = false;

            // Conectar la carga de datos y la selección de celdas
            this.Load += new EventHandler(FrmProveedores_Load);
            // Asumimos que el DataGridView se llama dataGridView1
            // ¡Asegúrate de agregar un DataGridView llamado 'dataGridView1' al formulario!
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
        }

        // ----------------------------------------------------------------------
        // 2. CARGA INICIAL Y MÉTODOS DE RECARGA
        // ----------------------------------------------------------------------

        private async void FrmProveedores_Load(object sender, EventArgs e)
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
            // Limpia los TextBoxes
            textBoxNombre.Text = "";
            textBoxTelefono.Text = "";

            _idSeleccionado = 0;

            // Habilita/Deshabilita botones según el estado
            buttonGuardar.Enabled = true;
            buttonActualizar.Enabled = false;
            buttonEliminar.Enabled = false;
        }

        // ----------------------------------------------------------------------
        // 3. EVENTOS DE BOTONES CRUD
        // ----------------------------------------------------------------------

        private async void buttonGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones de entrada
            string nombre = textBoxNombre.Text.Trim();
            string telefono = textBoxTelefono.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(telefono))
            {
                MessageBox.Show("El Nombre y el Teléfono no pueden estar vacíos.", "Validación");
                return;
            }

            var proveedor = new Proveedor
            {
                NombreProveedor = nombre,
                TelefonoProveedor = telefono
                // IdProveedor (PK) es generado por la API/DB
            };

            bool resultado = await _service.Guardar(proveedor);

            if (resultado)
            {
                MessageBox.Show("Proveedor guardado con éxito.");
                Limpiar();
                await CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al guardar. Revisa la API y la conexión.", "Error");
            }
        }

        private async void buttonActualizar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == 0)
            {
                MessageBox.Show("No hay un proveedor seleccionado para actualizar.", "Error");
                return;
            }

            // Validaciones de entrada
            string nombre = textBoxNombre.Text.Trim();
            string telefono = textBoxTelefono.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(telefono))
            {
                MessageBox.Show("El Nombre y el Teléfono no pueden estar vacíos.", "Validación");
                return;
            }

            var proveedor = new Proveedor
            {
                IdProveedor = _idSeleccionado, // CLAVE: Enviamos el ID para actualizar
                NombreProveedor = nombre,
                TelefonoProveedor = telefono
            };

            bool resultado = await _service.Actualizar(proveedor);

            if (resultado)
            {
                MessageBox.Show("Proveedor actualizado con éxito.");
                Limpiar();
                await CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al actualizar. Verifica que el ID exista en la API.", "Error");
            }
        }

        private async void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un proveedor para eliminar.", "Error");
                return;
            }

            var confirmacion = MessageBox.Show("¿Estás seguro de que quieres eliminar este proveedor? Esto afectará Mantenimientos y Recibos.", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                // Asumimos que el método Eliminar en el servicio toma el ID (int)
                bool resultado = await _service.Eliminar(_idSeleccionado);

                if (resultado)
                {
                    MessageBox.Show("Proveedor eliminado con éxito.");
                    Limpiar();
                    await CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar. La API no pudo procesar la solicitud.", "Error");
                }
            }
        }

        // ----------------------------------------------------------------------
        // 4. EVENTO DE SELECCIÓN DE FILA (CellClick)
        // ----------------------------------------------------------------------

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Limpiar();

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Asignar el ID y los valores a los TextBoxes
                _idSeleccionado = Convert.ToInt32(row.Cells["IdProveedor"].Value);

                // Cargar propiedades
                textBoxNombre.Text = row.Cells["Nombre"].Value?.ToString();
                textBoxTelefono.Text = row.Cells["Telefono"].Value?.ToString();

                // Cambiar el estado de los botones
                buttonGuardar.Enabled = false;
                buttonActualizar.Enabled = true;
                buttonEliminar.Enabled = true;
            }
        }

        // ----------------------------------------------------------------------
        // 5. MÉTODOS VACÍOS (Métodos de la plantilla inicial)
        // ----------------------------------------------------------------------
        private void textBoxNombre_TextChanged(object sender, EventArgs e) { }
        private void textBoxTelefono_TextChanged(object sender, EventArgs e) { }
    }
}