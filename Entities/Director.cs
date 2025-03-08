using System.ComponentModel.DataAnnotations;

namespace MovieStore.Entities;

public class Director
{
    [Key] public int Id { get; set; }
    
    public string Name { get; set; }

    public string Surname { get; set; }

    public List<Movie> Movies { get; set; }
}