using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using WinFormsApp1.Models; // Para usar la clase EstadoPedido

namespace WinFormsApp1.Services
{
    public class EstadoPedidoService
    {
        // ⭐ ¡IMPORTANTE! Ajusta el puerto y la ruta del Controller
        private const string BaseUrl = "AQUI EN ESTA PARTE PEGA EL URL DE LA API Y EL PORT"; // FERNANDOOOOOO
        private readonly HttpClient _client;

        public EstadoPedidoService()
        {
            _client = new HttpClient();
        }

        // ------------------------------------------------------------------
        // 1. OBTENER TODOS (GET)
        // ------------------------------------------------------------------
        public async Task<List<EstadoPedido>> ObtenerTodos()
        {
            try
            {
                var response = await _client.GetAsync(BaseUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    // Deserializa el JSON a una lista de objetos EstadoPedido
                    return JsonConvert.DeserializeObject<List<EstadoPedido>>(json);
                }

                return new List<EstadoPedido>();
            }
            catch (Exception ex)
            {
                // Manejo de errores de conexión (API apagada, URL incorrecta)
                MessageBox.Show($"Error de conexión al obtener Estados de Pedido: {ex.Message}", "Error de API");
                return new List<EstadoPedido>();
            }
        }

        // ------------------------------------------------------------------
        // 2. GUARDAR (POST)
        // ------------------------------------------------------------------
        public async Task<bool> Guardar(EstadoPedido estado)
        {
            try
            {
                // Serializa el objeto EstadoPedido a formato JSON
                var json = JsonConvert.SerializeObject(estado);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(BaseUrl, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar guardar el estado de pedido: {ex.Message}", "Error de API");
                return false;
            }
        }

        // ------------------------------------------------------------------
        // 3. ACTUALIZAR (PUT)
        // ------------------------------------------------------------------
        public async Task<bool> Actualizar(EstadoPedido estado)
        {
            try
            {
                var json = JsonConvert.SerializeObject(estado);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // La ruta incluye el ID: /api/EstadoPedidos/{IdEstadoPedido}
                var url = $"{BaseUrl}/{estado.IdEstado}";
                var response = await _client.PutAsync(url, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar actualizar el estado de pedido: {ex.Message}", "Error de API");
                return false;
            }
        }

        // ------------------------------------------------------------------
        // 4. ELIMINAR (DELETE)
        // ------------------------------------------------------------------
        public async Task<bool> Eliminar(int id)
        {
            try
            {
                // La ruta incluye el ID: /api/EstadoPedidos/{id}
                var url = $"{BaseUrl}/{id}";
                var response = await _client.DeleteAsync(url);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar eliminar el estado de pedido: {ex.Message}", "Error de API");
                return false;
            }
        }
    }
}