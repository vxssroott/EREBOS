using System;
using Erebos.SystemIdentity.Crypto;
using Xunit;

namespace Erebos.Tests.SystemIdentity;

public sealed class IdentityIdTests
{
    [Fact]
    public void GeneratedIdentityId_Is128Bits()
    {
        var id = IdentityIdGenerator.Generate();

        Assert.Equal(32, id.Length);
        Assert.Matches("^[0-9a-f]{32}$", id);
    }

    [Fact]
    public void GeneratedIdentityIds_AreNotIdentical()
    {
        var first = IdentityIdGenerator.Generate();
        var second = IdentityIdGenerator.Generate();

        Assert.NotEqual(first, second);
    }
}
