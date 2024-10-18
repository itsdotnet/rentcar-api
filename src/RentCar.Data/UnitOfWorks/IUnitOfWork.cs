using System;
using RentCar.Data.Repositories;
using RentCar.Domain.Entities;

namespace RentCar.Data.UnitOfWorks;

public interface IUnitOfWork : IDisposable
{
    IRepository<User> UserRepository { get; }
    IRepository<Provider> ProviderRepository { get; }
    IRepository<CarImage> CarImageRepository { get; }
    IRepository<Car> CarRepository { get; }
    IRepository<Book> BookRepository { get; }
    IRepository<Attachment> AttachmentRepository { get; }
    Task<bool> SaveAsync();
}
