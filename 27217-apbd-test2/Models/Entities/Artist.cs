using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _27217_apbd_test2.Models.Entities;

[Table("Artist")]
public class Artist
{
    [Key]
    public int ArtistId { get; set; }

    [Required, MaxLength(100)] 
    public string FirstName { get; set; } = null!;

    [Required, MaxLength(100)]
    public string LastName { get; set; } = null!;
    
    [Required]
    public DateTime BirthDate { get; set; }
    
    public ICollection<Artwork> Artworks { get; set; } = new List<Artwork>();
}