using _27217_apbd_test2.Services;
using Microsoft.AspNetCore.Mvc;

namespace _27217_apbd_test2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GalleriesController(IGalleriesService galleriesService) : ControllerBase
{
    [HttpGet("{id}/exhibitions")]
    public async Task<IActionResult> GetGalleryExhibitions(int id)
    {
        var result = await galleriesService.GetGalleryExhibitionsAsync(id);
        return result == null ? NotFound() : Ok(result);
    }
}