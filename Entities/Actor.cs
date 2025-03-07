namespace MovieStore.Entities;

public class Actor
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string Surname { get; set; }

    public List<MovieActor> MovieActors { get; set; }
}