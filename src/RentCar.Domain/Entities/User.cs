using System;
using RentCar.Domain.Commons;
using RentCar.Domain.Enums;

namespace RentCar.Domain.Entities;

public class User : Auditable
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
}
