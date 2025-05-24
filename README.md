# Custom GitHub Action with C#

[![Build status][build-badge]][build-status]

An example of writing a simple custom GitHub Action with C#.

## Introduction

This repository contains a simple example of a custom GitHub Action written with C#.

It uses the .NET 10 SDK run C# applications from a single file.

See [📺 _No projects just C# with `dotnet run app.cs`_][demo] by [@DamianEdwards][damian-edwards] for more information.

## Usage

To use this action in a workflow to try it out, you can create a workflow like this:

```yaml
on: [push]

jobs:
  csharp-action:
    runs-on: ubuntu-latest

    steps:
      - name: Use custom C# action
        uses: martincostello/custom-github-action-with-csharp@main
        id: csharp
        with:
          who-to-greet: ${{ github.triggering_actor }}

      - name: Display dice roll
        env:
          ROLLED: ${{ steps.csharp.outputs.rolled }}
        shell: bash
        run: echo "You rolled $ROLLED"
```

[build-badge]: https://github.com/martincostello/custom-github-action-with-csharp/actions/workflows/test.yml/badge.svg?branch=main&event=push
[build-status]: https://github.com/martincostello/custom-github-action-with-csharp/actions?query=workflow%3Atest+branch%3Amain+event%3Apush "Continuous Integration for this project"
[damian-edwards]: https://github.com/DamianEdwards "Damian Edwards on GitHub"
[demo]: https://youtu.be/98MizuB7i-w "No projects just C# with dotnet run app.cs - YouTube"
