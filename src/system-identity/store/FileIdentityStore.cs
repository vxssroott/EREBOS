using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Erebos.SystemIdentity.Models;
using Erebos.SystemIdentity.Serialization;
using Erebos.SystemIdentity.Validation;

namespace Erebos.SystemIdentity.Store;

public sealed class FileIdentityStore : IIdentityStore
{
    private readonly string _path;

    public FileIdentityStore(string path)
    {
        _path = path ?? throw new ArgumentNullException(nameof(path));
    }

    public async Task<DeviceIdentity?> LoadAsync(
        CancellationToken cancellationToken = default)
    {
        if (!File.Exists(_path))
            return null;

        string json = await File.ReadAllTextAsync(
            _path,
            cancellationToken);

        var identity = IdentitySerializer.Deserialize(json);

        IdentityValidator.Validate(identity);

        return identity;
    }

    public async Task SaveAsync(
        DeviceIdentity identity,
        CancellationToken cancellationToken = default)
    {
        IdentityValidator.Validate(identity);

        string? directory = Path.GetDirectoryName(_path);

        if (!string.IsNullOrWhiteSpace(directory))
            Directory.CreateDirectory(directory);

        string json = IdentitySerializer.Serialize(identity);

        await File.WriteAllTextAsync(
            _path,
            json,
            cancellationToken);
    }

    public Task DeleteAsync(
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        if (File.Exists(_path))
            File.Delete(_path);

        return Task.CompletedTask;
    }
}
