namespace RentCar.Service.DTOs.Booking;

public class BookUpdateDto
{
    public long Id { get; set; }
    public DateTime PickUpDate { get; set; }
    public long  UserId { get; set; }
    public long CarId { get; set; }
    public long ProviderId { get; set; }
}
