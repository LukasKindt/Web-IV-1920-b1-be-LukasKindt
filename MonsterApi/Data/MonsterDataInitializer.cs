using Microsoft.AspNetCore.Identity;
using MonsterApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MonsterApi.Data
{
    public class MonsterDataInitializer
    {
        private readonly MonsterContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public MonsterDataInitializer(MonsterContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                //seeding the database with monster, see DBContext         
                Customer customer = new Customer { Email = "monstermaster@hogent.be", FirstName = "Monster", LastName = "Master" };
                _dbContext.Customers.Add(customer);
                await CreateUser(customer.Email, "P@ssword1111");
                Customer student = new Customer { Email = "student@hogent.be", FirstName = "Student", LastName = "Hogent" };
                _dbContext.Customers.Add(student);
                student.AddFavouriteMonster(_dbContext.Monster.First());
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

