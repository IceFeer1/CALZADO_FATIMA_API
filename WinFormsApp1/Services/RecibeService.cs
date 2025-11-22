using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using WinFormsApp1.Models;

namespace WinFormsApp1.Services
{
    public class RecibeService
    {
        // ⭐ ¡IMPORTANTE! Ajusta el puerto (7123)
        private const string BaseUrl = "AQUI EN ESTA PARTE PEGA EL URL DE LA API Y EL PORT"; // FERNANDOOOOOO
        private readonly HttpClient _client;

        public RecibeService()
        {
            _client = new HttpClient();
        }

        // ------------------------------------------------------------------
        // 1. OBTENER TODOS (GET)
        // ------------------------------------------------------------------
        public async Task<List<Recibe>> ObtenerTodos()
        {
            try
            {
                var response = await _client.GetAsync(BaseUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Recibe>>(json);
                }

                return new List<Recibe>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión al obtener Recepciones: {ex.Message}", "Error de API");
                return new List<Recibe>();
            }
        }

        // ------------------------------------------------------------------
        // 2. GUARDAR (POST) - Registra una nueva recepción de producto/proveedor
        // ------------------------------------------------------------------
        public async Task<bool> Guardar(Recibe recibe)
        {
            try
            {
                var json = JsonConvert.SerializeObject(recibe);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(BaseUrl, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar guardar la recepción: {ex.Message}", "Error de API");
                return false;
            }
        }

        // ------------------------------------------------------------------
        // 3. ACTUALIZAR (PUT) - Usa la llave compuesta para identificar el registro
        // ------------------------------------------------------------------
        public async Task<bool> Actualizar(Recibe recibe)
        {
            try
            {
                var json = JsonConvert.SerializeObject(recibe);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // La ruta incluye los dos IDs que actúan como llave primaria:
                // Ejemplo de API: /api/Recibes?idProducto=1&idProveedor=5
                var url = $"{BaseUrl}?idProducto={recibe.IdProducto}&idProveedor={recibe.IdProveedor}";

                var response = await _client.PutAsync(url, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar actualizar la recepción: {ex.Message}", "Error de API");
                return false;
            }
        }

        // ------------------------------------------------------------------
        // 4. ELIMINAR (DELETE) - Se elimina usando la llave compuesta
        // ------------------------------------------------------------------
        public async Task<bool> Eliminar(int idProducto, int idProveedor)
        {
            try
            {
                // La ruta incluye los dos IDs para identificar el registro a eliminar:
                // Ejemplo de API: /api/Recibes/1/5
                var url = $"{BaseUrl}/{idProducto}/{idProveedor}";
                var response = await _client.DeleteAsync(url);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar eliminar la recepción: {ex.Message}", "Error de API");
                return false;
            }
        }
    }
}