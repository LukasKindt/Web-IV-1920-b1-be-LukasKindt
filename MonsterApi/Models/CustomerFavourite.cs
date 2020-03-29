namespace MonsterApi.Models
{
    public class CustomerFavourite
    {
        #region Properties
        public int CustomerId { get; set; }

        public int MonsterId { get; set; }

        public Customer Customer { get; set; }

        public Monster Monster { get; set; }
        #endregion
    }
}