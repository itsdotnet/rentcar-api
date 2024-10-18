using System;
using System.Diagnostics.Contracts;
using RentCar.Domain.Commons;

namespace RentCar.Domain.Entities;

public class CarImage : Auditable
{
    public long CarId { get; set; }
    public Car Car { get; set; }

    public long AttachmentId { get; set; }
    public Attachment Attachment { get; set; }
}
