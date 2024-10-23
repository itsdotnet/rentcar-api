using System;
using Microsoft.AspNetCore.Http;
using RentCar.Service.DTOs.CarImages;

namespace RentCar.Service.Interfaces;

public interface ICarImageService
{
    Task<bool> DeleteAsync(long id);
    Task<bool> DeleteRangeAsync(long carId);
    Task<CarImageResultDto> GetByIdAsync(long id);
    Task<IEnumerable<CarImageResultDto>> GetByCarIdAsync(long carId);
    Task<IEnumerable<CarImageResultDto>> GetAllAsync();
    Task<CarImageResultDto> CreateAsync(CarImageCreationDto dto);
    Task<IEnumerable<CarImageResultDto>> CreateRangeAsync(long carId, List<IFormFile> images);
}
