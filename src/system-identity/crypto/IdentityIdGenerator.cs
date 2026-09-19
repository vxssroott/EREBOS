using System;
using System.Security.Cryptography;

namespace Erebos.SystemIdentity.Crypto;

public static class IdentityIdGenerator
{
    public static string Generate()
    {
        Span<byte> bytes = stackalloc byte[16];

        RandomNumberGenerator.Fill(bytes);

        return Convert.ToHexString(bytes).ToLowerInvariant();
    }
}
