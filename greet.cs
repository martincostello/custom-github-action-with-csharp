#!/usr/bin/dotnet run

var name = args.FirstOrDefault() ?? "World";

Console.WriteLine($"Hello {name}!");
