using System.ComponentModel.DataAnnotations;

namespace MovieStore.Entities;

public class Movie
{
    [Key] public int Id { get; set; }
    
    public string Name { get; set; }

    public DateTime Year { get; set; }

    public int GenreId { get; set; }

    public Genre? Genre { get; set; }

    public int DirectorId { get; set; }

    public Director? Director { get; set; }

    public List<Actor> Actors { get; set; }

    public int Price { get; set; }
}