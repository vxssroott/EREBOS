using Erebos.SystemIdentity.Models;
using Xunit;

namespace Erebos.Tests.SystemIdentity;

public sealed class IdentityLifecycleTests
{
    [Fact]
    public void Initialized_CanBecome_Active()
    {
        Assert.True(
            IdentityLifecycle.CanTransition(
                IdentityState.Initialized,
                IdentityState.Active));
    }

    [Fact]
    public void Active_CanBecome_Revoked()
    {
        Assert.True(
            IdentityLifecycle.CanTransition(
                IdentityState.Active,
                IdentityState.Revoked));
    }

    [Fact]
    public void Revoked_CannotBecome_Active()
    {
        Assert.False(
            IdentityLifecycle.CanTransition(
                IdentityState.Revoked,
                IdentityState.Active));
    }

    [Fact]
    public void Revoked_CannotBecome_Initialized()
    {
        Assert.False(
            IdentityLifecycle.CanTransition(
                IdentityState.Revoked,
                IdentityState.Initialized));
    }
}
