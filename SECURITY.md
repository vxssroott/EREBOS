# EREBOS Security Policy

## Security Model

EREBOS is designed around explicit trust boundaries:

Persistent Identity → Capability Authorization → Ephemeral Execution

A remote controller must not automatically acquire privileges beyond the policy ceiling established by the target device.

## Core Security Properties

### Device-Bounded Authority

The enrolled device establishes the maximum authority available to remote sessions.

A compromised controller must not be able to negotiate privileges above that ceiling.

### Least Privilege

The ephemeral remote desktop runtime is not intended to execute as SYSTEM.

Privileged operations are mediated through an explicit capability boundary.

### Cryptographic Identity

The current System 1 identity primitive is Ed25519.

### Explicit Session State

Remote sessions are intended to operate through an explicit state machine.

### Auditability

Security-sensitive operations should produce structured audit evidence sufficient to reconstruct important session decisions.

## Threat Model

Relevant threats include:

- Compromised controller software
- Stolen session credentials
- Unauthorized enrollment
- Replay attacks
- Capability escalation
- Confused-deputy behavior
- Compromised ephemeral runtime
- Malformed protocol input
- Unauthorized persistence
- Audit tampering
- Denial-of-service

## Security Reporting

Security vulnerabilities should not be publicly disclosed before coordinated remediation is possible.

Use the repository's configured security contact or security advisory mechanism for private reports.

Do not include unnecessary secrets or personal information in vulnerability reports.

## Cryptographic Policy

EREBOS must not invent cryptographic primitives.

Established cryptographic implementations should be used and protocol decisions must be documented.

## Security Claims

Documentation must distinguish between:

- Implemented controls
- Designed controls
- Planned controls
- Security assumptions

A security property must not be described as implemented until corresponding implementation and verification evidence exists.
