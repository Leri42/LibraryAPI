using Domain.Entities;
using Domain.IRepositorie;
using Domain.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiDbContext _context;
        private IBookRepository _books;
        private IAuthorRepository _authors;
        private IAuthorBookRepository _authorsBook;
        public UnitOfWork(ApiDbContext context, IBookRepository books, IAuthorRepository authors, IAuthorBookRepository authorsBook)
        {
            _context = context;
            _books = books;
            _authors = authors;
            _authorsBook = authorsBook;
        }

        public IBookRepository Books => _books ??= new BookRepository(_context);
        public IAuthorRepository Authors => _authors ??= new AuthorRepository(_context);

        public IAuthorBookRepository AuthorBook => _authorsBook ??= new AuthorBookRepository(_context);

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
