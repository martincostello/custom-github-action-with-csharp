#!/usr/bin/env dotnet

var path = Environment.GetEnvironmentVariable("GITHUB_OUTPUT") ?? "roll.txt";
var roll = Random.Shared.Next(1, 7);

await File.WriteAllTextAsync(path, $"roll={roll}");
