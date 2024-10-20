namespace RentCar.Service.DTOs.Users;

public class UserCreationDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Confirm { get; set; }
}