using Microsoft.EntityFrameworkCore;
using MonsterApi.Models;
using System.Linq;

namespace MonsterApi.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MonsterContext _context;
        private readonly DbSet<Customer> _customers;

        public CustomerRepository(MonsterContext dbContext)
        {
            _context = dbContext;
            _customers = dbContext.Customers;
        }

        public Customer GetBy(string email)
        {
            return _customers.Include(c => c.Favourites).ThenInclude(f => f.Monster).ThenInclude(p => p.Moves).SingleOrDefault(c => c.Email == email);
        }

        public void Add(Customer customer)
        {
            _customers.Add(customer);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}