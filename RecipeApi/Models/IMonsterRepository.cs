using System.Collections.Generic;

namespace MonsterApi.Models
{
    public interface IMonsterRepository
    {
        Monster GetBy(int id);
        bool TryGetMonster(int id, out Monster monster);
        IEnumerable<Monster> GetAll();
        void Add(Monster monster);
        void Delete(Monster monster);
        void Update(Monster monster);
        void SaveChanges();
        public IEnumerable<Models.Monster> GetBy(string name = null);
    }
}

