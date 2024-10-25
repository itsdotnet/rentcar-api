using AutoMapper;
using RentCar.Data.UnitOfWorks;
using RentCar.Domain.Entities;
using RentCar.Service.DTOs.Cars;
using RentCar.Service.Exceptions;
using RentCar.Service.Interfaces;

namespace RentCar.Service.Services;

public class CarService : ICarService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CarService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CarResultDto> CreateAsync(CarCreationDto dto)
    {
        var newCar = _mapper.Map<Car>(dto);
        await _unitOfWork.CarRepository.AddAsync(newCar);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<CarResultDto>(newCar);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var car = await _unitOfWork.CarRepository.SelectAsync(c => c.Id == id);
        if (car == null)
            throw new NotFoundException("Car not found.");

        await _unitOfWork.CarRepository.DeleteAsync(c => c.Id == id);
        return await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<CarResultDto>> GetAllAsync()
    {
        var cars = _unitOfWork.CarRepository.SelectAll();
        return _mapper.Map<IEnumerable<CarResultDto>>(cars);
    }

    public async Task<CarResultDto> GetByIdAsync(long id)
    {
        var car = await _unitOfWork.CarRepository.SelectAsync(c => c.Id == id);
        if (car == null)
            throw new NotFoundException("Car not found.");

        return _mapper.Map<CarResultDto>(car);
    }

    public async Task<CarResultDto> UpdateAsync(CarUpdateDto dto)
    {
        var existingCar = await _unitOfWork.CarRepository.SelectAsync(c => c.Id == dto.Id);
        if (existingCar == null)
            throw new NotFoundException("Car not found.");

        _mapper.Map(dto, existingCar);
        await _unitOfWork.CarRepository.UpdateAsync(existingCar);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<CarResultDto>(existingCar);
    }

    public async Task<IEnumerable<CarResultDto>> GetByProviderIdAsync(long providerId)
    {
        var cars = _unitOfWork.CarRepository.SelectAll(c => c.ProviderId == providerId);
        return _mapper.Map<IEnumerable<CarResultDto>>(cars);
    }
}
