namespace PokemonApi.Models
{
    public class CustomerFavourite
    {
        #region Properties
        public int CustomerId { get; set; }

        public int PokemonId { get; set; }

        public Customer Customer { get; set; }

        public Pokemon Pokemon { get; set; }
        #endregion
    }
}