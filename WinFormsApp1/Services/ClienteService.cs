using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using WinFormsApp1.Models; // Necesitas esta referencia

namespace WinFormsApp1.Services
{
    public class ClienteService
    {
        // ⭐ ¡IMPORTANTE! Cambia el puerto por el que usa tu API.
        private const string BaseUrl = "AQUI EN ESTA PARTE PEGA EL URL DE LA API Y EL PORT"; // FERNANDOOOOOO
        private readonly HttpClient _client;

        public ClienteService()
        {
            _client = new HttpClient();
        }

        // ------------------------------------------------------------------
        // 1. OBTENER TODOS (GET)
        // ------------------------------------------------------------------
        public async Task<List<Cliente>> ObtenerTodos()
        {
            try
            {
                var response = await _client.GetAsync(BaseUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    // Deserializa el JSON a una lista de objetos Cliente
                    return JsonConvert.DeserializeObject<List<Cliente>>(json);
                }

                // Si falla (ej. 404, 500), devuelve una lista vacía.
                return new List<Cliente>();
            }
            catch (Exception ex)
            {
                // Manejo de errores de conexión (API apagada, URL incorrecta)
                MessageBox.Show($"Error de conexión al obtener clientes: {ex.Message}", "Error de API");
                return new List<Cliente>();
            }
        }

        // ------------------------------------------------------------------
        // 2. GUARDAR (POST)
        // ------------------------------------------------------------------
        public async Task<bool> Guardar(Cliente cliente)
        {
            try
            {
                // Serializa el objeto Cliente a formato JSON
                var json = JsonConvert.SerializeObject(cliente);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(BaseUrl, content);

                // Retorna true si el código de estado es 200 (OK) o 201 (Created)
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar guardar el cliente: {ex.Message}", "Error de API");
                return false;
            }
        }

        // ------------------------------------------------------------------
        // 3. ACTUALIZAR (PUT)
        // ------------------------------------------------------------------
        public async Task<bool> Actualizar(Cliente cliente)
        {
            try
            {
                var json = JsonConvert.SerializeObject(cliente);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // La ruta incluye el ID: /api/Clientes/{IdCliente}
                var url = $"{BaseUrl}/{cliente.IdCliente}";
                var response = await _client.PutAsync(url, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar actualizar el cliente: {ex.Message}", "Error de API");
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
                // La ruta incluye el ID: /api/Clientes/{id}
                var url = $"{BaseUrl}/{id}";
                var response = await _client.DeleteAsync(url);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar eliminar el cliente: {ex.Message}", "Error de API");
                return false;
            }
        }
    }
}