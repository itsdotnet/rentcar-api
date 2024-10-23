using RentCar.Service.DTOs.Users;

namespace RentCar.Service.Interfaces;

public interface IIdentityService
{
    Task<string> CurrentRole();
    Task<UserResultDto> CurrentUser();
    Task<bool> UpgradeRole(long userId);
    Task<bool> DowngradeRole(long userId);
}
