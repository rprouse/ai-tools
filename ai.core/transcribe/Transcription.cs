namespace ai.core.transcribe;

public record Transcription
{
    public required double Confidence { get; set; }
    public required string Text { get; set; }
}
