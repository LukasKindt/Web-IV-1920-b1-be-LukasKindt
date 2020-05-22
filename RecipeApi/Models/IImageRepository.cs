using System.Collections.Generic;

namespace MonsterApi.Models
{
    public interface IImageRepository
    {
        public IEnumerable<Image> GetAll();
        public Image GetBy(int id);
        public Image GetByMonsterId(int id);
        public void addImage(Image image);
        public void saveChanges();
    }
}

