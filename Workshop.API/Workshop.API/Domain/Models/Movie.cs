using Workshop.API.Domain.Enums;

namespace Workshop.API.Domain.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Year { get; set; }
        public Genre Genre { get; set; }
    }
}
