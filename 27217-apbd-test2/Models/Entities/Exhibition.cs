using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _27217_apbd_test2.Models.Entities;

[Table("Exhibition")]
public class Exhibition
{
    [Key]
    public int ExhibitionId { get; set; }
    
    [Required]
    public int GalleryId { get; set; }
    
    [Required, MaxLength(100)]
    public string Title { get; set; } = null!;
    
    [Required]
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    [Required]
    public int NumberOfArtworks { get; set; }
    
    public Gallery Gallery { get; set; } = null!;
    
    public ICollection<ExhibitionArtwork> ExhibitionArtworks { get; set; } = new List<ExhibitionArtwork>();
}