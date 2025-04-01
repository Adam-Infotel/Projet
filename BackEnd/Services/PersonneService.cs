using BackEnd.Class;
using BackEnd.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class PersonneService : IPersonneService
    {
        private readonly IPersonneRepository _personneRepository;

        public PersonneService(IPersonneRepository personneRepository)
        {
            _personneRepository = personneRepository;
        }

        public async Task<IEnumerable<Personne>> GetAllPersonnesAsync()
        {
            return await _personneRepository.GetAllPersonnesAsync();
        }

        public async Task<Personne> GetPersonneByIdAsync(int id)
        {
            return await _personneRepository.GetPersonneByIdAsync(id);
        }

        public async Task AddPersonneAsync(Personne personne)
        {
            await _personneRepository.AddPersonneAsync(personne);
        }
        public async Task AddPersonneListAsync(List<Personne> personnes)
        {
            await _personneRepository.AddPersonneListAsync(personnes);
        }
        public async Task UpdatePersonneAsync(Personne personne)
        {
            await _personneRepository.UpdatePersonneAsync(personne);
        }

        public async Task DeletePersonneAsync(int id)
        {
            await _personneRepository.DeletePersonneAsync(id);
        }
    }
}
