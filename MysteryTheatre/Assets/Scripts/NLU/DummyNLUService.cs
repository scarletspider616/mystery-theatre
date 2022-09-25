using System;
using System.Threading.Tasks;


namespace NLU
{
    [Serializable]
    public class DummyNLUService : INLUService
    {
        public async override Task<string> GetResponseAsync(string prompt)
        {
            return $"Dummy response for prompt: {prompt}";
        }
    }
}