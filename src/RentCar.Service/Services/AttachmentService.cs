using Microsoft.AspNetCore.Http;
using RentCar.Data.Repositories;
using RentCar.Domain.Entities;
using RentCar.Service.Exceptions;
using RentCar.Service.Extensions;
using RentCar.Service.Helpers;
using RentCar.Service.Interfaces;

namespace RentCar.Service.Services;

public class AttachmentService : IAttachmentService
{
    private readonly IRepository<Attachment> _attachmentRepository;

    public AttachmentService(IRepository<Attachment> repository)
    {
        _attachmentRepository = repository;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var attachment = await _attachmentRepository.SelectAsync(x => x.Id == id);

        if (attachment is null)
            throw new NotFoundException("Attachment not found");

        await _attachmentRepository.DeleteAsync(x => x == attachment);
        await _attachmentRepository.SaveAsync();

        return true;
    }

    public async Task<Attachment> UploadAsync(IFormFile Image, string folder)
    {
        var webrootPath = Path.Combine(PathHelper.WebRootPath, folder);

        if (!Directory.Exists(webrootPath))
            Directory.CreateDirectory(webrootPath);

        var fileName = "";

        fileName = MediaHelper.MakeImageName(Image.FileName);
        
        var fullPath = Path.Combine(webrootPath, fileName);

        var fileStream = new FileStream(fullPath, FileMode.OpenOrCreate);
        await fileStream.WriteAsync(Image.ToByte());

        var createdAttachment = new Attachment
        {
            Name = fileName,
            Path = fullPath
        };

        await _attachmentRepository.AddAsync(createdAttachment);
        await _attachmentRepository.SaveAsync();

        return createdAttachment;
    }
}
