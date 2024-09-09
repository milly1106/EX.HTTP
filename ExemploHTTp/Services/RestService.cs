using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using ExemploHTTp.Models;
using System.Text.Json;
using System.Linq.Expressions;
using System.Diagnostics;

namespace ExemploHTTp.Services
{
    public class RestService
    {
        private HttpClient client;
        private Fotos foto;
        private List<Fotos> fotos;
        private JsonSerializerOptions _seriallizarOptions;
        RestService()
        {
            client = new HttpClient();
            _seriallizarOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<Fotos>> getFotosAsync()
        {
            Uri uri = new Uri("https://jsonplaceholder.typicode.com/photos");
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    fotos = JsonSerializer.Deserialize<List<Fotos>>(content, _seriallizarOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return fotos;


        }

    }
}
