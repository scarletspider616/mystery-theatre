using System;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


namespace NLU
{
    public abstract class INLUService : MonoBehaviour
    {
        // TODO: Update in/out to be models containing return codes, ctx etc
        public abstract Task<List<string>> GetResponseAsync(string prompt);
    }
}