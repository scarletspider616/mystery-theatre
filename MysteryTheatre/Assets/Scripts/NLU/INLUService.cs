namespace NLU
{
    public interface INLUService
    {
        // TODO: Update in/out to be models containing return codes, ctx etc
        public string GetResponse(string prompt);
    }
}