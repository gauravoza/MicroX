namespace MicroX.Contracts.DTOs;

public class ServiceInfoDto
{
    public string Name { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Status { get; set; } = "Unknown";
    public DateTime LastChecked { get; set; } = DateTime.UtcNow;
}