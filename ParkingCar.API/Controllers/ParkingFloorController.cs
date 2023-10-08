using Domain.ParkingFloor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace ParkingCar.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ParkingFloorController : BaseController
    {
        private readonly DatabaseContext _dbContext;

        public ParkingFloorController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingFloor>>> GetParkingFloors()
        {
            return await _dbContext.ParkingFloors.ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParkingFloor(int id, ParkingFloor parkingFloor)
        {
            if (id != parkingFloor.ParkingFloorId)
            {
                return BadRequest();
            }

            _dbContext.Entry(parkingFloor).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingFloorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool ParkingFloorExists(int id)
        {
            return _dbContext.ParkingFloors.Any(e => e.ParkingFloorId == id);
        }
    }
}