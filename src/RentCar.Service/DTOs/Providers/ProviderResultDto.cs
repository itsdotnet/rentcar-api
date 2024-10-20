using RentCar.Domain.Enums;

namespace RentCar.Service.DTOs.Providers;

public class ProviderResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get ; set; }
    public float Longitude { get; set; }
    public float Latitude { get; set; }
    public Day Start { get; set; }
    public Day End { get; set; }
}