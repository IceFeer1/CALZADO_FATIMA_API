using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using WinFormsApp1.Models; // Para usar la clase DetalleVenta

namespace WinFormsApp1.Services
{
    public class DetalleVentaService
    {
        // ⭐ ¡IMPORTANTE! Ajusta el puerto y la ruta del Controller
        private const string BaseUrl = "AQUI EN ESTA PARTE PEGA EL URL DE LA API Y EL PORT"; // FERNANDOOOOOO
        private readonly HttpClient _client;

        public DetalleVentaService()
        {
            _client = new HttpClient();
        }

        // ------------------------------------------------------------------
        // 1. OBTENER TODOS (GET) - Para cargar el DataGridView de historial
        // ------------------------------------------------------------------
        public async Task<List<DetalleVenta>> ObtenerTodos()
        {
            try
            {
                var response = await _client.GetAsync(BaseUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<DetalleVenta>>(json);
                }

                return new List<DetalleVenta>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión al obtener Detalles de Venta: {ex.Message}", "Error de API");
                return new List<DetalleVenta>();
            }
        }

        // ------------------------------------------------------------------
        // 2. GUARDAR (POST) - Para agregar un nuevo detalle (línea de producto)
        // ------------------------------------------------------------------
        public async Task<bool> Guardar(DetalleVenta detalle)
        {
            try
            {
                var json = JsonConvert.SerializeObject(detalle);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(BaseUrl, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar guardar el detalle de venta: {ex.Message}", "Error de API");
                return false;
            }
        }

        // ------------------------------------------------------------------
        // 3. ACTUALIZAR (PUT) - Para modificar la cantidad o precio de una línea
        // ------------------------------------------------------------------
        public async Task<bool> Actualizar(DetalleVenta detalle)
        {
            try
            {
                var json = JsonConvert.SerializeObject(detalle);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Asumiendo que la llave primaria es IdDetalleVenta
                var url = $"{BaseUrl}/{detalle.IdDetalle}";
                var response = await _client.PutAsync(url, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar actualizar el detalle de venta: {ex.Message}", "Error de API");
                return false;
            }
        }

        // ------------------------------------------------------------------
        // 4. ELIMINAR (DELETE) - Para quitar una línea de producto del detalle
        // ------------------------------------------------------------------
        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var url = $"{BaseUrl}/{id}";
                var response = await _client.DeleteAsync(url);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar eliminar el detalle de venta: {ex.Message}", "Error de API");
                return false;
            }
        }
    }
}