using System.Threading;
using System.Threading.Tasks;
using Erebos.SystemIdentity.Models;

namespace Erebos.SystemIdentity;

public interface IIdentityService
{
    Task<DeviceIdentity> InitializeAsync(
        string displayName,
        CancellationToken cancellationToken = default);

    Task<DeviceIdentity?> GetAsync(
        CancellationToken cancellationToken = default);

    Task<DeviceIdentity> ActivateAsync(
        CancellationToken cancellationToken = default);

    Task<DeviceIdentity> RevokeAsync(
        CancellationToken cancellationToken = default);
}
