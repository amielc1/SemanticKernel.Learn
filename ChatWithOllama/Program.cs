using ChatWithOllama;
using System.Diagnostics;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.WriteLine("Ask a question to Ollama:");
var question = Console.ReadLine();

var ollamaManager = new OllamaManager();
await ollamaManager.TruncatePieShopChatHistoryAsync();

var response = await ollamaManager.AskOllama(question ?? "What is the capital of France?");

Console.WriteLine($"Ollama's response: {response}");

Console.ReadLine();