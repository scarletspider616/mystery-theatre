using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

namespace NLU
{
    public class RasaNLUService : INLUService
    {
        private Guid _id;
        private void Start()
        {
            _id = Guid.NewGuid();
        }

        private static readonly HttpClient client = new HttpClient();

        public override async Task<List<string>> GetResponseAsync(string prompt)
        {
            var data = new StringContent(JsonConvert.SerializeObject(new
            {
                sender = _id.ToString(),
                message = prompt
                }));

            data.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("http://localhost:5005/webhooks/rest/webhook", data);
            var bytes = await response.Content.ReadAsByteArrayAsync();
            var responseString = Encoding.UTF8.GetString(bytes,0,bytes.Length);
            var rasaReplies = JsonConvert.DeserializeObject<List<RasaReply>>(responseString);
            return rasaReplies?.Select(r=>r.text).ToList();
        }       
    }
}