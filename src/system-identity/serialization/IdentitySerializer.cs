using System.Text.Json;
using Erebos.SystemIdentity.Models;

namespace Erebos.SystemIdentity.Serialization;

public static class IdentitySerializer
{
    public static string Serialize(DeviceIdentity identity)
    {
        return JsonSerializer.Serialize(
            identity,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });
    }

    public static DeviceIdentity Deserialize(string json)
    {
        return JsonSerializer.Deserialize<DeviceIdentity>(json)
            ?? throw new JsonException("Invalid EREBOS device identity.");
    }
}
