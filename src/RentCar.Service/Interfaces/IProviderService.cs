using System;
using RentCar.Service.DTOs.Providers;

namespace RentCar.Service.Interfaces;

public interface IProviderService
{
    Task<bool> DeleteAsync(long id);
    Task<ProviderResultDto> GetByIdAsync(long id);
    Task<IEnumerable<ProviderResultDto>> GetAllAsync();
    Task<ProviderResultDto> UpdateAsync(ProviderUpdateDto dto);
    Task<ProviderResultDto> CreateAsync(ProviderCreationDto dto);
}
