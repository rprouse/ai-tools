using Deepgram;
using Deepgram.Models.Listen.v1.REST;

namespace ai.core;

public class DeepgramService
{
    public static async Task<string> TranscribeAudioAsync(string audioFilePath, string apiKey)
    {
        try
        {
            // Initialize Library with default logging
            // Normal logging is "Info" level
            Library.Initialize();

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

            return response.ToString();
        }
        finally
        {
            // Teardown Library
            Library.Terminate();
        }
    }
}
