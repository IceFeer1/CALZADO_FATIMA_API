using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Models;      // Para usar la clase Recibe
using WinFormsApp1.Services;    // Para usar RecibeService

namespace WinFormsApp1
{
    public partial class FrmRecibe : Form
    {
        // 1. INSTANCIACIÓN Y VARIABLES DE ESTADO
        // -------------------------------------
        RecibeService _service = new RecibeService();
        // Clave compuesta: almacenamos ambos IDs de la fila seleccionada
        int _idProductoSeleccionado = 0;
        int _idProveedorSeleccionado = 0;

        public FrmRecibe()
        {
            InitializeComponent();

            // Inicialización de botones
            buttonActualizar.Enabled = false;
            buttonEliminar.Enabled = false;

            // Conectar la carga de datos y la selección de celdas
            this.Load += new EventHandler(FrmRecibe_Load);
            // Asumimos que el DataGridView se llama dataGridView1
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
        }

        // ----------------------------------------------------------------------
        // 2. CARGA INICIAL Y MÉTODOS DE RECARGA
        // ----------------------------------------------------------------------

        private async void FrmRecibe_Load(object sender, EventArgs e)
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
                !DateTime.TryParse(textBoxFecha.Text, out DateTime fechaRecibo))
            {
                MessageBox.Show("Asegúrate de que ID Producto e ID Proveedor sean números válidos, y la Fecha sea válida.", "Validación");
                return;
            }

            var recibe = new Recibe
            {
                IdProducto = idProducto,
                IdProveedor = idProveedor,
                FechaRecibo = fechaRecibo
            };

            // Para el Guardar, la API debe validar si la clave compuesta ya existe.
            bool resultado = await _service.Guardar(recibe);

            if (resultado)
            {
                MessageBox.Show("Registro de Recibo guardado con éxito.");
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
                MessageBox.Show("No hay un registro de recibo seleccionado para actualizar.", "Error");
                return;
            }

            // Validaciones de entrada (Solo se puede cambiar la fecha al actualizar este registro)
            if (!DateTime.TryParse(textBoxFecha.Text, out DateTime fechaRecibo))
            {
                MessageBox.Show("La Fecha de Recibo debe ser válida.", "Validación");
                return;
            }

            // Los IDs de la clave compuesta se mantienen (se toman de las variables de estado)
            var recibe = new Recibe
            {
                IdProducto = _idProductoSeleccionado, // Se mantiene el ID original
                IdProveedor = _idProveedorSeleccionado, // Se mantiene el ID original
                FechaRecibo = fechaRecibo // Se actualiza solo la fecha
            };

            bool resultado = await _service.Actualizar(recibe);

            if (resultado)
            {
                MessageBox.Show("Registro de Recibo actualizado con éxito.");
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
                MessageBox.Show("Selecciona un registro de recibo para eliminar.", "Error");
                return;
            }

            var confirmacion = MessageBox.Show("¿Estás seguro de que quieres eliminar este registro de recibo?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                // Para eliminar un registro con clave compuesta, la API debe recibir
                // un objeto DTO/Modelo con las claves o un método que acepte ambas.
                var recibeParaEliminar = new Recibe
                {
                    IdProducto = _idProductoSeleccionado,
                    IdProveedor = _idProveedorSeleccionado
                };

                // Asumimos que la API/Servicio es capaz de manejar un objeto con la PK para la eliminación
                bool resultado = await _service.Eliminar(_idProductoSeleccionado, _idProveedorSeleccionado);

                if (resultado)
                {
                    MessageBox.Show("Registro de Recibo eliminado con éxito.");
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

                // 1. Capturar la clave compuesta
                _idProductoSeleccionado = Convert.ToInt32(row.Cells["IdProducto"].Value);
                _idProveedorSeleccionado = Convert.ToInt32(row.Cells["IdProveedor"].Value);

                // 2. Cargar datos en los TextBoxes
                textBoxProducto.Text = _idProductoSeleccionado.ToString();
                textBoxProveedor.Text = _idProveedorSeleccionado.ToString();

                // 3. Formatear la fecha
                if (row.Cells["FechaRecibo"].Value != null && row.Cells["FechaRecibo"].Value is DateTime fecha)
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