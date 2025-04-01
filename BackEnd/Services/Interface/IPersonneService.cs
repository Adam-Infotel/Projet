using BackEnd.Class;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public interface IPersonneService
    {
        Task<IEnumerable<Personne>> GetAllPersonnesAsync();
        Task<Personne> GetPersonneByIdAsync(int id);
        Task AddPersonneAsync(Personne personne);
        Task AddPersonneListAsync(List<Personne> personnes);
        Task UpdatePersonneAsync(Personne personne);
        Task DeletePersonneAsync(int id);
    }
}
