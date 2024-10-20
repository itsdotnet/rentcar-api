using RentCar.Service.DTOs.Attachments;

namespace RentCar.Service.DTOs.CarImages;

public class CarImageResultDto
{
    public long Id { get; set; }
    public long CarId { get; set; }
    public AttachmentResultDto Image { get; set; }
}