using Deepgram;
using Deepgram.Logger;
using Deepgram.Models.Listen.v1.REST;

namespace AI.Tools.Core.Transcribe;

public class DeepgramService
{
    public static async Task<Transcription> TranscribeAudioAsync(string audioFilePath, string apiKey)
    {
        try
        {
            // Initialize Library with default logging
            // Normal logging is "Info" level
            Library.Initialize(LogLevel.Error);

            // use the client factory with a API Key set with the "DEEPGRAM_API_KEY" environment variable
            var deepgramClient = ClientFactory.CreateListenRESTClient(apiKey);

            // check to see if the file exists
            if (!File.Exists(audioFilePath))
            {
                throw new FileNotFoundException("File not found", audioFilePath);
            }

            var audioData = File.ReadAllBytes(audioFilePath);
            var response = await deepgramClient.TranscribeFile(
                audioData,
                new PreRecordedSchema()
                {
                    Model = "nova-3",
                });

            var alternative = response.Results?.Channels?.FirstOrDefault()?.Alternatives?.FirstOrDefault();
            if (alternative == null)
            {
                throw new InvalidOperationException("No channels or alternatives found in the response.");
            }

            return new Transcription
            {
                Confidence = alternative.Confidence ?? 0.0,
                Text = alternative?.Transcript ?? string.Empty
            };
        }
        finally
        {
            // Teardown Library
            Library.Terminate();
        }
    }
}
