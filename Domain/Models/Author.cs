using Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string FullName
        {
            get
            {
                return Firstname + " " + Lastname;
            } 
        }
        public DateTime Birthdate { get; set; }
        [ForeignKey(nameof(BookId))]
        public int BookId { get; set; }
        public ICollection<AuthorBook> AuthorBook { get; set; } = new List<AuthorBook>();
    }
}
