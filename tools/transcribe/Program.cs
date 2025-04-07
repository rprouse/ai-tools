using Spectre.Console.Cli;
using AI.Tools.Transcribe;

// Setup command line app
var app = new CommandApp<TranscribeCommand>();
return await app.RunAsync(args);
