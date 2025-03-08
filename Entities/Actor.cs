using System.ComponentModel.DataAnnotations;

namespace MovieStore.Entities;

public class Actor
{
    [Key] public int Id { get; set; }
    
    public string Name { get; set; }

    public string Surname { get; set; }

    public List<MovieActor> MovieActors { get; set; } = new();
}