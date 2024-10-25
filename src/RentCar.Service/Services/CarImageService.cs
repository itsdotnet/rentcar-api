using AutoMapper;
using Microsoft.AspNetCore.Http;
using RentCar.Data.UnitOfWorks;
using RentCar.Domain.Entities;
using RentCar.Service.DTOs.CarImages;
using RentCar.Service.Exceptions;
using RentCar.Service.Interfaces;

namespace RentCar.Service.Services;

public class CarImageService : ICarImageService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAttachmentService _attachmentService;

    public CarImageService(IUnitOfWork unitOfWork, IMapper mapper, IAttachmentService attachmentService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _attachmentService = attachmentService;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var carImage = await _unitOfWork.CarImageRepository.SelectAsync(q => q.Id == id);
        if (carImage == null)
            throw new NotFoundException("Car image not found.");

        await _unitOfWork.CarImageRepository.DeleteAsync(x => x.Id == id);
        return await _unitOfWork.SaveAsync();
    }

    public async Task<bool> DeleteRangeAsync(long carId)
    {
        var carImages = _unitOfWork.CarImageRepository.SelectAll(q => q.CarId == carId);
        if (!carImages.Any())
            throw new NotFoundException("No car images found for this car.");

        foreach (var carImage in carImages)
        {
            await _unitOfWork.CarImageRepository.DeleteAsync(x => x.Id == carImage.Id);
        }

        return await _unitOfWork.SaveAsync();
    }


    public async Task<CarImageResultDto> GetByIdAsync(long id)
    {
        var carImage = await _unitOfWork.CarImageRepository.SelectAsync(q => q.Id == id);
        if (carImage == null)
            throw new NotFoundException("Car image not found.");

        return _mapper.Map<CarImageResultDto>(carImage);
    }

    public async Task<IEnumerable<CarImageResultDto>> GetByCarIdAsync(long carId)
    {
        var carImages = _unitOfWork.CarImageRepository.SelectAll(q => q.CarId == carId);
        return _mapper.Map<IEnumerable<CarImageResultDto>>(carImages);
    }

    public async Task<IEnumerable<CarImageResultDto>> GetAllAsync()
    {
        var carImages = _unitOfWork.CarImageRepository.SelectAll();
        return _mapper.Map<IEnumerable<CarImageResultDto>>(carImages);
    }

    public async Task<CarImageResultDto> CreateAsync(CarImageCreationDto dto)
    {
        var attachment = await _attachmentService.UploadAsync(dto.Image, "CarImage");
        var carImage = new CarImage
        {
            CarId = dto.CarId,
            AttachmentId = attachment.Id 
        };

        await _unitOfWork.CarImageRepository.AddAsync(carImage);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<CarImageResultDto>(carImage);
    }

    public async Task<IEnumerable<CarImageResultDto>> CreateRangeAsync(long carId, List<IFormFile> images)
    {
        var carImages = new List<CarImage>();

        foreach (var image in images)
        {
            var attachment = await _attachmentService.UploadAsync(image, "CarImage");
            var carImage = new CarImage
            {
                CarId = carId,
                AttachmentId = attachment.Id
            };
            carImages.Add(carImage);
        }

        foreach (var carImage in carImages)
        {
            await _unitOfWork.CarImageRepository.AddAsync(carImage);
        }
        await _unitOfWork.SaveAsync();

        return _mapper.Map<IEnumerable<CarImageResultDto>>(carImages);
    }
}