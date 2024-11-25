

using System.ComponentModel.DataAnnotations;

namespace GameStore.Entities;
public class Game
{
    [Key]
    public int Id { get; set; }

    public required string Name { get; set; }

    public required decimal Price { get; set; }

    public required string Genre { get; set; }

    public required DateTime Relasedate { get; set; }
    public required string Imageurl { get; set; }

}
