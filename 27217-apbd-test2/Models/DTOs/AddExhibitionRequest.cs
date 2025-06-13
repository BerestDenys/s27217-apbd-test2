using System.ComponentModel.DataAnnotations;

namespace _27217_apbd_test2.Models.DTOs;

public class AddExhibitionRequest
{
    [Required, MaxLength(100)]
    public string Title { get; set; }

    [Required, MaxLength(50)]
    public string Gallery { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required, MinLength(1)]
    public List<ArtworkAssignmentDto> Artworks { get; set; }
}
