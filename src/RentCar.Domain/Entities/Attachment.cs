using System;
using RentCar.Domain.Commons;

namespace RentCar.Domain.Entities;

public class Attachment : Auditable
{
    public string Name { get; set; }
    public string Path { get; set; }
}
