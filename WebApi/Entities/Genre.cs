using System.ComponentModel.DataAnnotations;

namespace MovieStore.Entities;

public class Genre
{
    [Key] public int Id { get; set; }
    
    public string Name { get; set; }
}