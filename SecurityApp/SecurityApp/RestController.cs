using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SecurityApp
{
    public class RestController 

    {
        private HttpClient client;

        public RestController()
        {
            client = new HttpClient();
        }

        public async Task<List<string>> GetTemperatureAsync()
        {
            var uri = new Uri("http://localhost:5000/api/temperatura");
            var response = await client.GetAsync(uri);
            List<string> items = null;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                items = JsonConvert.DeserializeObject<List<string>>(content);
            }
            return items;
        }

    }
}
