using RentCar.Service.DTOs.Cars;

namespace RentCar.Service.Interfaces;

public interface ICarService
{
    Task<bool> DeleteAsync(long id);
    Task<CarResultDto> GetByIdAsync(long id);
    Task<IEnumerable<CarResultDto>> GetAllAsync();
    Task<CarResultDto> UpdateAsync(CarUpdateDto dto);
    Task<CarResultDto> CreateAsync(CarCreationDto dto);
    Task<IEnumerable<CarResultDto>> GetByProviderIdAsync(long providerId);
}
