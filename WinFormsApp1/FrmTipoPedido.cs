using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Models;      // Para usar la clase TipoPedido
using WinFormsApp1.Services;    // Para usar TipoPedidoService

namespace WinFormsApp1
{
    public partial class FrmTipoPedido : Form
    {
        // 1. INSTANCIACIÓN Y VARIABLES DE ESTADO
        // -------------------------------------
        TipoPedidoService _service = new TipoPedidoService();
        int _idSeleccionado = 0; // Almacena el ID del TipoPedido seleccionado

        public FrmTipoPedido()
        {
            InitializeComponent();

            // Inicialización de botones
            buttonActualizar.Enabled = false;
            buttonEliminar.Enabled = false;

            // Conectar la carga de datos y la selección de celdas
            this.Load += new EventHandler(FrmTipoPedido_Load);
            // Asumimos que el DataGridView se llama dataGridView1
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
        }

        // ----------------------------------------------------------------------
        // 2. CARGA INICIAL Y MÉTODOS DE RECARGA
        // ----------------------------------------------------------------------

        private async void FrmTipoPedido_Load(object sender, EventArgs e)
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
            // Asumimos que el TextBox para la descripción se llama 'textBoxDescripcion'
            textBoxDescripcion.Text = "";

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
            string descripcion = textBoxDescripcion.Text.Trim();
            if (string.IsNullOrEmpty(descripcion))
            {
                MessageBox.Show("La Descripción no puede estar vacía.", "Validación");
                return;
            }

            var tipoPedido = new TipoPedido
            {
                Descripcion = descripcion
                // IdTipoPedido (PK) es generado por la API/DB
            };

            bool resultado = await _service.Guardar(tipoPedido);

            if (resultado)
            {
                MessageBox.Show("Tipo de Pedido guardado con éxito.");
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
                MessageBox.Show("No hay un Tipo de Pedido seleccionado para actualizar.", "Error");
                return;
            }

            // Validaciones de entrada
            string descripcion = textBoxDescripcion.Text.Trim();
            if (string.IsNullOrEmpty(descripcion))
            {
                MessageBox.Show("La Descripción no puede estar vacía.", "Validación");
                return;
            }

            var tipoPedido = new TipoPedido
            {
                // Asume que la PK en el modelo es IdTipoPedido
                IdTipo = _idSeleccionado,
                Descripcion = descripcion
            };

            bool resultado = await _service.Actualizar(tipoPedido);

            if (resultado)
            {
                MessageBox.Show("Tipo de Pedido actualizado con éxito.");
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
                MessageBox.Show("Selecciona un Tipo de Pedido para eliminar.", "Error");
                return;
            }

            var confirmacion = MessageBox.Show("¿Estás seguro de que quieres eliminar este Tipo de Pedido? Esto podría afectar a los Pedidos asociados.", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                // Asumimos que el método Eliminar en el servicio toma el ID (int)
                bool resultado = await _service.Eliminar(_idSeleccionado);

                if (resultado)
                {
                    MessageBox.Show("Tipo de Pedido eliminado con éxito.");
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

                // Asignar el ID y la descripción a los TextBoxes
                // Asume que la columna en el DataGridView se llama "IdTipoPedido"
                _idSeleccionado = Convert.ToInt32(row.Cells["IdTipoPedido"].Value);
                textBoxDescripcion.Text = row.Cells["Descripcion"].Value?.ToString();

                // Cambiar el estado de los botones
                buttonGuardar.Enabled = false;
                buttonActualizar.Enabled = true;
                buttonEliminar.Enabled = true;
            }
        }

        // ----------------------------------------------------------------------
        // 5. MÉTODOS VACÍOS (Métodos de la plantilla inicial)
        // ----------------------------------------------------------------------
        private void textBoxDescripcion_TextChanged(object sender, EventArgs e) { }
    }
}