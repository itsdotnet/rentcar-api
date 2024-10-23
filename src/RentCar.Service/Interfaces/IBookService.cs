using Microsoft.AspNetCore.Http;
using RentCar.Service.DTOs.Booking;

namespace RentCar.Service.Interfaces;

public interface IBookService
{
    Task<bool> DeleteAsync(long id);
    Task<bool> DeleteRangeByUserAsync(long userId);
    Task<bool> DeleteRangeByProviderAsync(long providerId);
    Task<BookResultDto> GetByIdAsync(long id);
    Task<IEnumerable<BookResultDto>> GetByUserIdAsync(long userId);
    Task<IEnumerable<BookResultDto>> GetByProviderIdAsync(long providerId);
    Task<IEnumerable<BookResultDto>> GetAllAsync();
    Task<BookResultDto> CreateAsync(BookCreationDto dto);
}