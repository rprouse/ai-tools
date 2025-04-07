var key = Environment.GetEnvironmentVariable("DEEPGRAM_API_KEY");
if (string.IsNullOrEmpty(key))
{
    throw new InvalidOperationException("The DEEPGRAM_API_KEY environment variable is not set.");
}
var file = @"D:\src\Manos\DentaScribe\DentaScribe.Server\Audio\scottish_dentist.mp3";

string response = await ai.core.DeepgramService.TranscribeAudioAsync(file, key);

Console.WriteLine(response);


