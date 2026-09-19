using System;
using Erebos.SystemIdentity.Models;

namespace Erebos.SystemIdentity.Validation;

public static class IdentityValidator
{
    public static void Validate(DeviceIdentity identity)
    {
        if (string.IsNullOrWhiteSpace(identity.IdentityId))
            throw new ArgumentException("Identity ID is required.");

        if (identity.IdentityId.Length != 32)
            throw new ArgumentException(
                "Identity ID must contain 128 bits represented as 32 hex characters.");

        if (identity.SchemaVersion <= 0)
            throw new ArgumentException("Invalid identity schema version.");

        if (string.IsNullOrWhiteSpace(identity.DisplayName))
            throw new ArgumentException("Display name is required.");

        if (identity.CreatedAt == default)
            throw new ArgumentException("Creation timestamp is required.");

        if (string.IsNullOrWhiteSpace(identity.PublicKeyAlgorithm))
            throw new ArgumentException("Public key algorithm is required.");

        if (string.IsNullOrWhiteSpace(identity.PublicKey))
            throw new ArgumentException("Public key is required.");

        if (identity.State == IdentityState.Uninitialized)
            throw new ArgumentException(
                "A persisted identity cannot remain uninitialized.");
    }
}
