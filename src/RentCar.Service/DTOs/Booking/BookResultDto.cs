using RentCar.Service.DTOs.Cars;
using RentCar.Service.DTOs.Providers;
using RentCar.Service.DTOs.Users;

namespace RentCar.Service.DTOs.Booking;

public class BookResultDto
{
    public long Id { get; set; }
    public DateTime PickUpDate { get; set; }
    public UserResultDto User { get; set; }
    public CarResultDto Car { get; set; }
    public ProviderResultDto Provider { get; set; }
}