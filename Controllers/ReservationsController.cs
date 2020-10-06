using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiMeetings.Model;


namespace ApiMeetings.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReservationsController : ControllerBase
  {

    private readonly ApiDbContext _context;

    public ReservationsController(ApiDbContext context)
    {
      _context = context;
    }

    // GET: api/Reservations
    [HttpGet]
    public IEnumerable<ReservationModel> GetReservations()
    {
      return _context.Reservations;
    }

    // GET: api/Reservations/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetReservationModel([FromRoute] Guid id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var reservationModel = await _context.Reservations.FindAsync(id);

      if (reservationModel == null)
      {
        return NotFound();
      }

      return Ok(reservationModel);
    }

    // PUT: api/Reservations/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutReservationModel([FromRoute] Guid id, [FromBody] ReservationModel reservationModel)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != reservationModel.Id)
      {
        return BadRequest();
      }

      _context.Entry(reservationModel).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ReservationModelExists(id))
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

    // POST: api/Reservations
    [HttpPost]
    public async Task<IActionResult> PostReservationModel([FromBody] ReservationModel reservationModel)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _context.Reservations.Add(reservationModel);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetReservationModel", new { id = reservationModel.Id }, reservationModel);
    }

    // DELETE: api/Reservations/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReservationModel([FromRoute] Guid id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var reservationModel = await _context.Reservations.FindAsync(id);
      if (reservationModel == null)
      {
        return NotFound();
      }

      _context.Reservations.Remove(reservationModel);
      await _context.SaveChangesAsync();

      return Ok(reservationModel);
    }

    private bool ReservationModelExists(Guid id)
    {
      return _context.Reservations.Any(e => e.Id == id);
    }
  }
}