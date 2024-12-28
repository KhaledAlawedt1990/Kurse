using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using NAudio.Wave;
using Microsoft.CognitiveServices.Speech;

class Program
{
    private const string AzureSubscriptionKey = "Ihr-Azure-API-Schlüssel";
    private const string AzureRegion = "Ihre-Region"; // z. B. "westeurope"
    private const string GoogleApiKey = "Ihr-Google-API-Schlüssel";

    static async Task Main(string[] args)
    {
        Console.WriteLine("Wählen Sie eine Option:");
        Console.WriteLine("1. Audio aufnehmen");
        Console.WriteLine("2. Sprache erkennen (Azure)");
        Console.WriteLine("3. Sprache erkennen (Google)");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                RecordAudio();
                break;
            case "2":
                Console.WriteLine("Geben Sie den Pfad zur Audiodatei ein:");
                string azureAudioPath = Console.ReadLine();
                string azureResult = await ConvertSpeechToTextAzureAsync(azureAudioPath);
                Console.WriteLine("Erkannt (Azure): " + azureResult);
                break;
            case "3":
                await ConvertSpeechToTextGoogleAsync();
                break;
            default:
                Console.WriteLine("Ungültige Auswahl.");
                break;
        }
    }

    private static void RecordAudio()
    {
        string fileName = "aufnahme.wav";
        var recorder = new AudioRecorder();

        Console.WriteLine("Drücken Sie [Enter], um die Aufnahme zu starten.");
        Console.ReadLine();
        recorder.StartRecording(fileName);
        Console.WriteLine("Aufnahme läuft... Drücken Sie [Enter], um sie zu stoppen.");
        Console.ReadLine();
        recorder.StopRecording();
        Console.WriteLine($"Aufnahme beendet. Datei gespeichert: {fileName}");
    }

    private static async Task<string> ConvertSpeechToTextAzureAsync(string audioFilePath)
    {
        var config = SpeechConfig.FromSubscription(AzureSubscriptionKey, AzureRegion);

        Console.WriteLine("Geben Sie den Sprachcode ein (z. B. 'de-DE' für Deutsch, 'en-US' für Englisch):");
        string languageCode = Console.ReadLine()?.Trim();
        config.SpeechRecognitionLanguage = string.IsNullOrEmpty(languageCode) ? "en-US" : languageCode;

        using var audioInput = AudioConfig.FromWavFileInput(audioFilePath);
        using var recognizer = new SpeechRecognizer(config, audioInput);

        var result = await recognizer.RecognizeOnceAsync();

        if (result.Reason == ResultReason.RecognizedSpeech)
        {
            return result.Text;
        }
        else if (result.Reason == ResultReason.NoMatch)
        {
            Console.WriteLine("Keine Übereinstimmung gefunden.");
        }
        else if (result.Reason == ResultReason.Canceled)
        {
            var cancellation = CancellationDetails.FromResult(result);
            Console.WriteLine($"Erkennung abgebrochen: {cancellation.Reason}");
        }

        return string.Empty;
    }

    private static async Task ConvertSpeechToTextGoogleAsync()
    {
        string apiUrl = $"https://speech.googleapis.com/v1/speech:recognize?key={GoogleApiKey}";

        Console.WriteLine("Geben Sie den Pfad zur Audiodatei ein (Google erwartet WAV-Dateien):");
        string audioFilePath = Console.ReadLine();

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string requestJson = $@"
            {{
                'config': {{
                    'encoding': 'LINEAR16',
                    'sampleRateHertz': 16000,
                    'languageCode': 'en-US'
                }},
                'audio': {{
                    'uri': '{audioFilePath}'
                }}
            }}";

            HttpContent content = new StringContent(requestJson);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Erkannt (Google): " + result);
            }
            else
            {
                Console.WriteLine("Fehler: " + response.StatusCode);
            }
        }
    }
}

public class AudioRecorder
{
    private WaveInEvent waveSource;
    private WaveFileWriter waveFile;

    public void StartRecording(string fileName)
    {
        waveSource = new WaveInEvent();
        waveSource.WaveFormat = new WaveFormat(16000, 1); // 16 kHz, Mono

        waveSource.DataAvailable += (s, e) =>
        {
            if (waveFile != null)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        };

        waveSource.RecordingStopped += (s, e) =>
        {
            waveFile?.Dispose();
            waveFile = null;
            waveSource.Dispose();
        };

        waveFile = new WaveFileWriter(fileName, waveSource.WaveFormat);
        waveSource.StartRecording();
    }

    public void StopRecording()
    {
        waveSource.StopRecording();
    }
}