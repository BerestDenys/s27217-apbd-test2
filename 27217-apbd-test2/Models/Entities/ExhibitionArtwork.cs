using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _27217_apbd_test2.Models.Entities;

[Table("Exhibition_Artwork")]
[PrimaryKey(nameof(ExhibitionId), nameof(ArtworkId))]
public class ExhibitionArtwork
{
    public int ExhibitionId { get; set; }
    public int ArtworkId { get; set; }
    
    [Required, Precision(10, 2)]
    public decimal InsuranceValue { get; set; }
    
    public Exhibition Exhibition { get; set; } = null!;
    public Artwork Artwork { get; set; } = null!;
}