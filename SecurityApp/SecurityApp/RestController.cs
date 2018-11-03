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

        public async Task<Temperature> GetTemperatureAsync()
        {
            var uri = new Uri("http://192.168.1.223:5000/api/temperatura");
            var response = await client.GetAsync(uri);
            Temperature temperature = null;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                temperature = JsonConvert.DeserializeObject<Temperature>(content);
            }
            return temperature;
        }

        public async Task<bool> PutTemperatureAsync(string newTemperature)
        {
            var uri = new Uri(string.Concat("http://192.168.1.223:5000/api/temperatura/",newTemperature));
            var response = await client.PutAsync(uri, null);
            return response.IsSuccessStatusCode;
        }

    }
}
