using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using WinFormsApp1.Models;
using System.Net; // Necesario para manejar respuestas específicas

namespace WinFormsApp1.Services
{
    public class SuministraService
    {
        // ⭐ ¡IMPORTANTE! Ajusta el puerto (7123)
        private const string BaseUrl = "AQUI EN ESTA PARTE PEGA EL URL DE LA API Y EL PORT"; // FERNANDOOOOOO
        private readonly HttpClient _client;

        public SuministraService()
        {
            _client = new HttpClient();
        }
        

        // ------------------------------------------------------------------
        // 1. OBTENER TODOS (GET)
        // ------------------------------------------------------------------
        public async Task<List<Suministra>> ObtenerTodos()
        {
            try
            {
                var response = await _client.GetAsync(BaseUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Suministra>>(json);
                }

                return new List<Suministra>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión al obtener Suministros: {ex.Message}", "Error de API");
                return new List<Suministra>();
            }
        }

        // ------------------------------------------------------------------
        // 2. GUARDAR (POST) - Crea una nueva relación de suministro
        // ------------------------------------------------------------------
        public async Task<bool> Guardar(Suministra suministra)
        {
            try
            {
                var json = JsonConvert.SerializeObject(suministra);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(BaseUrl, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar guardar el suministro: {ex.Message}", "Error de API");
                return false;
            }
        }

        // ------------------------------------------------------------------
        // 3. ACTUALIZAR (PUT) 
        //    Asumimos que la llave compuesta es IdProducto + IdProveedor 
        //    y que tu API expone un endpoint que acepta estos IDs en la URL.
        // ------------------------------------------------------------------
        public async Task<bool> Actualizar(Suministra suministra)
        {
            try
            {
                var json = JsonConvert.SerializeObject(suministra);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // La ruta incluye los dos IDs que actúan como llave primaria:
                // Ejemplo de ruta de API: /api/Suministras?idProducto=1&idProveedor=5
                var url = $"{BaseUrl}?idProducto={suministra.IdProducto}&idProveedor={suministra.IdProveedor}";

                var response = await _client.PutAsync(url, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar actualizar el suministro: {ex.Message}", "Error de API");
                return false;
            }
        }

        // ------------------------------------------------------------------
        // 4. ELIMINAR (DELETE)
        //    Se asume que la API permite eliminar con la llave compuesta
        // ------------------------------------------------------------------
        public async Task<bool> Eliminar(int idProducto, int idProveedor)
        {
            try
            {
                // La ruta incluye los dos IDs para identificar el registro a eliminar
                // Ejemplo de ruta de API: /api/Suministras/1/5 
                var url = $"{BaseUrl}/{idProducto}/{idProveedor}";
                var response = await _client.DeleteAsync(url);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar eliminar el suministro: {ex.Message}", "Error de API");
                return false;
            }
        }
    }
}