using Microsoft.AspNetCore.Http;

namespace RentCar.Service.DTOs.CarImages;

public class CarImageCreationDto
{
    public long CarId { get; set; }
    public IFormFile Image { get; set; }
}