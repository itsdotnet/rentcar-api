using System;
using RentCar.Data.Repositories;
using RentCar.Domain.Entities;

namespace RentCar.Data.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;
    
    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;

        UserRepository = new Repository<User>(dbContext);
        ProviderRepository = new Repository<Provider>(dbContext);
        CarImageRepository = new Repository<CarImage>(dbContext);   
        CarRepository = new Repository<Car>(dbContext);
        BookRepository = new Repository<Book>(dbContext);
        AttachmentRepository = new Repository<Attachment>(dbContext);
    }

    public IRepository<User> UserRepository { get; }
    public IRepository<Provider> ProviderRepository { get; }
    public IRepository<CarImage> CarImageRepository { get; }
    public IRepository<Car> CarRepository { get; }
    public IRepository<Book> BookRepository { get; }
    public IRepository<Attachment> AttachmentRepository { get; }

    public void Dispose()
    { GC.SuppressFinalize(true); }
    
    public async Task<bool> SaveAsync()
    {
        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }
}
