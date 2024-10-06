using EncoreTix.Core.Management;
using EncoreTix.Core.Services.AttractionService;
using Microsoft.AspNetCore.Mvc;

namespace EncoreTix.Controllers
{
    public class AttractionController : Controller
    {
        private readonly IAttractionsService _attractionsService;
        private readonly IAttractionDetailManagement _attractionDetailManagement;
        public AttractionController(IAttractionsService attractionsService, IAttractionDetailManagement attractionDetailManagement)
        {
            _attractionsService = attractionsService;
            _attractionDetailManagement = attractionDetailManagement;
        }


        public async Task<IActionResult> IndexAsync()
        {
            var result = await _attractionsService.GetAttractionListAsync("PHISH"); // put phish as the default according to the requirments 
            var model = result.Embedded;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AttractionList(string keyword)
        {
            var result = await _attractionsService.GetAttractionListAsync(keyword);
            return PartialView("AttractionList", result.Embedded);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Attraction ID is required.");
            }

            var attraction = await _attractionDetailManagement.GetAttractionDetails(id);

            if (attraction == null)
            {
                return NotFound("Attraction not found.");
            }

            return View(attraction);
        }
    }
}
