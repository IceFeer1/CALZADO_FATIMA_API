using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Models;      // Para usar la clase DetalleVenta
using WinFormsApp1.Services;    // Para usar DetalleVentaService

namespace WinFormsApp1
{
    public partial class FrmDetalleVenta : Form
    {
        // 1. INSTANCIACIÓN Y VARIABLES DE ESTADO
        // -------------------------------------
        DetalleVentaService _service = new DetalleVentaService();

        // El ID de DetalleVenta es compuesto (IdVenta y IdProducto)
        int _idVentaSeleccionado = 0;
        int _idProductoSeleccionado = 0;

        public FrmDetalleVenta()
        {
            InitializeComponent();

            // Inicialización de la UI
            buttonActualizar.Enabled = false;
            buttonEliminar.Enabled = false;

            // Conectar el cargador de datos y el selector de celdas
            this.Load += new EventHandler(FrmDetalleVenta_Load);
            // El DataGridView debe llamarse dataGridView1
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
        }

        // ----------------------------------------------------------------------
        // 2. CARGA INICIAL Y MÉTODOS DE RECARGA
        // ----------------------------------------------------------------------

        private async void FrmDetalleVenta_Load(object sender, EventArgs e)
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
            // Usando tus nombres de TextBox:
            textBoxIdVenta.Text = "";
            textBoxIdProducto.Text = "";
            textBoxCantidad.Text = "";

            _idVentaSeleccionado = 0;
            _idProductoSeleccionado = 0;

            buttonGuardar.Enabled = true;
            buttonActualizar.Enabled = false;
            buttonEliminar.Enabled = false;
            textBoxIdVenta.ReadOnly = false;
            textBoxIdProducto.ReadOnly = false;
        }

        // ----------------------------------------------------------------------
        // 3. EVENTOS DE BOTONES CRUD
        // ----------------------------------------------------------------------

        private async void buttonGuardar_Click(object sender, EventArgs e)
        {
            // Validamos solo los campos presentes en la UI (ID Venta, ID Producto, Cantidad)
            if (!int.TryParse(textBoxIdVenta.Text, out int idVenta) ||
                !int.TryParse(textBoxIdProducto.Text, out int idProducto) ||
                !int.TryParse(textBoxCantidad.Text, out int cantidad))
            {
                MessageBox.Show("ID Venta, ID Producto y Cantidad deben ser números válidos.", "Validación");
                return;
            }

            // Asumiendo que el PrecioUnitario se asigna automáticamente o no es editable aquí
            var detalle = new DetalleVenta
            {
                IdVenta = idVenta,
                IdProducto = idProducto,
                Cantidad = cantidad,
                // Si PrecioUnitario es requerido, obtén su valor de alguna parte
                // PrecioUnitario = 0m // Placeholder si la propiedad existe pero no hay TextBox
            };

            bool resultado = await _service.Guardar(detalle);

            if (resultado)
            {
                MessageBox.Show("Detalle de Venta guardado con éxito.");
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
            if (_idVentaSeleccionado == 0 || _idProductoSeleccionado == 0)
            {
                MessageBox.Show("No hay un detalle de venta seleccionado para actualizar.", "Error");
                return;
            }
            if (!int.TryParse(textBoxCantidad.Text, out int cantidad))
            {
                MessageBox.Show("La Cantidad debe ser un número válido.", "Validación");
                return;
            }

            var detalle = new DetalleVenta
            {
                IdVenta = _idVentaSeleccionado,
                IdProducto = _idProductoSeleccionado,
                Cantidad = cantidad,
                // Si PrecioUnitario es requerido, se debe mantener el valor original o usar un DTO
            };

            bool resultado = await _service.Actualizar(detalle);

            if (resultado)
            {
                MessageBox.Show("Detalle de Venta actualizado con éxito.");
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
            if (_idVentaSeleccionado == 0 || _idProductoSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un registro de detalle de venta para eliminar.", "Error");
                return;
            }

            var confirmacion = MessageBox.Show("¿Estás seguro de que quieres eliminar este detalle de venta?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                // Corrección del CS1501: Enviamos el objeto DTO/Modelo con las claves compuestas
                // ADVERTENCIA: Esto puede eliminar TODOS los detalles de esa Venta.
                var detalleParaEliminar = new DetalleVenta
                {
                    IdVenta = _idVentaSeleccionado,
                    IdProducto = _idProductoSeleccionado
                };

                bool resultado = await _service.Eliminar(_idVentaSeleccionado);

                if (resultado)
                {
                    MessageBox.Show("Detalle de Venta eliminado con éxito (o todos los detalles de esa venta).");
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

                // Obtener las llaves compuestas
                _idVentaSeleccionado = Convert.ToInt32(row.Cells["IdVenta"].Value);
                _idProductoSeleccionado = Convert.ToInt32(row.Cells["IdProducto"].Value);

                // Cargar datos en TextBoxes
                textBoxIdVenta.Text = _idVentaSeleccionado.ToString();
                textBoxIdProducto.Text = _idProductoSeleccionado.ToString();
                textBoxCantidad.Text = row.Cells["Cantidad"].Value?.ToString();

                // NOTA: Si el campo 'PrecioUnitario' existe en el DataGridView, puedes cargarlo así:
                // textBoxPrecioUnitario.Text = row.Cells["PrecioUnitario"].Value?.ToString();

                // Las llaves primarias no deben ser editables al actualizar
                textBoxIdVenta.ReadOnly = true;
                textBoxIdProducto.ReadOnly = true;

                // Cambiar el estado de los botones
                buttonGuardar.Enabled = false;
                buttonActualizar.Enabled = true;
                buttonEliminar.Enabled = true;
            }
        }

        // ----------------------------------------------------------------------
        // 5. MÉTODOS VACÍOS
        // ----------------------------------------------------------------------
        private void textBoxCantidad_TextChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}