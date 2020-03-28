using Microsoft.EntityFrameworkCore;
using PokemonApi.Models;
using System.Linq;

namespace PokemonApi.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly PokemonContext _context;
        private readonly DbSet<Customer> _customers;

        public CustomerRepository(PokemonContext dbContext)
        {
            _context = dbContext;
            _customers = dbContext.Customers;
        }

        public Customer GetBy(string email)
        {
            return _customers.Include(c => c.Favourites).ThenInclude(f => f.Pokemon).ThenInclude(p => p.Moves).SingleOrDefault(c => c.Email == email);
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