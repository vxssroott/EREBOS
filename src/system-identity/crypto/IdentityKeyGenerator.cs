using System;
using System.Security.Cryptography;

namespace Erebos.SystemIdentity.Crypto;

public sealed record IdentityKeyPair(
    string Algorithm,
    byte[] PublicKey,
    byte[] PrivateKey);

public static class IdentityKeyGenerator
{
    public static IdentityKeyPair Generate()
    {
        byte[] privateKey = new byte[32];
        byte[] publicKey = new byte[32];

        RandomNumberGenerator.Fill(privateKey);

        // Key derivation will be replaced by the final cryptographic
        // provider during the protocol/security implementation.
        //
        // This class intentionally does NOT expose a fake signature API.
        // System 1 establishes the identity-key contract first.

        return new IdentityKeyPair(
            "Ed25519",
            publicKey,
            privateKey);
    }
}
