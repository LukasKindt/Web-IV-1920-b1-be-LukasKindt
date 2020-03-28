using System.Collections.Generic;

namespace PokemonApi.Models
{
    public interface IPokemonRepository
    {
        Pokemon GetBy(int id);
        bool TryGetPokemon(int id, out Pokemon pokemon);
        IEnumerable<Pokemon> GetAll();
        void Add(Pokemon pokemon);
        void Delete(Pokemon pokemon);
        void Update(Pokemon pokemon);
        void SaveChanges();
    }
}

