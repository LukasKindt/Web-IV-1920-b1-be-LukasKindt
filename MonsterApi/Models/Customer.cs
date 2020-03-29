using System.Collections.Generic;
using System.Linq;

namespace MonsterApi.Models
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

        public IEnumerable<Monster> FavouriteMonster => Favourites.Select(f => f.Monster);
        #endregion

        #region Constructors
        public Customer()
        {
            Favourites = new List<CustomerFavourite>();
        }
        #endregion

        #region Methods
        public void AddFavouriteMonster(Monster monster)
        {
            Favourites.Add(new CustomerFavourite() { MonsterId = monster.Id, CustomerId = CustomerId, Monster = monster, Customer = this });
        }
        #endregion
    }
}