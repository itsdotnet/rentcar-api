using AutoMapper;
using RentCar.Data.UnitOfWorks;
using RentCar.Domain.Entities;
using RentCar.Service.DTOs.Providers;
using RentCar.Service.Exceptions;
using RentCar.Service.Interfaces;

namespace RentCar.Service.Services;

public class ProviderService : IProviderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProviderService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ProviderResultDto> CreateAsync(ProviderCreationDto dto)
    {
        var existingProvider = await _unitOfWork.ProviderRepository.SelectAsync(p => p.Name == dto.Name);
        if (existingProvider != null)
            throw new AlreadyExistException("Provider with this name already exists.");

        var newProvider = _mapper.Map<Provider>(dto);
        await _unitOfWork.ProviderRepository.AddAsync(newProvider);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<ProviderResultDto>(newProvider);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var provider = await _unitOfWork.ProviderRepository.SelectAsync(p => p.Id == id);
        if (provider == null)
            throw new NotFoundException("Provider not found.");

        await _unitOfWork.ProviderRepository.DeleteAsync(p => p.Id == provider.Id);
        return await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<ProviderResultDto>> GetAllAsync()
    {
        var providers = _unitOfWork.ProviderRepository.SelectAll();
        return _mapper.Map<IEnumerable<ProviderResultDto>>(providers);
    }

    public async Task<ProviderResultDto> GetByIdAsync(long id)
    {
        var provider = await _unitOfWork.ProviderRepository.SelectAsync(p => p.Id == id);
        if (provider == null)
            throw new NotFoundException("Provider not found.");

        return _mapper.Map<ProviderResultDto>(provider);
    }

    public async Task<ProviderResultDto> UpdateAsync(ProviderUpdateDto dto)
    {
        var existingProvider = await _unitOfWork.ProviderRepository.SelectAsync(p => p.Id == dto.Id);
        if (existingProvider == null)
            throw new NotFoundException("Provider not found.");

        _mapper.Map(dto, existingProvider);
        await _unitOfWork.ProviderRepository.UpdateAsync(existingProvider);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<ProviderResultDto>(existingProvider);
    }
}
