using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Models;      // Para usar la clase Suministra
using WinFormsApp1.Services;    // Para usar SuministraService

namespace WinFormsApp1
{
    public partial class FrmSuministra : Form
    {
        // 1. INSTANCIACIÓN Y VARIABLES DE ESTADO
        // -------------------------------------
        SuministraService _service = new SuministraService();
        // Clave compuesta: almacenamos ambos IDs de la fila seleccionada
        int _idProductoSeleccionado = 0;
        int _idProveedorSeleccionado = 0;

        public FrmSuministra()
        {
            InitializeComponent();

            // Inicialización de botones
            buttonActualizar.Enabled = false;
            buttonEliminar.Enabled = false;

            // Conectar la carga de datos y la selección de celdas
            this.Load += new EventHandler(FrmSuministra_Load);
            // Asumimos que el DataGridView se llama dataGridView1
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
        }

        // ----------------------------------------------------------------------
        // 2. CARGA INICIAL Y MÉTODOS DE RECARGA
        // ----------------------------------------------------------------------

        private async void FrmSuministra_Load(object sender, EventArgs e)
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
            // Limpia los TextBoxes (usando los nombres definidos: textBoxProducto, textBoxProveedor, textBoxFecha)
            textBoxProducto.Text = "";
            textBoxProveedor.Text = "";
            textBoxFecha.Text = "";

            _idProductoSeleccionado = 0;
            _idProveedorSeleccionado = 0;

            // Habilita/Deshabilita botones según el estado
            buttonGuardar.Enabled = true;
            buttonActualizar.Enabled = false;
            buttonEliminar.Enabled = false;

            // Habilitar la edición de los campos PK al guardar
            textBoxProducto.ReadOnly = false;
            textBoxProveedor.ReadOnly = false;
        }

        // ----------------------------------------------------------------------
        // 3. EVENTOS DE BOTONES CRUD
        // ----------------------------------------------------------------------

        private async void buttonGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones de entrada
            if (!int.TryParse(textBoxProducto.Text, out int idProducto) ||
                !int.TryParse(textBoxProveedor.Text, out int idProveedor) ||
                !DateTime.TryParse(textBoxFecha.Text, out DateTime fechaSuministra)) // Asume columna 'Fecha' o 'FechaSuministra'
            {
                MessageBox.Show("Asegúrate de que ID Producto e ID Proveedor sean números válidos, y la Fecha sea válida.", "Validación");
                return;
            }

            var suministra = new Suministra
            {
                IdProducto = idProducto,
                IdProveedor = idProveedor,
                FechaSuministro = fechaSuministra
            };

            // Para el Guardar, la API debe validar si la clave compuesta ya existe.
            bool resultado = await _service.Guardar(suministra);

            if (resultado)
            {
                MessageBox.Show("Registro de Suministro guardado con éxito.");
                Limpiar();
                await CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al guardar. Puede que la combinación Producto-Proveedor ya exista o que las FKs no sean válidas.", "Error");
            }
        }

        private async void buttonActualizar_Click(object sender, EventArgs e)
        {
            if (_idProductoSeleccionado == 0 || _idProveedorSeleccionado == 0)
            {
                MessageBox.Show("No hay un registro de suministro seleccionado para actualizar.", "Error");
                return;
            }

            // Validaciones de entrada (Solo se puede cambiar la fecha al actualizar este registro)
            if (!DateTime.TryParse(textBoxFecha.Text, out DateTime fechaSuministra))
            {
                MessageBox.Show("La Fecha de Suministro debe ser válida.", "Validación");
                return;
            }

            // Los IDs de la clave compuesta se mantienen (se toman de las variables de estado)
            var suministra = new Suministra
            {
                IdProducto = _idProductoSeleccionado,
                IdProveedor = _idProveedorSeleccionado,
                FechaSuministro = fechaSuministra // Se actualiza solo la fecha
            };

            bool resultado = await _service.Actualizar(suministra);

            if (resultado)
            {
                MessageBox.Show("Registro de Suministro actualizado con éxito.");
                Limpiar();
                await CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al actualizar. Verifica que el registro exista en la API.", "Error");
            }
        }

        private async void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (_idProductoSeleccionado == 0 || _idProveedorSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un registro de suministro para eliminar.", "Error");
                return;
            }

            var confirmacion = MessageBox.Show("¿Estás seguro de que quieres eliminar este registro de suministro?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                // Enviamos los IDs por separado, asumiendo que el servicio espera: Eliminar(int idProducto, int idProveedor)
                bool resultado = await _service.Eliminar(_idProductoSeleccionado, _idProveedorSeleccionado);

                if (resultado)
                {
                    MessageBox.Show("Registro de Suministro eliminado con éxito.");
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
                Limpiar(); // Limpia el estado anterior

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // 1. Capturar la clave compuesta (asume los nombres de columna en el DataGridView)
                _idProductoSeleccionado = Convert.ToInt32(row.Cells["IdProducto"].Value);
                _idProveedorSeleccionado = Convert.ToInt32(row.Cells["IdProveedor"].Value);

                // 2. Cargar datos en los TextBoxes
                textBoxProducto.Text = _idProductoSeleccionado.ToString();
                textBoxProveedor.Text = _idProveedorSeleccionado.ToString();

                // 3. Formatear la fecha (asume columna 'FechaSuministra')
                if (row.Cells["FechaSuministra"].Value != null && row.Cells["FechaSuministra"].Value is DateTime fecha)
                {
                    textBoxFecha.Text = fecha.ToShortDateString();
                }

                // 4. Deshabilitar la edición de las claves primarias (solo se actualiza la fecha)
                textBoxProducto.ReadOnly = true;
                textBoxProveedor.ReadOnly = true;

                // 5. Cambiar el estado de los botones
                buttonGuardar.Enabled = false;
                buttonActualizar.Enabled = true;
                buttonEliminar.Enabled = true;
            }
        }

        // ----------------------------------------------------------------------
        // 5. MÉTODOS VACÍOS (Métodos de la plantilla inicial)
        // ----------------------------------------------------------------------
        private void textBoxProducto_TextChanged(object sender, EventArgs e) { }
        private void textBoxProveedor_TextChanged(object sender, EventArgs e) { }
        private void textBoxFecha_TextChanged(object sender, EventArgs e) { }
    }
}