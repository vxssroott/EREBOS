using System.Text;
using Erebos.SystemIdentity.Crypto;
using Xunit;

namespace Erebos.Tests.SystemIdentity;

public sealed class Ed25519Tests
{
    [Fact]
    public void GeneratedKeyPair_HasExpectedLengths()
    {
        var keyPair = IdentityKeyGenerator.Generate();

        Assert.Equal(IdentityKeyGenerator.Algorithm, "Ed25519");
        Assert.Equal(32, keyPair.PublicKey.Length);
        Assert.Equal(32, keyPair.PrivateKey.Length);
    }

    [Fact]
    public void Signature_VerifiesWithMatchingPublicKey()
    {
        var keyPair = IdentityKeyGenerator.Generate();

        byte[] message = Encoding.UTF8.GetBytes(
            "EREBOS SYSTEM IDENTITY");

        byte[] signature = IdentityKeyGenerator.Sign(
            message,
            keyPair.PrivateKey);

        Assert.Equal(64, signature.Length);

        Assert.True(
            IdentityKeyGenerator.Verify(
                message,
                signature,
                keyPair.PublicKey));
    }

    [Fact]
    public void Signature_FailsForModifiedMessage()
    {
        var keyPair = IdentityKeyGenerator.Generate();

        byte[] message = Encoding.UTF8.GetBytes(
            "EREBOS SYSTEM IDENTITY");

        byte[] modified = Encoding.UTF8.GetBytes(
            "EREBOS SYSTEM IDENTITX");

        byte[] signature = IdentityKeyGenerator.Sign(
            message,
            keyPair.PrivateKey);

        Assert.False(
            IdentityKeyGenerator.Verify(
                modified,
                signature,
                keyPair.PublicKey));
    }

    [Fact]
    public void Signature_FailsForDifferentKey()
    {
        var first = IdentityKeyGenerator.Generate();
        var second = IdentityKeyGenerator.Generate();

        byte[] message = Encoding.UTF8.GetBytes(
            "EREBOS SYSTEM IDENTITY");

        byte[] signature = IdentityKeyGenerator.Sign(
            message,
            first.PrivateKey);

        Assert.False(
            IdentityKeyGenerator.Verify(
                message,
                signature,
                second.PublicKey));
    }

    [Fact]
    public void PublicKeyFingerprint_IsStable()
    {
        var keyPair = IdentityKeyGenerator.Generate();

        string first =
            IdentityFingerprint.Compute(keyPair.PublicKey);

        string second =
            IdentityFingerprint.Compute(keyPair.PublicKey);

        Assert.Equal(first, second);
        Assert.Equal(64, first.Length);
    }
}

