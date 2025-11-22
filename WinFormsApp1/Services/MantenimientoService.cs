using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using WinFormsApp1.Models; // Para usar la clase Mantenimiento

namespace WinFormsApp1.Services
{
    public class MantenimientoService
    {
        // ⭐ ¡IMPORTANTE! Ajusta el puerto y la ruta del Controller
        private const string BaseUrl = "AQUI EN ESTA PARTE PEGA EL URL DE LA API Y EL PORT"; // FERNANDOOOOOO
        private readonly HttpClient _client;

        public MantenimientoService()
        {
            _client = new HttpClient();
        }

        // ------------------------------------------------------------------
        // 1. OBTENER TODOS (GET)
        // ------------------------------------------------------------------
        public async Task<List<Mantenimiento>> ObtenerTodos()
        {
            try
            {
                var response = await _client.GetAsync(BaseUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    // Deserializa el JSON a una lista de objetos Mantenimiento
                    return JsonConvert.DeserializeObject<List<Mantenimiento>>(json);
                }

                return new List<Mantenimiento>();
            }
            catch (Exception ex)
            {
                // Manejo de errores de conexión (API apagada, URL incorrecta)
                MessageBox.Show($"Error de conexión al obtener Mantenimientos: {ex.Message}", "Error de API");
                return new List<Mantenimiento>();
            }
        }

        // ------------------------------------------------------------------
        // 2. GUARDAR (POST)
        // ------------------------------------------------------------------
        public async Task<bool> Guardar(Mantenimiento mantenimiento)
        {
            try
            {
                // Serializa el objeto Mantenimiento a formato JSON
                var json = JsonConvert.SerializeObject(mantenimiento);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(BaseUrl, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar guardar el mantenimiento: {ex.Message}", "Error de API");
                return false;
            }
        }

        // ------------------------------------------------------------------
        // 3. ACTUALIZAR (PUT)
        // ------------------------------------------------------------------
        public async Task<bool> Actualizar(Mantenimiento mantenimiento)
        {
            try
            {
                var json = JsonConvert.SerializeObject(mantenimiento);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Asumimos que la llave primaria es IdMantenimiento (o similar)
                // Debes asegurarte de que tu clase Mantenimiento en Models tenga esta propiedad.
                var url = $"{BaseUrl}/{mantenimiento.IdMantenimiento}";
                var response = await _client.PutAsync(url, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar actualizar el mantenimiento: {ex.Message}", "Error de API");
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
                // La ruta incluye el ID: /api/Mantenimientos/{id}
                var url = $"{BaseUrl}/{id}";
                var response = await _client.DeleteAsync(url);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar eliminar el mantenimiento: {ex.Message}", "Error de API");
                return false;
            }
        }
    }
}