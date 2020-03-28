using Microsoft.AspNetCore.Identity;
using PokemonApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonApi.Data
{
    public class PokemonDataInitializer
    {
        private readonly PokemonContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public PokemonDataInitializer(PokemonContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                //seeding the database with pokemon, see DBContext         
                Customer customer = new Customer { Email = "pokemonmaster@hogent.be", FirstName = "Adam", LastName = "Master" };
                _dbContext.Customers.Add(customer);
                await CreateUser(customer.Email, "P@ssword1111");
                Customer student = new Customer { Email = "student@hogent.be", FirstName = "Student", LastName = "Hogent" };
                _dbContext.Customers.Add(student);
                student.AddFavouritePokemon(_dbContext.Pokemon.First());
                await CreateUser(student.Email, "P@ssword1111");
                _dbContext.SaveChanges();
            }

        }


        private async Task CreateUser(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
        }
    }



}

