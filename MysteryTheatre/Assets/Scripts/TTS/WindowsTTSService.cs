using System.Diagnostics;

namespace TTS
{
    public class WindowsTTSService : ITTSService
    {
        public override void Speak(string transcript)
        {
            transcript = transcript.Replace("'", @"\'");
            // PowerShell -Command "Add-Type –AssemblyName System.Speech; (New-Object System.Speech.Synthesis.SpeechSynthesizer).Speak('hello');"
            var startInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments =
                    $"-Command \"Add-Type -WindowStyle hidden -AssemblyName System.Speech; (New-Object System.Speech.Synthesis.SpeechSynthesizer).Speak('${transcript}');\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                WindowStyle = ProcessWindowStyle.Hidden,
            };
            IsSpeaking = true;
            SpeechProcess = Process.Start(startInfo);
            SpeechProcess?.WaitForExit();
            IsSpeaking = false;
        }
    }
}