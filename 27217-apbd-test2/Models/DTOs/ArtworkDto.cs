namespace _27217_apbd_test2.Models.DTOs;

public class ArtworkDto
{
    public string Title { get; set; }
    public int YearCreated { get; set; }
    public decimal InsuranceValue { get; set; }
    public ArtistDto Artist { get; set; }
}