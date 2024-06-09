using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IAuthorBookRepository : IGenericRepository<AuthorBook>
    {
        Task<List<int>> GetAllAuthorIdsByBook(int bookId);
    }
}
