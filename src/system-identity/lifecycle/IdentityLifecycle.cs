using System;

namespace Erebos.SystemIdentity.Models;

public static class IdentityLifecycle
{
    public static bool CanTransition(
        IdentityState current,
        IdentityState next)
    {
        return (current, next) switch
        {
            (IdentityState.Uninitialized, IdentityState.Initialized) => true,
            (IdentityState.Initialized, IdentityState.Active) => true,
            (IdentityState.Active, IdentityState.Revoked) => true,

            // Revocation is terminal.
            (IdentityState.Revoked, _) => false,

            _ => false
        };
    }

    public static void EnsureTransition(
        IdentityState current,
        IdentityState next)
    {
        if (!CanTransition(current, next))
        {
            throw new InvalidOperationException(
                $"Invalid identity transition: {current} -> {next}");
        }
    }
}
