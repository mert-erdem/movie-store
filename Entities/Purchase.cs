using System.ComponentModel.DataAnnotations;

namespace MovieStore.Entities;

public class Purchase
{
    [Key] public int Id { get; set; }
    
    public int CustomerId { get; set; }

    public int MovieId { get; set; }

    public float Price { get; set; }

    public DateTime Time { get; set; }
}