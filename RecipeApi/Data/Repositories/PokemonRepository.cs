using Microsoft.EntityFrameworkCore;
using PokemonApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PokemonApi.Data.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly PokemonContext _context;
        private readonly DbSet<Models.Pokemon> _pokemon;

        public PokemonRepository(PokemonContext dbContext)
        {
            _context = dbContext;
            _pokemon = dbContext.Pokemon;
        }

        public IEnumerable<Models.Pokemon> GetAll()
        {
            return _pokemon.ToList();
        }

        public Models.Pokemon GetBy(int id)
        {
            return _pokemon.Include(r => r.Moves).SingleOrDefault(p => p.Id == id);
        }

        public bool TryGetPokemon(int id, out Models.Pokemon pokemon)
        {
            pokemon = _context.Pokemon.Include(t => t.Moves).FirstOrDefault(t => t.Id == id);
            return pokemon != null;
        }

        public void Add(Models.Pokemon pokemon)
        {
            _pokemon.Add(pokemon);
        }

        public void Update(Models.Pokemon pokemon)
        {
            _context.Update(pokemon);
        }

        public void Delete(Models.Pokemon pokemon)
        {
            _pokemon.Remove(pokemon);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
     }
}
