using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PokemonApi.Models
{
    public class Pokemon
    {
        #region Properties
        /// <summary>
        /// the id of the Pok�mon
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// the name of the Pok�mon
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The Pok�dex entry of the Pok�mon, description of the Pok�mon
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A list of moves this Pok�mon can use
        /// </summary>
        public ICollection<Move> Moves { get; private set; }
        #endregion

        #region Constructors
        public Pokemon()
        {
            Moves = new List<Move>();
        }

        public Pokemon(string name, string description) : this()
        {
            Name = name;
            Description = description;
        }
        #endregion

        #region Methods
        public void AddMove(Move move) => Moves.Add(move);

        public Move GetMove(int id) => Moves.SingleOrDefault(m => m.Id == id);
        #endregion
    }
}