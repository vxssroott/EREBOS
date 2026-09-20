# Cryptographic Provider

System 1 now requires the real .NET Ed25519 cryptographic implementation.

The identity layer provides:

- Ed25519 key generation
- Ed25519 signing
- Ed25519 verification
- SHA-256 public-key fingerprinting

The private key is intentionally not serialized into the DeviceIdentity model.

## Acceptance Requirements

- [x] Real Ed25519 key generation
- [x] Valid public/private key relationship
- [x] Signature generation
- [x] Signature verification
- [x] Modified-message rejection
- [x] Wrong-key rejection
- [x] Public-key fingerprinting
- [x] Identity lifecycle
- [x] Identity validation
- [x] Identity persistence contract

## Remaining Production Hardening

Protected private-key storage remains a platform-integration concern.

The final Windows implementation should bind persistent private-key material
to an appropriate protected OS key store and/or hardware-backed mechanism
where available.

This is distinct from cryptographic correctness.

System 1 can therefore be cryptographically verified while platform key
storage remains a subsequent hardening task.
