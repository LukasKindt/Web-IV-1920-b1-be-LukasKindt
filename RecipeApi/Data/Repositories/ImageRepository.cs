using Microsoft.EntityFrameworkCore;
using MonsterApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MonsterApi.Data.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly MonsterContext _context;
        private readonly DbSet<Image> _images;

        public ImageRepository(MonsterContext dbContext)
        {
            _context = dbContext;
            _images = dbContext.Images;
        }
        
        public void addImage(Image image)
        {
            _images.Add(image);
        }

        public IEnumerable<Image> GetAll()
        {
            return _images;
        }

        public Image GetBy(int id)
        {
            return _images.Include(i => i.Monster).FirstOrDefault(i => i.Id == id);
        }

        public Image GetByMonsterId(int id)
        {
            return _images.Include(i => i.Monster).FirstOrDefault(i => i.MonsterId == id);
        }

        public void saveChanges()
        {
            _context.SaveChanges();
        }
    }
}