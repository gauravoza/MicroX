namespace MicroX.Domain.Entities;

public class ServiceInfo
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Status { get; set; } = "Unknown"; // e.g., Healthy, Degraded
    public DateTime LastChecked { get; set; } = DateTime.UtcNow;
}
