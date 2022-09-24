using System;
using UnityEngine;

namespace NLU
{
    public abstract class INLUService : MonoBehaviour
    {
        // TODO: Update in/out to be models containing return codes, ctx etc
        public abstract string GetResponse(string prompt);
    }
}