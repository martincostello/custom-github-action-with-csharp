# Custom GitHub Action with C#

[![Build status][build-badge]][build-status]

An example of writing a simple custom GitHub Action with C#.

## Introduction

This repository contains a simple example of a custom GitHub Action written in C#.

It uses the .NET 10 SDK to run C# applications with a single `.cs` file.

See [📺 _No projects just C# with `dotnet run app.cs`_][demo-talk] by [@DamianEdwards][damian-edwards] for more information.

## Usage

To use this action in a workflow to try it out, you can create [a workflow like this][demo-workflow]:

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

## How it works

The action is implemented as a [composite action][composite-action] for GitHub Actions.

Using the ability to run a .NET application directly from a single `.cs` file, added in .NET 10, you
can write a custom GitHub Action written in C# without needing to create a project or compile it in advance.

This means you can use C# and .NET in a lightweight manner, only needing to install the .NET 10+ SDK before use.

> [!NOTE]
> These snippets use PowerShell as the shell for cross-platform compatibility so that they
> work on macOS, Linux and Windows, but you could use any shell supported by GitHub Actions.

First the action installs the .NET 10 SDK:

```yaml
- uses: actions/setup-dotnet@v4
  with:
    dotnet-version: '10.0.x'
```

Finally it executes the relevant C# code file to execute the custom application that is the core action functionality.

```yaml
- shell: pwsh
  run: |
    & (Join-Path $env:GITHUB_ACTION_PATH "roll-dice.cs")
```

> [!NOTE]
> The [`GITHUB_ACTION_PATH` environment variable][github-actions-environment-vars] is used to find the `.cs` file to run.

The C# files themselves contain [a shebang][shebang] at the top to indicate they should be run with the .NET SDK:

```csharp
#!/usr/bin/env -S ${DOTNET_ROOT}/dotnet run
```

This shebang is specific to use in GitHub Actions and uses the `${DOTNET_ROOT}` environment variable to find the version
of the `dotnet` executable installed by the [`actions/setup-dotnet` action][setup-dotnet] so that the correct version is
used to execute the file.

> [!TIP]
> Ensure that any `.cs` files have executable permissions set so that they can be run directly in a shell on non-Windows platforms.

[build-badge]: https://github.com/martincostello/custom-github-action-with-csharp/actions/workflows/test.yml/badge.svg?branch=main&event=push
[build-status]: https://github.com/martincostello/custom-github-action-with-csharp/actions?query=workflow%3Atest+branch%3Amain+event%3Apush "Continuous Integration for this project"
[composite-action]: https://docs.github.com/actions/sharing-automations/creating-actions/creating-a-composite-action "Creating a composite action"
[damian-edwards]: https://github.com/DamianEdwards "Damian Edwards on GitHub"
[demo-talk]: https://youtu.be/98MizuB7i-w "No projects just C# with dotnet run app.cs - YouTube"
[demo-workflow]: https://github.com/martincostello/custom-github-action-with-csharp/blob/main/.github/workflows/demo.yml
[github-actions-environment-vars]: https://docs.github.com/actions/writing-workflows/choosing-what-your-workflow-does/store-information-in-variables#default-environment-variables "Store information in variables - Default environment variables"
[setup-dotnet]: https://github.com/actions/setup-dotnet "The setup-dotnet GitHub Action"
[shebang]: https://en.wikipedia.org/wiki/Shebang_(Unix) "Shebang (Unix)"
