using System;
using RentCar.Domain.Commons;

namespace RentCar.Domain.Entities;

public class User : Auditable
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
