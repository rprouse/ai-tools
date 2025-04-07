using AI.Tools.Core.Transcribe;
using Spectre.Console;
using Spectre.Console.Cli;

namespace AI.Tools.Transcribe;

public class TranscribeCommand : Command<TranscribeCommand.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandArgument(0, "[filePath]")]
        public string? FilePath { get; set; }

        [CommandOption("-f|--file")]
        public string? FileOption { get; set; }
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        return ExecuteAsync(context, settings).GetAwaiter().GetResult();
    }

    public async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        // Get the API key
        var key = Environment.GetEnvironmentVariable("DEEPGRAM_API_KEY");
        if (string.IsNullOrEmpty(key))
        {
            AnsiConsole.MarkupLine("[red]The DEEPGRAM_API_KEY environment variable is not set.[/]");
            return 1;
        }

        // Get the file path
        string? filePath = settings.FilePath ?? settings.FileOption;
        if (string.IsNullOrEmpty(filePath))
        {
            AnsiConsole.MarkupLine("[red]Please provide an audio file path.[/]");
            return 1;
        }

        // Validate file exists
        if (!File.Exists(filePath))
        {
            AnsiConsole.MarkupLine($"[red]File not found: {filePath}[/]");
            return 1;
        }

        // Transcribe the audio
        Transcription response = await DeepgramService.TranscribeAudioAsync(filePath, key);
        AnsiConsole.WriteLine(response.Text);

        return 0;
    }
}


