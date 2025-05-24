# Custom GitHub Action with C#

An example of writing a simple custom GitHub Action with C#.

## Introduction

This repository contains a simple example of a custom GitHub Action written in C#.

It requires at least .NET 10 and uses the [dotnet-cs](https://github.com/DamianEdwards/csrun)
global tool to run inline C# code.

See [_No projects just C# with `dotnet run app.cs`_](https://youtu.be/98MizuB7i-w)
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
        with:
          who-to-greet: github.triggering_actor

      - name: Display dice roll
        env:
          ROLLED: ${{ steps.csharp.outputs.rolled }}
        shell: bash
        run: echo "You rolled $ROLLED"
```
