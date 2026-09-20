# EREBOS Installation & Development Guide

## Requirements

- Windows
- .NET 8 SDK
- Git
- PowerShell

Verify:

    dotnet --version
    git --version
    $PSVersionTable.PSVersion

## Clone

    git clone <EREBOS_REPOSITORY_URL>
    cd EREBOS

Replace `<EREBOS_REPOSITORY_URL>` with the actual repository URL.

## Build

    dotnet build .\src\system-identity\Erebos.SystemIdentity.csproj

## Test

    dotnet test .\tests\unit\SystemIdentity\Erebos.SystemIdentity.Tests.csproj

The current System 1 checkpoint is:

    Passed: 11
    Failed: 0
    Skipped: 0

## Development Rule

When implementation and test contracts disagree:

1. Inspect the actual source.
2. Identify the authoritative architectural contract.
3. Make the smallest justified change.
4. Rebuild.
5. Run the affected test suite.
6. Review the final diff.

Do not bypass security or identity tests merely to obtain a green build.

## Repository Hygiene

Never commit:

- Private keys
- Credentials
- Access tokens
- Production certificates
- Local machine identifiers
- Deployment secrets
- Build output

## Current Scope

This guide currently documents the System 1 development environment.

Deployment procedures for the persistent agent and ephemeral runtime will be documented after those components are implemented and verified.
