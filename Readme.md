# AI Tools

A collection of AI-related tools and utilities for audio transcription and other AI tasks.

## Overview

This solution contains a set of command line AI-related tools and utilities. The solution is structured into a core library and various tool applications.

## Project Structure

- **AI.Core**: Core library containing shared functionality and services
- **Tools**: Collection of command-line tools
  - **Transcribe**: Command-line tool for audio transcription

## Getting Started

### Prerequisites

- .NET 9.0 SDK or later
- API key for Deepgram (for transcription functionality)

### Installation

1. Clone the repository
   ```
   git clone <repository-url>
   cd ai-tools
   ```

2. Build the solution
   ```
   dotnet build
   ```

3. Run the transcribe tool
   ```
   dotnet run --project Tools/Transcribe/Transcribe.csproj -- [options]
   ```

## Transcribe Tool

The Transcribe tool allows you to convert audio files to text using the Deepgram API.

### Usage

```
dotnet run --project Tools/Transcribe/Transcribe.csproj -- [options] <file>
```

### Options

- `--help`: Display help information
- `--file <path>`: Specify input audio file path

## Development

### Adding New Tools

1. Create a new project in the Tools directory
2. Reference the AI.Core project for shared functionality
3. Implement the command using Spectre.Console.CLI

### Dependencies

- Spectre.Console: For rich command-line output and colors
- Spectre.Console.CLI: For command-line option processing
- Deepgram SDK: For audio transcription

## License

[MIT](LICENSE)

## Contributing

Contributions are welcome. Please follow the coding conventions outlined in the `.github/copilot-instructions.md` file.
