using AutoMapper;
using RentCar.Data.UnitOfWorks;
using RentCar.Domain.Entities;
using RentCar.Service.DTOs.Users;
using RentCar.Service.Exceptions;
using RentCar.Service.Helpers;
using RentCar.Service.Interfaces;

namespace RentCar.Service.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UserResultDto> CreateAsync(UserCreationDto dto)
    {
        var existingUser = await _unitOfWork.UserRepository.SelectAsync(q => q.Email == dto.Email);
        if (existingUser != null)
            throw new AlreadyExistException("User with this email already exists.");

        var newUser = _mapper.Map<User>(dto);
        await _unitOfWork.UserRepository.AddAsync(newUser);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<UserResultDto>(newUser);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var user = await _unitOfWork.UserRepository.SelectAsync(q => q.Id == id);
        if (user == null)
            throw new NotFoundException("User not found.");

        await _unitOfWork.UserRepository.DeleteAsync(x => x.Id == user.Id);
        return await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<UserResultDto>> GetAllAsync()
    {
        var users = _unitOfWork.UserRepository.SelectAll();
        return _mapper.Map<IEnumerable<UserResultDto>>(users);
    }

    public async Task<UserResultDto> GetByIdAsync(long id)
    {
        var user = await _unitOfWork.UserRepository.SelectAsync(q => q.Id == id);
        if (user == null)
            throw new NotFoundException("User not found.");
        
        return _mapper.Map<UserResultDto>(user);
    }

    public async Task<UserResultDto> UpdateAsync(UserUpdateDto dto)
    {
        var existingUser = await _unitOfWork.UserRepository.SelectAsync(q => q.Id == dto.Id);
        if (existingUser == null)
            throw new NotFoundException("User not found.");

        _mapper.Map(dto, existingUser);
        await _unitOfWork.UserRepository.UpdateAsync(existingUser);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<UserResultDto>(existingUser);
    }

    public async Task<UserResultDto> UpdatePasswordAsync(long id, string oldPass, string newPass)
    {
        var existingUser = await _unitOfWork.UserRepository.SelectAsync(q => q.Id == id);
        if (existingUser == null)
            throw new NotFoundException("User not found.");

        // Assuming you have a method to verify and hash passwords
        if (!PasswordHasher.Verify(oldPass, existingUser.Password))
            throw new CustomException(401, "Old password is incorrect.");

        existingUser.Password = PasswordHasher.Hash(newPass);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<UserResultDto>(existingUser);
    }
}
