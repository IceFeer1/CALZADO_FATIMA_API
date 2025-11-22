using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Models;      // Para usar la clase Pedido
using WinFormsApp1.Services;    // Para usar PedidoService

namespace WinFormsApp1
{
    public partial class FrmPedidos : Form
    {
        // 1. INSTANCIACIÓN Y VARIABLES DE ESTADO
        // -------------------------------------
        PedidoService _service = new PedidoService();
        int _idSeleccionado = 0; // Almacena el ID del Pedido seleccionado

        public FrmPedidos()
        {
            InitializeComponent();

            // Inicialización de botones
            buttonActualizar.Enabled = false;
            buttonEliminar.Enabled = false;

            // Conectar la carga de datos y la selección de celdas
            this.Load += new EventHandler(FrmPedidos_Load);
            // Asumimos que el DataGridView se llama dataGridView1
            // ¡Asegúrate de agregar un DataGridView llamado 'dataGridView1' al formulario!
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
        }

        // ----------------------------------------------------------------------
        // 2. CARGA INICIAL Y MÉTODOS DE RECARGA
        // ----------------------------------------------------------------------

        private async void FrmPedidos_Load(object sender, EventArgs e)
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
                // NOTA: Si la API devuelve los ID de Tipo y Estado en lugar de los objetos,
                // la lista se cargará correctamente. Si devuelve los objetos completos,
                // puede que necesites un DTO o configurar el DataGridView.
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
            // Limpia los TextBoxes (usando los nombres definidos en tu plantilla)
            textBoxIDCliente.Text = "";
            textBoxTipo.Text = "";
            textBoxEstado.Text = "";
            textBoxFecha.Text = "";

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
            // Validaciones de entrada (IdCliente, IdTipo, IdEstado como int; Fecha como DateTime)
            if (!int.TryParse(textBoxIDCliente.Text, out int idCliente) ||
                !int.TryParse(textBoxTipo.Text, out int idTipo) ||
                !int.TryParse(textBoxEstado.Text, out int idEstado) ||
                !DateTime.TryParse(textBoxFecha.Text, out DateTime fechaPedido))
            {
                MessageBox.Show("Asegúrate de que ID Cliente, Tipo y Estado sean números válidos, y la Fecha de Pedido sea válida.", "Validación");
                return;
            }

            var pedido = new Pedido
            {
                IdCliente = idCliente,
                IdTipo = idTipo,
                IdEstado = idEstado,
                FechaPedido = fechaPedido
                // IdPedido (PK) es generado por la API/DB
            };

            bool resultado = await _service.Guardar(pedido);

            if (resultado)
            {
                MessageBox.Show("Pedido guardado con éxito.");
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
                MessageBox.Show("No hay un pedido seleccionado para actualizar.", "Error");
                return;
            }

            // Validaciones de entrada
            if (!int.TryParse(textBoxIDCliente.Text, out int idCliente) ||
                !int.TryParse(textBoxTipo.Text, out int idTipo) ||
                !int.TryParse(textBoxEstado.Text, out int idEstado) ||
                !DateTime.TryParse(textBoxFecha.Text, out DateTime fechaPedido))
            {
                MessageBox.Show("Asegúrate de que ID Cliente, Tipo y Estado sean números válidos, y la Fecha de Pedido sea válida.", "Validación");
                return;
            }

            var pedido = new Pedido
            {
                IdPedido = _idSeleccionado, // CLAVE: Enviamos el ID para actualizar
                IdCliente = idCliente,
                IdTipo = idTipo,
                IdEstado = idEstado,
                FechaPedido = fechaPedido
            };

            bool resultado = await _service.Actualizar(pedido);

            if (resultado)
            {
                MessageBox.Show("Pedido actualizado con éxito.");
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
                MessageBox.Show("Selecciona un pedido para eliminar.", "Error");
                return;
            }

            var confirmacion = MessageBox.Show("¿Estás seguro de que quieres eliminar este pedido? Esto podría afectar a sus detalles.", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                // Asumimos que el método Eliminar en el servicio toma el ID (int)
                bool resultado = await _service.Eliminar(_idSeleccionado);

                if (resultado)
                {
                    MessageBox.Show("Pedido eliminado con éxito.");
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
                _idSeleccionado = Convert.ToInt32(row.Cells["IdPedido"].Value);

                // Cargar ID de claves foráneas
                textBoxIDCliente.Text = row.Cells["IdCliente"].Value?.ToString();
                textBoxTipo.Text = row.Cells["IdTipo"].Value?.ToString();     // Asumimos que la columna se llama IdTipo
                textBoxEstado.Text = row.Cells["IdEstado"].Value?.ToString(); // Asumimos que la columna se llama IdEstado

                // Formatear la fecha
                if (row.Cells["FechaPedido"].Value != null && row.Cells["FechaPedido"].Value is DateTime fecha)
                {
                    textBoxFecha.Text = fecha.ToShortDateString();
                }

                // Cambiar el estado de los botones
                buttonGuardar.Enabled = false;
                buttonActualizar.Enabled = true;
                buttonEliminar.Enabled = true;
            }
        }

        // ----------------------------------------------------------------------
        // 5. MÉTODOS VACÍOS (Métodos de la plantilla inicial)
        // ----------------------------------------------------------------------
        private void textBoxIDCliente_TextChanged(object sender, EventArgs e) { }
        private void textBoxTipo_TextChanged(object sender, EventArgs e) { }
        private void textBoxEstado_TextChanged(object sender, EventArgs e) { }
        private void textBoxFecha_TextChanged(object sender, EventArgs e) { }
    }
}