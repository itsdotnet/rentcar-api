using AutoMapper;
using RentCar.Domain.Entities;
using RentCar.Service.DTOs.Attachments;
using RentCar.Service.DTOs.Booking;
using RentCar.Service.DTOs.Cars;
using RentCar.Service.DTOs.Providers;
using RentCar.Service.DTOs.Users;

namespace RentCar.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserResultDto>().ReverseMap();
        CreateMap<UserUpdateDto, User>().ReverseMap();
        CreateMap<UserCreationDto, User>().ReverseMap();
        
        CreateMap<Provider,ProviderCreationDto>().ReverseMap();
        CreateMap<Provider, ProviderUpdateDto>().ReverseMap();
        CreateMap<ProviderResultDto, Provider>().ReverseMap();

        CreateMap<Car,CarCreationDto>().ReverseMap();
        CreateMap<Car, CarUpdateDto>().ReverseMap();
        CreateMap<CarResultDto, Car>().ReverseMap();

        CreateMap<Book, BookCreationDto>().ReverseMap();
        CreateMap<Book, BookUpdateDto>().ReverseMap();
        CreateMap<BookResultDto, Book>().ReverseMap();

        CreateMap<Attachment, AttachmentResultDto>().ReverseMap();
    }
}