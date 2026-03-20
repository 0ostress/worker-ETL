using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ETLWorker.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<string>> ObtenerComentariosAsync()
        {
            var comentarios = new List<string>();

            try
            {
                var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/comments");

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Error API: " + response.StatusCode);
                    return comentarios;
                }

                var json = await response.Content.ReadAsStringAsync();

                using (JsonDocument doc = JsonDocument.Parse(json))
                {
                    foreach (JsonElement item in doc.RootElement.EnumerateArray())
                    {
                        // Validar que exista la propiedad "body"
                        if (item.TryGetProperty("body", out JsonElement body))
                        {
                            string texto = body.GetString();

                            if (!string.IsNullOrEmpty(texto))
                            {
                                comentarios.Add(texto);
                                Console.WriteLine("API: " + texto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error API: " + ex.Message);
            }

            return comentarios;
        }
    }
}