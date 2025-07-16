#!/usr/bin/env dotnet

var name = args.FirstOrDefault() ?? "World";

Console.WriteLine($"Hello {name}!");
