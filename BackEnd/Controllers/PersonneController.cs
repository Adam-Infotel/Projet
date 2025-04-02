using BackEnd.Class;
using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonneModel>> UpdatePersonne(int id, [FromBody] FormPersonneModel personne)
        {
            var existingPersonne = await _personneService.GetPersonneByIdAsync(id);
            
            if (existingPersonne == null)
            {
                return NotFound("Personne non trouvée.");
            }

            // Mise à jour des propriétés de l'objet existant
            if (!string.IsNullOrEmpty(personne.Nom))
                existingPersonne.Nom = personne.Nom;

            if (!string.IsNullOrEmpty(personne.Prenom))
                existingPersonne.Prenom = personne.Prenom;

            if (!string.IsNullOrEmpty(personne.Email))
                existingPersonne.Email = personne.Email;

            if (!string.IsNullOrEmpty(personne.Telephone))
                existingPersonne.Telephone = personne.Telephone;

            // Appliquez la mise à jour dans la base de données
            await _personneService.UpdatePersonneAsync(existingPersonne);

            // Mappez l'entité mise à jour en modèle (par exemple PersonneModel)
            var updatedPersonneModel = _mapper.Map<PersonneModel>(existingPersonne);

            // Retourne le modèle modifié avec un statut HTTP 200 OK
            return Ok(updatedPersonneModel); 
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