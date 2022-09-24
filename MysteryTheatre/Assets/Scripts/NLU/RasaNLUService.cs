using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NLU
{
    [Serializable]
    public class RasaNLUService : INLUService
    {

        private static readonly HttpClient client = new HttpClient();
        
        public override string GetResponse(string prompt)
        {
            var task = Task.Run(() => client.GetStringAsync("http://localhost:5005")); 
            task.Wait();
            var responseString = task.Result;
            // return $"Dummy response for prompt: {prompt}";
            //var responseString = "hi";
            return responseString;
        }
        
    }
}