using Microsoft.EntityFrameworkCore;
using MonsterApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MonsterApi.Data.Repositories
{
    public class MonsterRepository : IMonsterRepository
    {
        private readonly MonsterContext _context;
        private readonly DbSet<Models.Monster> _monster;

        public MonsterRepository(MonsterContext dbContext)
        {
            _context = dbContext;
            _monster = dbContext.Monster;
        }

        public IEnumerable<Models.Monster> GetAll()
        {
            return _monster.Include(r => r.Moves).ToList();
        }

        public Models.Monster GetBy(int id)
        {
            return _monster.Include(r => r.Moves).SingleOrDefault(p => p.Id == id);
        }

        public bool TryGetMonster(int id, out Models.Monster monster)
        {
            monster = _context.Monster.Include(t => t.Moves).FirstOrDefault(t => t.Id == id);
            return monster != null;
        }

        public void Add(Models.Monster monster)
        {
            _monster.Add(monster);
        }

        public void Update(Models.Monster monster)
        {
            _context.Update(monster);
        }

        public void Delete(Models.Monster monster)
        {
            _monster.Remove(monster);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Models.Monster> GetBy(string name = null) {
            var monsters = _context.Monster.Include(m => m.Moves).AsQueryable();
            if (!string.IsNullOrEmpty(name))
                monsters = monsters.Where(m => m.Name.IndexOf(name) >= 0);
            return monsters.OrderBy(m => m.Name).ToList();
        }
     }
}
