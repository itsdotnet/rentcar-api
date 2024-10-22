using Microsoft.AspNetCore.Http;
using RentCar.Domain.Entities;

namespace RentCar.Service.Interfaces;

public interface IAttachmentService
{
    Task<bool> DeleteAsync(long id);
    Task<Attachment> UploadAsync(IFormFile Image, string folder);
}
