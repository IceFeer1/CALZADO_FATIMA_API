using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using WinFormsApp1.Models; // Para usar la clase Proveedor

namespace WinFormsApp1.Services
{
    public class ProveedorService
    {
        // ⭐ ¡IMPORTANTE! Ajusta el puerto y la ruta del Controller
        private const string BaseUrl = "AQUI EN ESTA PARTE PEGA EL URL DE LA API Y EL PORT"; // FERNANDOOOOOO
        private readonly HttpClient _client;

        public ProveedorService()
        {
            _client = new HttpClient();
        }

        // ------------------------------------------------------------------
        // 1. OBTENER TODOS (GET)
        // ------------------------------------------------------------------
        public async Task<List<Proveedor>> ObtenerTodos()
        {
            try
            {
                var response = await _client.GetAsync(BaseUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    // Deserializa el JSON a una lista de objetos Proveedor
                    return JsonConvert.DeserializeObject<List<Proveedor>>(json);
                }

                return new List<Proveedor>();
            }
            catch (Exception ex)
            {
                // Manejo de errores de conexión (API apagada, URL incorrecta)
                MessageBox.Show($"Error de conexión al obtener Proveedores: {ex.Message}", "Error de API");
                return new List<Proveedor>();
            }
        }

        // ------------------------------------------------------------------
        // 2. GUARDAR (POST) - Para crear un nuevo proveedor
        // ------------------------------------------------------------------
        public async Task<bool> Guardar(Proveedor proveedor)
        {
            try
            {
                // Serializa el objeto Proveedor a formato JSON
                var json = JsonConvert.SerializeObject(proveedor);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(BaseUrl, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar guardar el proveedor: {ex.Message}", "Error de API");
                return false;
            }
        }

        // ------------------------------------------------------------------
        // 3. ACTUALIZAR (PUT) - Para modificar datos del proveedor
        // ------------------------------------------------------------------
        public async Task<bool> Actualizar(Proveedor proveedor)
        {
            try
            {
                var json = JsonConvert.SerializeObject(proveedor);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // La ruta incluye el ID: /api/Proveedores/{IdProveedor}
                var url = $"{BaseUrl}/{proveedor.IdProveedor}";
                var response = await _client.PutAsync(url, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar actualizar el proveedor: {ex.Message}", "Error de API");
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
                // La ruta incluye el ID: /api/Proveedores/{id}
                var url = $"{BaseUrl}/{id}";
                var response = await _client.DeleteAsync(url);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar eliminar el proveedor: {ex.Message}", "Error de API");
                return false;
            }
        }
    }
}