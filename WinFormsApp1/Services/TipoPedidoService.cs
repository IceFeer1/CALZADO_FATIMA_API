using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using WinFormsApp1.Models; // Para usar la clase TipoPedido

namespace WinFormsApp1.Services
{
    public class TipoPedidoService
    {
        // ⭐ ¡IMPORTANTE! Ajusta el puerto y la ruta del Controller
        private const string BaseUrl = "AQUI EN ESTA PARTE PEGA EL URL DE LA API Y EL PORT"; // FERNANDOOOOOO
        private readonly HttpClient _client;

        public TipoPedidoService()
        {
            _client = new HttpClient();
        }

        // ------------------------------------------------------------------
        // 1. OBTENER TODOS (GET)
        // ------------------------------------------------------------------
        public async Task<List<TipoPedido>> ObtenerTodos()
        {
            try
            {
                var response = await _client.GetAsync(BaseUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    // Deserializa el JSON a una lista de objetos TipoPedido
                    return JsonConvert.DeserializeObject<List<TipoPedido>>(json);
                }

                return new List<TipoPedido>();
            }
            catch (Exception ex)
            {
                // Manejo de errores de conexión (API apagada, URL incorrecta)
                MessageBox.Show($"Error de conexión al obtener Tipos de Pedido: {ex.Message}", "Error de API");
                return new List<TipoPedido>();
            }
        }

        // ------------------------------------------------------------------
        // 2. GUARDAR (POST) - Crea un nuevo tipo de pedido
        // ------------------------------------------------------------------
        public async Task<bool> Guardar(TipoPedido tipo)
        {
            try
            {
                // Serializa el objeto TipoPedido a formato JSON
                var json = JsonConvert.SerializeObject(tipo);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(BaseUrl, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar guardar el tipo de pedido: {ex.Message}", "Error de API");
                return false;
            }
        }

        // ------------------------------------------------------------------
        // 3. ACTUALIZAR (PUT) - Para modificar el nombre o descripción
        // ------------------------------------------------------------------
        public async Task<bool> Actualizar(TipoPedido tipo)
        {
            try
            {
                var json = JsonConvert.SerializeObject(tipo);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // La ruta incluye el ID: /api/TipoPedidos/{IdTipoPedido}
                var url = $"{BaseUrl}/{tipo.IdTipo}";
                var response = await _client.PutAsync(url, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar actualizar el tipo de pedido: {ex.Message}", "Error de API");
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
                // La ruta incluye el ID: /api/TipoPedidos/{id}
                var url = $"{BaseUrl}/{id}";
                var response = await _client.DeleteAsync(url);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar eliminar el tipo de pedido: {ex.Message}", "Error de API");
                return false;
            }
        }
    }
}