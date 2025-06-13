namespace _27217_apbd_test2.Models.DTOs;

public class GalleryExhibitionDto
{
    public int GalleryId { get; set; }
    public string Name { get; set; }
    public DateTime EstablishedDate { get; set; }
    public List<ExhibitionDto> Exhibitions { get; set; }
}