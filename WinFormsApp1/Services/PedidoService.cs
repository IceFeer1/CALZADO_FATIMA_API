using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using WinFormsApp1.Models; // Para usar la clase Pedido

namespace WinFormsApp1.Services
{
    public class PedidoService
    {
        // ⭐ ¡IMPORTANTE! Ajusta el puerto y la ruta del Controller
        private const string BaseUrl = "AQUI EN ESTA PARTE PEGA EL URL DE LA API Y EL PORT"; // FERNANDOOOOOO
        private readonly HttpClient _client;

        public PedidoService()
        {
            _client = new HttpClient();
        }

        // ------------------------------------------------------------------
        // 1. OBTENER TODOS (GET)
        // ------------------------------------------------------------------
        public async Task<List<Pedido>> ObtenerTodos()
        {
            try
            {
                var response = await _client.GetAsync(BaseUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    // Deserializa el JSON a una lista de objetos Pedido
                    return JsonConvert.DeserializeObject<List<Pedido>>(json);
                }

                return new List<Pedido>();
            }
            catch (Exception ex)
            {
                // Manejo de errores de conexión (API apagada, URL incorrecta)
                MessageBox.Show($"Error de conexión al obtener Pedidos: {ex.Message}", "Error de API");
                return new List<Pedido>();
            }
        }

        // ------------------------------------------------------------------
        // 2. GUARDAR (POST) - Para crear un nuevo pedido
        // ------------------------------------------------------------------
        public async Task<bool> Guardar(Pedido pedido)
        {
            try
            {
                // Serializa el objeto Pedido a formato JSON
                var json = JsonConvert.SerializeObject(pedido);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(BaseUrl, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar guardar el pedido: {ex.Message}", "Error de API");
                return false;
            }
        }

        // ------------------------------------------------------------------
        // 3. ACTUALIZAR (PUT) - Para modificar estado, fechas, etc.
        // ------------------------------------------------------------------
        public async Task<bool> Actualizar(Pedido pedido)
        {
            try
            {
                var json = JsonConvert.SerializeObject(pedido);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Asumimos que la llave primaria es IdPedido
                var url = $"{BaseUrl}/{pedido.IdPedido}";
                var response = await _client.PutAsync(url, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar actualizar el pedido: {ex.Message}", "Error de API");
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
                // La ruta incluye el ID: /api/Pedidos/{id}
                var url = $"{BaseUrl}/{id}";
                var response = await _client.DeleteAsync(url);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar eliminar el pedido: {ex.Message}", "Error de API");
                return false;
            }
        }
    }
}