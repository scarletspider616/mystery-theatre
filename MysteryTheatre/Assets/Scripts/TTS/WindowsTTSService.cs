using System.Diagnostics;

namespace TTS
{
    public class WindowsTTSService : ITTSService
    {
        public override void Speak(string transcript)
        {
            // PowerShell -Command "Add-Type –AssemblyName System.Speech; (New-Object System.Speech.Synthesis.SpeechSynthesizer).Speak('hello');"
            var startInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments =
                    $"-Command \"Add-Type -AssemblyName System.Speech; (New-Object System.Speech.Synthesis.SpeechSynthesizer).Speak('${transcript}');\"",
                UseShellExecute = false,
                RedirectStandardOutput = false
            };
            SpeechProcess = Process.Start("/usr/bin/say", transcript);
        }
    }
}