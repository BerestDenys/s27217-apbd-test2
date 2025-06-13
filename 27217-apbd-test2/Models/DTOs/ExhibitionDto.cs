namespace _27217_apbd_test2.Models.DTOs;

public class ExhibitionDto
{
    public string Title { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int NumberOfArtworks { get; set; }
    public List<ArtworkDto> Artworks { get; set; }
}