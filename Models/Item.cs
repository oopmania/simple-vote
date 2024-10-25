namespace SimpleVote.Models;

public class Item
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Votes { get; set; } = 0;
}