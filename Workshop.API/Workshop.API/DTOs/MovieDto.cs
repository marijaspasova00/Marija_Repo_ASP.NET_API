using Workshop.API.Domain.Enums;
using Workshop.API.Domain.Models;

namespace Workshop.API.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Year { get; set; }
        public Genre Genre { get; set; }
        //public List<Movie> movies { get; set; }
    }
}
