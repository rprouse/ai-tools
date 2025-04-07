# GitHub Copilot Instructions

This document provides information about coding conventions, dependencies, and other useful details for GitHub Copilot or other AI agents working on this codebase.

## Project Structure

This solution contains AI-related tools and utilities, located in `d:\src\ai\ai-tools`.

## Coding Conventions

- Follow C# coding conventions as outlined in the [Microsoft C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Use 4 spaces for indentation
- Use PascalCase for class names, public methods, and properties
- Use camelCase for local variables and parameters
- Use descriptive variable and method names that clearly communicate intent
- Include XML documentation for public APIs
- Follow the principle of "Clean Code" - methods should be small and have a single responsibility
- Use async/await pattern for asynchronous operations
- Use LINQ for collection operations where appropriate

## NuGet Packages

The solution uses the following NuGet packages:

- Spectre.Console (for rich command line output and colors)
- Spectre.Console.CLI (for processing command line options)

## Error Handling

- Use try-catch blocks strategically, not for flow control
- Write exceptions to the console using Spectre.Console
- Validate inputs at method boundaries

## Testing

- Unit tests should be written using NUnit
- Follow the Arrange-Act-Assert pattern
- Mock external dependencies using Moq
- Aim for high test coverage, especially for business logic

## Git Workflow

- Use feature branches for new features
- Format commit messages following conventional commits style:
  - feat: for new features
  - fix: for bug fixes
  - docs: for documentation changes
  - refactor: for refactoring code
  - test: for adding tests
  - chore: for maintenance tasks
- Create pull requests for code reviews before merging
