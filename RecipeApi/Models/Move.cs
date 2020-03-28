namespace MonsterApi.Models
{
    public class Move
    {
        #region Properties
        /// <summary>
        /// The id of the move
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the move
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The amount of PP the move has, amount of times the move can be used
        /// </summary>
        public int PowerPoints { get; set; }

        /// <summary>
        /// The power of the move
        /// </summary>
        public int BasePower { get; set; }

        /// <summary>
        /// The chance the move will hit (in %)
        /// </summary>
        public int Accuracy { get; set; }

        /// <summary>
        /// The extra effect of the move
        /// </summary>
        public string Effect { get; set; }
        #endregion

        #region Constructors
        public Move(string name, int pp, int accuracy, string effect, int basepower = 0)
        {
            Name = name;
            PowerPoints = pp;
            BasePower = basepower;
            Accuracy = accuracy;
            Effect = effect;
        }

        public Move() { }
        #endregion
    }
}