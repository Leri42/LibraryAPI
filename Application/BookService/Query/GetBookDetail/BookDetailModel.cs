using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookService.Query.GetBookDetail
{
    public class BookDetailModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int ReleaseYear { get; set; }
        public double Rating { get; set; }
        public bool IsTaken { get; set; }
        public IEnumerable<AuthorViewModel> Authors { get; set; }
    }

    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
