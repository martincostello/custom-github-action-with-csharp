#!/usr/bin/env -S ${DOTNET_ROOT}/dotnet run

var path = Environment.GetEnvironmentVariable("GITHUB_OUTPUT") ?? "roll.txt";
var roll = Random.Shared.Next(1, 7);

await File.WriteAllTextAsync(path, $"roll={roll}");
