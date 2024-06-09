using Domain.Entities;
using Domain.IRepositories;

namespace Domain.IRepositorie
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<Author> GetAauthorByNameAsync(string name, string surname);
    }
}
