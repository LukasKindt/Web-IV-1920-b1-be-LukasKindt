using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokemon.DTO_s;
using PokemonApi.Models;

namespace Pokemon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly ICustomerRepository _customerRepository;
        public PokemonController(IPokemonRepository context, ICustomerRepository customerRepository) {
            _pokemonRepository = context;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Gets all Pokémon
        /// </summary>
        /// <returns>All Pokémon</returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IEnumerable<PokemonApi.Models.Pokemon> GetPokemon() {
            return _pokemonRepository.GetAll().OrderBy(p => p.Id);
        }

        /// <summary>
        /// Get the Pokémon with given id
        /// </summary>
        /// <param name="id">The id of the Pokémon</param>
        /// <returns>The Pokémon</returns>
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<PokemonApi.Models.Pokemon> GetPokemon(int id) {
            PokemonApi.Models.Pokemon pokemon = _pokemonRepository.GetBy(id);
            if (pokemon == null) { return NotFound(); }
            return pokemon;
        }

        [HttpGet("Favourites")]
        public IEnumerable<PokemonApi.Models.Pokemon> GetFavourites()
        {
            Customer customer = _customerRepository.GetBy(User.Identity.Name);
            return customer.FavouritePokemon;
        }

        /// <summary>
        /// Adds a Pokémon
        /// </summary>
        /// <param name="pokemon">The Pokémon</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<PokemonApi.Models.Pokemon> PostPokemon(PokemonDTO pokemon) {
            PokemonApi.Models.Pokemon pokemonToCreate = new PokemonApi.Models.Pokemon() { Name = pokemon.Name, Description = pokemon.Description };
            foreach (var m in pokemon.Moves) {
                pokemonToCreate.AddMove(new Move(m.Name, m.PowerPoints, m.Accuracy, m.Effect, m.BasePower));
            }
            _pokemonRepository.Add(pokemonToCreate);
            _pokemonRepository.SaveChanges();

            return CreatedAtAction(nameof(GetPokemon), new { id = pokemonToCreate.Id }, pokemon);
        }

        /// <summary>
        /// Puts a Pokémon at specific id
        /// </summary>
        /// <param name="id">The presumed id of the Pokémon</param>
        /// <param name="pokemon">The Pokémon</param>
        /// <returns>ActionResult</returns>
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult PutPokemon(int id, PokemonApi.Models.Pokemon pokemon) {
            if (id != pokemon.Id) { return BadRequest(); }
            _pokemonRepository.Update(pokemon);
            _pokemonRepository.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Delete the Pokémon with given id
        /// </summary>
        /// <param name="id">the id of the Pokémon</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult DeletePokemon(int id) {
            PokemonApi.Models.Pokemon pokemon = _pokemonRepository.GetBy(id);
            if (pokemon == null) { return NotFound(); }
            _pokemonRepository.Delete(pokemon);
            _pokemonRepository.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Get the move with given id, given the Pokémon
        /// </summary>
        /// <param name="id">the id of the Pokémon</param>
        /// <param name="moveId">the id of the move</param>
        /// <returns>the move</returns>
        [HttpGet("{id}/moves/{moveId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Move> GetMove(int id, int moveId) {
            if (!_pokemonRepository.TryGetPokemon(id, out var pokemon)) { return NotFound(); }
            Move m = pokemon.GetMove(moveId);
            if (m == null) { return NotFound(); }
            return m;
        }

    }

}