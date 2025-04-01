using BackEnd.Class;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using AutoMapper;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonneController : ControllerBase
    {
        private readonly IPersonneService _personneService;
        private readonly IMapper _mapper;

        public PersonneController(IPersonneService personneService, IMapper mapper)
        {
            _personneService = personneService;
            _mapper = mapper;
        }

        // GET: api/personne
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonneModel>>> GetAllPersonnes()
        {
            var personnes = await _personneService.GetAllPersonnesAsync();
            var personneModels = _mapper.Map<List<PersonneModel>>(personnes);

            return Ok(personneModels);
        }

        // GET: api/personne/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Personne>> GetPersonne(int id)
        {
            var personne = await _personneService.GetPersonneByIdAsync(id);
            if (personne == null)
            {
                return NotFound();
            }
            var personneModels = _mapper.Map<PersonneModel>(personne);

            return Ok(personneModels);
        }

        // POST: api/personne/add
        [HttpPost("add")]
        public async Task<ActionResult> AddPersonnesList([FromBody] List<Personne> personnes)
        {
            // Vérifier que la liste de personnes n'est pas vide
            if (personnes == null || personnes.Count == 0)
            {
                return BadRequest("La liste des personnes est vide.");
            }

            await _personneService.AddPersonneListAsync(personnes);

            // Retourne un message de succès
            return CreatedAtAction(nameof(GetAllPersonnes), new { message = "Personnes ajoutées avec succès" });
        }

        // PUT: api/personne/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePersonne(int id, [FromBody] Personne personne)
        {
            if (id != personne.Id)
            {
                return BadRequest();
            }
            await _personneService.UpdatePersonneAsync(personne);
            return NoContent();
        }

        // DELETE: api/personne/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePersonne(int id)
        {
            var personne = await _personneService.GetPersonneByIdAsync(id);
            if (personne == null)
            {
                return NotFound(new { message = "Personne non trouvée." });
            }

            await _personneService.DeletePersonneAsync(id);

            return Ok(new { message = "Personne supprimée avec succès." });
        }
    }
}
