# Custom GitHub Action with C#

[![Build status][build-badge]][build-status]

An example of writing a simple custom GitHub Action with C#.

## Introduction

This repository contains a simple example of a custom GitHub Action written in C#.

It uses the .NET 10 SDK and the [dotnet-cs](https://github.com/DamianEdwards/csrun) global tool to run inline C# code.

See [📺 _No projects just C# with `dotnet run app.cs`_](https://youtu.be/98MizuB7i-w)
by [@DamianEdwards](https://github.com/DamianEdwards) for more information.

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
