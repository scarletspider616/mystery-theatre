using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace NLU
{
    public class RasaNLUService : INLUService
    {

        private static readonly HttpClient client = new HttpClient();
        
        public async override Task<string> GetResponseAsync(string prompt)
        {

            var data = new StringContent(JsonConvert.SerializeObject(new
            {
                sender = "theuser",
                message = prompt
                }));

            data.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("http://localhost:5005/webhooks/rest/webhook", data);
            var responseString = await response.Content.ReadAsStringAsync();
            var reply = JsonConvert.DeserializeObject<List<RasaReply>>(responseString);
            return reply[0].text;
        }       
    }
}