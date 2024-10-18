using System;
using RentCar.Domain.Commons;

namespace RentCar.Domain.Entities;

public class Book : Auditable
{
    public DateTime PickUpDate { get; set; }

    public long  UserId { get; set; }
    public User User { get; set; }

    public long CarId { get; set; }
    public Car Car { get; set; }

    public long ProviderId { get; set; }
    public Provider Provider { get; set; }
}
