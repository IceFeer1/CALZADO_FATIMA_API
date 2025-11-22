using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using WinFormsApp1.Models; // Para usar la clase Venta

namespace WinFormsApp1.Services
{
    public class VentaService
    {
        // ⭐ ¡IMPORTANTE! Ajusta el puerto y la ruta del Controller
        private const string BaseUrl = "AQUI EN ESTA PARTE PEGA EL URL DE LA API Y EL PORT"; // FERNANDOOOOOO
        private readonly HttpClient _client;

        public VentaService()
        {
            _client = new HttpClient();
        }

        // ------------------------------------------------------------------
        // 1. OBTENER TODOS (GET) - Lista de transacciones de venta
        // ------------------------------------------------------------------
        public async Task<List<Venta>> ObtenerTodos()
        {
            try
            {
                var response = await _client.GetAsync(BaseUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    // Deserializa el JSON a una lista de objetos Venta
                    return JsonConvert.DeserializeObject<List<Venta>>(json);
                }

                return new List<Venta>();
            }
            catch (Exception ex)
            {
                // Manejo de errores de conexión (API apagada, URL incorrecta)
                MessageBox.Show($"Error de conexión al obtener Ventas: {ex.Message}", "Error de API");
                return new List<Venta>();
            }
        }

        // ------------------------------------------------------------------
        // 2. GUARDAR (POST) - Registra una nueva transacción de venta
        // ------------------------------------------------------------------
        public async Task<bool> Guardar(Venta venta)
        {
            try
            {
                // Serializa el objeto Venta a formato JSON.
                // Nota: Tu API debe estar configurada para aceptar el DTO de Venta, 
                // que idealmente incluye la lista de DetalleVenta.
                var json = JsonConvert.SerializeObject(venta);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(BaseUrl, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar registrar la venta: {ex.Message}", "Error de API");
                return false;
            }
        }

        // ------------------------------------------------------------------
        // 3. ACTUALIZAR (PUT) - Para anular o modificar una venta existente
        // ------------------------------------------------------------------
        public async Task<bool> Actualizar(Venta venta)
        {
            try
            {
                var json = JsonConvert.SerializeObject(venta);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // La ruta incluye el ID: /api/Ventas/{IdVenta}
                var url = $"{BaseUrl}/{venta.IdVenta}";
                var response = await _client.PutAsync(url, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar actualizar la venta: {ex.Message}", "Error de API");
                return false;
            }
        }

        // ------------------------------------------------------------------
        // 4. ELIMINAR (DELETE) - Eliminar/Anular una venta
        // ------------------------------------------------------------------
        public async Task<bool> Eliminar(int id)
        {
            try
            {
                // La ruta incluye el ID: /api/Ventas/{id}
                var url = $"{BaseUrl}/{id}";
                var response = await _client.DeleteAsync(url);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar anular/eliminar la venta: {ex.Message}", "Error de API");
                return false;
            }
        }
    }
}