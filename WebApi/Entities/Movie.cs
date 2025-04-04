using System.ComponentModel.DataAnnotations;

namespace MovieStore.Entities;

public class Movie
{
    [Key] public int Id { get; set; }

    public bool IsActive { get; set; } = true;
    
    public string Name { get; set; }

    public DateTime ReleaseDate { get; set; }

    public int GenreId { get; set; }

    public Genre? Genre { get; set; }

    public int DirectorId { get; set; }

    public Director? Director { get; set; }

    public List<MovieActor> MovieActors { get; set; } = new();

    public float Price { get; set; }
}