using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace NLU
{
    [Serializable]
    public class DummyNLUService : INLUService
    {
        public override Task<List<string>> GetResponseAsync(string prompt)
        {
            return Task.FromResult(new List<string> {$"Dummy response for prompt: {prompt}"});
        }
    }
}