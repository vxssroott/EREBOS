using System;
using System.Security.Cryptography;

namespace Erebos.SystemIdentity.Crypto;

public static class IdentityFingerprint
{
    public static string Compute(ReadOnlySpan<byte> publicKey)
    {
        byte[] digest = SHA256.HashData(publicKey);

        return Convert.ToHexString(digest)
            .ToLowerInvariant();
    }
}
