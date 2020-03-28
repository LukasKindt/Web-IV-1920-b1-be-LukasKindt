using System.Collections.Generic;
using System.Linq;

namespace PokemonApi.Models
{
    public class Customer
    {
        #region Properties
        //add extra properties if needed
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public ICollection<CustomerFavourite> Favourites { get; private set; }

        public IEnumerable<Pokemon> FavouritePokemon => Favourites.Select(f => f.Pokemon);
        #endregion

        #region Constructors
        public Customer()
        {
            Favourites = new List<CustomerFavourite>();
        }
        #endregion

        #region Methods
        public void AddFavouritePokemon(Pokemon pokemon)
        {
            Favourites.Add(new CustomerFavourite() { PokemonId = pokemon.Id, CustomerId = CustomerId, Pokemon = pokemon, Customer = this });
        }
        #endregion
    }
}