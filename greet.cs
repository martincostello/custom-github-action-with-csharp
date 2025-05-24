#!/usr/bin/env -S ${DOTNET_ROOT}/dotnet run

var name = args.FirstOrDefault() ?? "World";

Console.WriteLine($"Hello {name}!");
