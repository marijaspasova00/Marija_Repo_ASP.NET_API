using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workshop.API.Data;
using Workshop.API.Domain.Enums;
using Workshop.API.Domain.Models;
using Workshop.API.DTOs;
using static System.Net.Mime.MediaTypeNames;

namespace Workshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<MovieDto>> GetAll() 
        {
            try
            {
                var movieDb = StaticDb.Movies;
                var movies = movieDb.Select(m => new Movie
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    Year = m.Year,
                    Genre = m.Genre,
                }).ToList();
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, contact the admin!");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<MovieDto> GetMovieById(int id) 
        {
            try
            {
                if(id < 0)
                {
                    return BadRequest("The id can not be negative!");
                }
                Movie movieDb = StaticDb.Movies.FirstOrDefault(m => m.Id == id);
                if(movieDb == null) 
                {
                    return NotFound($"Note with id {id} does not exist!");
                }
                var movieDto = new MovieDto
                {
                    Title = movieDb.Title,
                    Description = movieDb.Description,
                    Year = movieDb.Year,
                    Genre = movieDb.Genre
                };
                return Ok(movieDto);
            }
            catch(Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, contact the admin!");
            }
        }
        [HttpGet("findById")]
        public ActionResult<MovieDto> FindMovieById(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("The id can not be negative!");
                }

                //try to find the note by id
                Movie movieDb = StaticDb.Movies.FirstOrDefault(x => x.Id == id);
                if (movieDb == null)
                {
                    //404
                    return NotFound($"Movie with id {id} does not exist!");

                }

                var movieDto = new MovieDto
                {
                    Title=movieDb.Title,
                    Description = movieDb.Description,
                    Year = movieDb.Year,
                    Genre = movieDb.Genre
                };
                return Ok(movieDto);
            }
            catch
            {
                //log
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, contact the admin!");
            }
        }

        [HttpGet("findByGenreOrYear")]
        public ActionResult<MovieDto> Filter(int? genre, string? year)
        {
            try
            {
                if (string.IsNullOrEmpty(year) && genre == null)
                {
                    return BadRequest("Insert at least one query paramater");
                }
                if (string.IsNullOrEmpty(year))
                {
                    return Ok(StaticDb.Movies.Where(x => (int)x.Genre == genre).ToList());
                }
                if (genre == null)
                {
                    return Ok(StaticDb.Movies.Where(x => x.Year.ToLower() == year.ToLower()).ToList());
                }

                return Ok(StaticDb.Movies.Where(x => x.Year.ToLower() == year.ToLower() && (int)x.Genre == genre).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, please contact the support team.");
            }
        }
        [HttpPost("addMovie")]
        public IActionResult CreateMovie([FromBody] MovieDto movieDto)
        {
            try
            {
                //validations
                if (string.IsNullOrEmpty(movieDto.Title))
                {
                    return BadRequest($"Title is a required field");
                }

                Movie movieDb = StaticDb.Movies.FirstOrDefault(x => x.Id == movieDto.Id);
                if (movieDto == null)
                {
                    return NotFound($"Movie with id {movieDto.Id} was not found!");
                }

                //create
                Movie newMovie = new Movie
                {
                    Id = ++StaticDb.Movies.LastOrDefault().Id,
                    Title = movieDto.Title,
                    Description = movieDto.Description,
                    Year = movieDto.Year,
                    Genre = movieDto.Genre
                };
                StaticDb.Movies.Add(newMovie);

                return StatusCode(StatusCodes.Status201Created, "Note created!");
            }
            catch
            {
                //log
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, contact the admin!");
            }
        }
        [HttpPut]
        public IActionResult UpdateMovie([FromBody] MovieDto movie)
        {
            try
            {
                Movie movieDb = StaticDb.Movies.FirstOrDefault(x => x.Id == movie.Id);
                if (movieDb == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Resource not found");
                }
                if (string.IsNullOrEmpty(movie.Title))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Text must not be empty.");
                }
                if (string.IsNullOrEmpty(movie.Year))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Insert a year of a movie.");
                }
                if (!string.IsNullOrEmpty(movie.Description) && movie.Description.Length > 250)
                {
                    return BadRequest("Description can not be longer than 250 characters");
                }
                movieDb.Title = movie.Title;
                movieDb.Description = movie.Description;
                movieDb.Year = movie.Year;
                movieDb.Genre = movie.Genre;
                return StatusCode(StatusCodes.Status204NoContent, "Movie updated!");
            }
            catch (Exception ex)
            {
                //log
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, contact the admin!");
            }
        }
        [HttpDelete]
        public IActionResult DeleteMovieFromBody([FromBody] int id)
        {
            try
            {
                if (id < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request, the id can not be negative!");
                }
                var movieDb = StaticDb.Movies.FirstOrDefault(m => m.Id == id);
                if (movieDb == null)
                {
                    return NotFound("Movie was not found");
                }
                StaticDb.Movies.Remove(movieDb);
                return StatusCode(StatusCodes.Status204NoContent, "Movie deleted!");
            }
            catch (Exception ex)
            {
                //log 
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, contact the admin!");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMovieFromRoute(int id)
        {
            try
            {
                if (id < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request, the id can not be negative!");
                }
                var movieDb = StaticDb.Movies.FirstOrDefault(x => x.Id == id);
                if (movieDb == null)
                {
                    return NotFound("Movie was not found");
                }
                StaticDb.Movies.Remove(movieDb);

                return StatusCode(StatusCodes.Status204NoContent, "Movie deleted!");
            }
            catch (Exception ex)
            {
                //log 
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, contact the admin!");
            }
        }

    }
}

