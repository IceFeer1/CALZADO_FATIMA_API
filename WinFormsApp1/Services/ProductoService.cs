using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using WinFormsApp1.Models; // Para usar la clase Producto

namespace WinFormsApp1.Services
{
    public class ProductoService
    {
        // ⭐ ¡IMPORTANTE! Ajusta el puerto y la ruta del Controller
        private const string BaseUrl = "AQUI EN ESTA PARTE PEGA EL URL DE LA API Y EL PORT"; // FERNANDOOOOOO
        private readonly HttpClient _client;

        public ProductoService()
        {
            _client = new HttpClient();
        }

        // ------------------------------------------------------------------
        // 1. OBTENER TODOS (GET)
        // ------------------------------------------------------------------
        public async Task<List<Producto>> ObtenerTodos()
        {
            try
            {
                var response = await _client.GetAsync(BaseUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    // Deserializa el JSON a una lista de objetos Producto
                    return JsonConvert.DeserializeObject<List<Producto>>(json);
                }

                return new List<Producto>();
            }
            catch (Exception ex)
            {
                // Manejo de errores de conexión (API apagada, URL incorrecta)
                MessageBox.Show($"Error de conexión al obtener Productos: {ex.Message}", "Error de API");
                return new List<Producto>();
            }
        }

        // ------------------------------------------------------------------
        // 2. GUARDAR (POST) - Para crear un nuevo producto
        // ------------------------------------------------------------------
        public async Task<bool> Guardar(Producto producto)
        {
            try
            {
                // Serializa el objeto Producto a formato JSON
                var json = JsonConvert.SerializeObject(producto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(BaseUrl, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar guardar el producto: {ex.Message}", "Error de API");
                return false;
            }
        }

        // ------------------------------------------------------------------
        // 3. ACTUALIZAR (PUT) - Para modificar nombre, precio, stock, etc.
        // ------------------------------------------------------------------
        public async Task<bool> Actualizar(Producto producto)
        {
            try
            {
                var json = JsonConvert.SerializeObject(producto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // La ruta incluye el ID: /api/Productos/{IdProducto}
                var url = $"{BaseUrl}/{producto.IdProducto}";
                var response = await _client.PutAsync(url, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar actualizar el producto: {ex.Message}", "Error de API");
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
                // La ruta incluye el ID: /api/Productos/{id}
                var url = $"{BaseUrl}/{id}";
                var response = await _client.DeleteAsync(url);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar eliminar el producto: {ex.Message}", "Error de API");
                return false;
            }
        }
    }
}