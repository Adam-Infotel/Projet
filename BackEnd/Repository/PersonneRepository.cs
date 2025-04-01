using BackEnd.Class;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Context;
namespace BackEnd.Repository
{
    public class PersonneRepository : IPersonneRepository
    {
        private readonly MonProjetDbContext _context;

        public PersonneRepository(MonProjetDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Personne>> GetAllPersonnesAsync()
        {
            return await _context.Personne.ToListAsync();
        }

        public async Task<Personne> GetPersonneByIdAsync(int id)
        {
            return await _context.Personne.FindAsync(id);
        }

        public async Task AddPersonneAsync(Personne personne)
        {
            await _context.Personne.AddAsync(personne);
            await _context.SaveChangesAsync();
        }
        public async Task AddPersonneListAsync(List<Personne> personnes)
        {
            await _context.Personne.AddRangeAsync(personnes);
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePersonneAsync(Personne personne)
        {
            _context.Personne.Update(personne);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePersonneAsync(int id)
        {
            var personne = await _context.Personne.FindAsync(id);
            if (personne != null)
            {
                _context.Personne.Remove(personne);
                await _context.SaveChangesAsync();
            }
        }
    }
}
