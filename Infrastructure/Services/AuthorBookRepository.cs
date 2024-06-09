using Domain.IRepositories;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AuthorBookRepository : GenericRepository<AuthorBook>, IAuthorBookRepository
    {
        public AuthorBookRepository(ApiDbContext context) : base(context)
        {
            

        }
        public async Task<List<int>> GetAllAuthorIdsByBook(int bookId)
        {
            var authorIds = await _context.AuthorBooks
                .Where(x => x.BookId == bookId)
                .Select(x => x.AuthorId)
                .ToListAsync();
            return authorIds;
        }
    }
}
