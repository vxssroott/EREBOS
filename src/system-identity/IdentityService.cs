using System;
using System.Threading;
using System.Threading.Tasks;
using Erebos.SystemIdentity.Crypto;
using Erebos.SystemIdentity.Models;
using Erebos.SystemIdentity.Store;
using Erebos.SystemIdentity.Validation;

namespace Erebos.SystemIdentity;

public sealed class IdentityService : IIdentityService
{
    private readonly IIdentityStore _store;

    public IdentityService(IIdentityStore store)
    {
        _store = store;
    }

    public async Task<DeviceIdentity> InitializeAsync(
        string displayName,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(displayName))
            throw new ArgumentException(
                "Display name is required.",
                nameof(displayName));

        var existing = await _store.LoadAsync(cancellationToken);

        if (existing is not null)
        {
            if (existing.State == IdentityState.Revoked)
            {
                throw new InvalidOperationException(
                    "A revoked EREBOS identity cannot be silently reinitialized.");
            }

            return existing;
        }

        var identity = new DeviceIdentity(
            IdentityId: IdentityIdGenerator.Generate(),
            SchemaVersion: 1,
            DisplayName: displayName.Trim(),
            CreatedAt: DateTimeOffset.UtcNow,
            PublicKeyAlgorithm: "Ed25519",
            PublicKey: Convert.ToBase64String(
                IdentityKeyGenerator.Generate().PublicKey),
            State: IdentityState.Initialized);

        IdentityValidator.Validate(identity);

        await _store.SaveAsync(identity, cancellationToken);

        return identity;
    }

    public Task<DeviceIdentity?> GetAsync(
        CancellationToken cancellationToken = default)
    {
        return _store.LoadAsync(cancellationToken);
    }

    public async Task<DeviceIdentity> ActivateAsync(
        CancellationToken cancellationToken = default)
    {
        var identity = await RequireIdentity(cancellationToken);

        IdentityLifecycle.EnsureTransition(
            identity.State,
            IdentityState.Active);

        var updated = identity with
        {
            State = IdentityState.Active
        };

        await _store.SaveAsync(updated, cancellationToken);

        return updated;
    }

    public async Task<DeviceIdentity> RevokeAsync(
        CancellationToken cancellationToken = default)
    {
        var identity = await RequireIdentity(cancellationToken);

        IdentityLifecycle.EnsureTransition(
            identity.State,
            IdentityState.Revoked);

        var updated = identity with
        {
            State = IdentityState.Revoked
        };

        await _store.SaveAsync(updated, cancellationToken);

        return updated;
    }

    private async Task<DeviceIdentity> RequireIdentity(
        CancellationToken cancellationToken)
    {
        var identity = await _store.LoadAsync(cancellationToken);

        return identity
            ?? throw new InvalidOperationException(
                "EREBOS device identity has not been initialized.");
    }
}
