using System;
using System.Net.Http;

namespace NLU
{
    [Serializable]
    public class RasaNLUService : INLUService
    {

        private static readonly HttpClient client = new HttpClient();
        
        public override string GetResponse(string prompt)
        {
            var responseString = client.GetResponse("localhost:5005");
            // return $"Dummy response for prompt: {prompt}";
            //var responseString = "hi";
            return responseString;
        }
        
    }
}