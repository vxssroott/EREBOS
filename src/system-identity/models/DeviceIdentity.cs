using System;

namespace Erebos.SystemIdentity.Models;

public enum IdentityState
{
    Uninitialized = 0,
    Initialized = 1,
    Active = 2,
    Revoked = 3
}

public sealed record DeviceIdentity(
    string IdentityId,
    int SchemaVersion,
    string DisplayName,
    DateTimeOffset CreatedAt,
    string PublicKeyAlgorithm,
    string PublicKey,
    IdentityState State
);
