using System.Threading;
using System.Threading.Tasks;
using Erebos.SystemIdentity.Models;

namespace Erebos.SystemIdentity.Store;

public interface IIdentityStore
{
    Task<DeviceIdentity?> LoadAsync(
        CancellationToken cancellationToken = default);

    Task SaveAsync(
        DeviceIdentity identity,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        CancellationToken cancellationToken = default);
}
