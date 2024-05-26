using Microsoft.AspNetCore.Mvc;
using WebApiFilmes.Models;

namespace WebApiFilmes.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Route("api/movie")]
public class MovieController : ControllerBase
{
    private static List<Movie> _movies = new List<Movie>();
    private static int id = 0;

    [HttpGet]
    public IEnumerable<Movie> GetAllMovies()
    {
        return _movies;
    }
    
    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id)
    {
        var movie = _movies.FirstOrDefault(movie => movie.Id == id);

        if (movie == null) return NotFound();
        return Ok(movie);
    }

    [HttpGet("page")]
    public IActionResult GetMoviesByPage([FromQuery] int _skip = 0, [FromQuery] int _take = 50)
    {
        // Skip -> Quantos elementos da lista voce quer pular
        // Take -> Quantos elementos da lista vcoce quer pegar
        //return _movies.Skip(_skip).Take(_take);

        var movies = _movies.Skip(_skip).Take(_take);
        if (movies == null) return NotFound();
        return Ok(movies);
    }

    [HttpPost]
    public IActionResult CreateMovie([FromBody] Movie movie)
    {
        movie.Id = id++;

        _movies.Add(movie);

        return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);

        //Console.WriteLine("Titulo: " + movie.Title);
        //Console.WriteLine("Gênero: " + movie.Gender);
        //Console.WriteLine("Tempo de Duração: " + movie.DurationTime);
    }
}
