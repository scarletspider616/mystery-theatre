using System;
using UnityEngine;
using System.Threading.Tasks;


namespace NLU
{
    public abstract class INLUService : MonoBehaviour
    {
        // TODO: Update in/out to be models containing return codes, ctx etc
        public abstract Task<string> GetResponseAsync(string prompt);
    }
}