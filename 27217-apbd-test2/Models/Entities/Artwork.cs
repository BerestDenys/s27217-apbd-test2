using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _27217_apbd_test2.Models.Entities;

[Table("Artwork")]
public class Artwork
{
    [Key]
    public int ArtworkId { get; set; }
    
    [Required]
    public int ArtistId { get; set; }
    
    [Required, MaxLength(100)]
    public string Title { get; set; } = null!;
    
    [Required]
    public int YearCreated { get; set; }
    
    public Artist Artist { get; set; } = null!;
    
    public ICollection<ExhibitionArtwork> ExhibitionArtworks { get; set; } = new List<ExhibitionArtwork>();
}