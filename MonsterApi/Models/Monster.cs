using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MonsterApi.Models
{
    public class Monster
    {
        #region Properties
        /// <summary>
        /// the id of the Monster
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// the name of the Monster
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Extra information about the monster
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The base Attack Points
        /// </summary>
        public int Attack { get; set; }

        /// <summary>
        /// The base Defense points
        /// </summary>
        public int Defense { get; set; }

        /// <summary>
        /// The Base HP
        /// </summary>
        public int HealthPoints { get; set; }

        /// <summary>
        /// The Base Speed
        /// </summary>
        public int Speed { get; set; }
        /// <summary>
        /// A list of moves this Monster can use
        /// </summary>
        public ICollection<Move> Moves { get; private set; }
        #endregion

        #region Constructors
        public Monster()
        {
            Moves = new List<Move>();
        }

        public Monster(string name, string description) : this()
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