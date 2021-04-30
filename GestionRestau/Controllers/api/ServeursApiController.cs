using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionRestau.Models;
using GestionRestau.Models.Context;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionRestau.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServeursApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServeursApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ServeursApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Serveur>>> GetServeurs()
        {
            return await _context.Serveurs.ToListAsync();
        }

        // GET: api/ServeursApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Serveur>> GetServeur(int id)
        {
            var serveur = await _context.Serveurs.FindAsync(id);

            if (serveur == null)
            {
                return NotFound();
            }

            return serveur;
        }

        // PUT: api/ServeursApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServeur(int id, Serveur serveur)
        {
            if (id != serveur.Id)
            {
                return BadRequest();
            }

            _context.Entry(serveur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServeurExists(id))
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

        // POST: api/ServeursApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Serveur>> PostServeur(Serveur serveur)
        {
            _context.Serveurs.Add(serveur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServeur", new { id = serveur.Id }, serveur);
        }

        // DELETE: api/ServeursApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Serveur>> DeleteServeur(int id)
        {
            var serveur = await _context.Serveurs.FindAsync(id);
            if (serveur == null)
            {
                return NotFound();
            }

            _context.Serveurs.Remove(serveur);
            await _context.SaveChangesAsync();

            return serveur;
        }

        private bool ServeurExists(int id)
        {
            return _context.Serveurs.Any(e => e.Id == id);
        }

    }
}
