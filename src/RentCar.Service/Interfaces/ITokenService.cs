using RentCar.Domain.Entities;

namespace RentCar.Service.Interfaces;

public interface ITokenService
{
    public string GenerateToken(User user);
}