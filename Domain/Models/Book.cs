using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int ReleaseYear { get; set; }
        [Range(0, 10)]
        public double Rating { get; set; }
        public bool IsTaken { get; set; } = false;
        public ICollection<AuthorBook>? AuthorBook { get; set; }
    }
}
