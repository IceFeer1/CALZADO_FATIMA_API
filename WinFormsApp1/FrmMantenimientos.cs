using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Models;      // Para usar la clase Mantenimiento
using WinFormsApp1.Services;    // Para usar MantenimientoService

namespace WinFormsApp1
{
    public partial class FrmMantenimientos : Form
    {
        // 1. INSTANCIACIÓN Y VARIABLES DE ESTADO
        // -------------------------------------
        MantenimientoService _service = new MantenimientoService();
        int _idSeleccionado = 0;

        public FrmMantenimientos()
        {
            InitializeComponent();

            // Inicialización de botones
            buttonActualizar.Enabled = false;
            buttonEliminar.Enabled = false;

            // Conectar la carga de datos y la selección de celdas
            this.Load += new EventHandler(FrmMantenimientos_Load);
            // Asumimos que el DataGridView se llama dataGridView1
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
        }

        // ----------------------------------------------------------------------
        // 2. CARGA INICIAL Y MÉTODOS DE RECARGA
        // ----------------------------------------------------------------------

        private async void FrmMantenimientos_Load(object sender, EventArgs e)
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
            textBoxProducto.Text = "";
            textBoxProveedor.Text = "";
            textBoxFecha.Text = "";

            _idSeleccionado = 0;

            // Habilita/Deshabilita botones según el estado
            buttonGuardar.Enabled = true;
            buttonActualizar.Enabled = false;
            buttonEliminar.Enabled = false;
        }

        // ----------------------------------------------------------------------
        // 3. EVENTOS DE BOTONES CRUD (Marcados con 'async')
        // ----------------------------------------------------------------------

        private async void buttonGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones de entrada
            if (!int.TryParse(textBoxProducto.Text, out int idProducto) ||
                !int.TryParse(textBoxProveedor.Text, out int idProveedor) ||
                !DateTime.TryParse(textBoxFecha.Text, out DateTime fechaMantenimiento)) // Cambiado a fechaMantenimiento
            {
                MessageBox.Show("Asegúrate de que ID Producto e ID Proveedor sean números, y la Fecha sea válida.", "Validación");
                return;
            }

            var mantenimiento = new Mantenimiento
            {
                IdProducto = idProducto,
                IdProveedor = idProveedor,
                FechaMantenimiento = fechaMantenimiento // Propiedad correcta
            };

            bool resultado = await _service.Guardar(mantenimiento);

            if (resultado)
            {
                MessageBox.Show("Registro de Mantenimiento guardado con éxito.");
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
                MessageBox.Show("No hay un registro seleccionado para actualizar.", "Error");
                return;
            }

            // Validaciones de entrada
            if (!int.TryParse(textBoxProducto.Text, out int idProducto) ||
                !int.TryParse(textBoxProveedor.Text, out int idProveedor) ||
                !DateTime.TryParse(textBoxFecha.Text, out DateTime fechaMantenimiento)) // Cambiado a fechaMantenimiento
            {
                MessageBox.Show("Asegúrate de que ID Producto e ID Proveedor sean números, y la Fecha sea válida.", "Validación");
                return;
            }

            var mantenimiento = new Mantenimiento
            {
                IdMantenimiento = _idSeleccionado, // CLAVE: Enviamos el ID para actualizar
                IdProducto = idProducto,
                IdProveedor = idProveedor,
                FechaMantenimiento = fechaMantenimiento // Propiedad correcta
            };

            bool resultado = await _service.Actualizar(mantenimiento);

            if (resultado)
            {
                MessageBox.Show("Registro de Mantenimiento actualizado con éxito.");
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
                MessageBox.Show("Selecciona un registro de mantenimiento para eliminar.", "Error");
                return;
            }

            var confirmacion = MessageBox.Show("¿Estás seguro de que quieres eliminar este registro?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                // Asumimos que el método Eliminar en el servicio toma el ID (int)
                bool resultado = await _service.Eliminar(_idSeleccionado);

                if (resultado)
                {
                    MessageBox.Show("Registro de Mantenimiento eliminado con éxito.");
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
                _idSeleccionado = Convert.ToInt32(row.Cells["IdMantenimiento"].Value);
                textBoxProducto.Text = row.Cells["IdProducto"].Value?.ToString();
                textBoxProveedor.Text = row.Cells["IdProveedor"].Value?.ToString();

                // CORRECCIÓN: Usar el nombre de columna correcto: "FechaMantenimiento"
                if (row.Cells["FechaMantenimiento"].Value != null && row.Cells["FechaMantenimiento"].Value is DateTime fecha)
                {
                    textBoxFecha.Text = fecha.ToShortDateString();
                }
                else
                {
                    textBoxFecha.Text = string.Empty;
                }

                // Cambiar el estado de los botones
                buttonGuardar.Enabled = false;
                buttonActualizar.Enabled = true;
                buttonEliminar.Enabled = true;
            }
        }

        // ----------------------------------------------------------------------
        // 5. MÉTODOS VACÍOS (De la plantilla inicial)
        // ----------------------------------------------------------------------
        private void textBoxProducto_TextChanged(object sender, EventArgs e) { }
        private void textBoxProveedor_TextChanged(object sender, EventArgs e) { }
        private void textBoxFecha_TextChanged(object sender, EventArgs e) { }
    }
}