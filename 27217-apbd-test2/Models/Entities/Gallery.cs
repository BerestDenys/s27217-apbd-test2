using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _27217_apbd_test2.Models.Entities;

[Table("Gallery")]
public class Gallery
{
    [Key]
    public int GalleryId { get; set; }
    
    [Required, MaxLength(50)]
    public string Name { get; set; } = null!;
    
    [Required]
    public DateTime EstablishedDate { get; set; }
    
    public ICollection<Exhibition> Exhibitions { get; set; } = new List<Exhibition>();
}