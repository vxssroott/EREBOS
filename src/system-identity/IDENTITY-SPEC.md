# EREBOS System Identity

## Purpose

System Identity is the root identity domain for an EREBOS device.

It answers:

- Who is this device?
- What cryptographic identity represents it?
- What lifecycle state is the identity in?
- How is identity persisted?
- How is identity serialized?
- How can another subsystem safely consume it?

## Identity Model

A device identity consists of:

- Identity ID
- Schema version
- Display name
- Creation timestamp
- Public identity key
- Key algorithm
- Identity state
- Metadata

The private key is never part of the serialized public identity document.

## Lifecycle

UNINITIALIZED
    ↓
INITIALIZED
    ↓
ACTIVE
    ↓
REVOKED

The implementation must not silently resurrect a revoked identity.

## Design Boundary

System Identity establishes identity.

It does not yet implement:

- Network discovery
- Peer discovery
- Transport
- Session establishment
- Remote control
- File transfer
- Process control
- Terminal execution

Those belong to later numbered systems.

## Security Principle

MAC addresses, IP addresses and hostnames are descriptive network attributes.
They are not the cryptographic identity of an EREBOS device.
