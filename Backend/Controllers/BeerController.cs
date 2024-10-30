using Backend.DTOs;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private StoreContext _context;
        public BeerController(StoreContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<BeerDTO>> Get() => _context.Beers.Select(b => new BeerDTO
        {
            Id = b.BeerId,
            Name = b.Name,
            Alcohol = b.Alcohol,
            BrandId = b.BrandID
        }).ToListAsync();
    }
}
