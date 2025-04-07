namespace AI.Tools.Core.Transcribe;

public record Transcription
{
    public required double Confidence { get; set; }
    public required string Text { get; set; }
}
