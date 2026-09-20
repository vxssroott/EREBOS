# EREBOS

**Ephemeral Remote Execution & Boundary Orchestration System**

EREBOS is a Windows-to-Windows remote desktop and control platform centered on ephemeral remote execution, persistent device identity, explicit capability boundaries, strong cryptographic trust, and verifiable session state.

EREBOS is not described as "zero-install". Its design objective is ephemeral execution with a minimal persistent trust and presence foundation.

## Architecture

1. Persistent Identity & Presence Agent
2. Capability Broker
3. Ephemeral Remote Desktop Runtime

## Protocol Plan

- Control Plane
- Data Plane
- Media Plane
- Audit Plane

## Security Principles

- Persistent trust is separated from ephemeral execution.
- Controller authority cannot exceed the enrolled device policy ceiling.
- Remote execution does not imply SYSTEM authority.
- Capabilities are explicit and attenuated.
- Session transitions are modeled explicitly.
- Security-sensitive actions should be auditable.
- Cryptographic identity is established before remote control.
- AI is not part of the MVP security decision path.

## Current Status

### System 1 — Identity

- Ed25519 identity generation
- Public/private key validation
- Identity API foundation
- Automated unit tests
- 11/11 tests passing

## Development

See `INSTALL.md`.

## Security

See `SECURITY.md`.

## License

See `LICENSE`.

> EREBOS is under active engineering development. Interfaces and implementation details may change until the corresponding specifications are stabilized.
