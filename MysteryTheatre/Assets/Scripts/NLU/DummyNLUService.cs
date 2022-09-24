using System;

namespace NLU
{
    [Serializable]
    public class DummyNLUService : INLUService
    {
        public override string GetResponse(string prompt)
        {
            return $"Dummy response for prompt: {prompt}";
        }
    }
}