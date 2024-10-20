using RentCar.Service.DTOs.Providers;

namespace RentCar.Service.DTOs.Cars;

public class CarResultDto
{
    public long Id { get; set; } 
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Description { get; set; }
    public string MileAge { get; set; }
    public int EngineCapacity { get; set; }
    public string Transmission { get; set; }
    public DateTime Release { get; set; }
    public string FuelType { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }   

    public ProviderResultDto Provider { get; set; }
}