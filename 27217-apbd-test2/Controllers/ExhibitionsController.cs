using _27217_apbd_test2.Models.DTOs;
using _27217_apbd_test2.Services;
using Microsoft.AspNetCore.Mvc;

namespace _27217_apbd_test2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExhibitionsController(IExhibitionsService exhibitionsService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddExhibition([FromBody] AddExhibitionRequest request)
    {
        var success = await exhibitionsService.AddExhibitionAsync(request);
        return success ? StatusCode(201) : BadRequest("Invalid gallery or artwork data.");
    }
}
