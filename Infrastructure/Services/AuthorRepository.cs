using Domain.Entities;
using Domain.IRepositorie;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApiDbContext context) : base(context)
        {
        }
        public async Task<Author> GetAauthorByNameAsync(string name, string surname)
        {
            return await _context.Authors.FirstOrDefaultAsync(author => author.Firstname == name && author.Lastname==surname);
        }
    }
}

