using System.Collections.Generic;
using System.Linq;

namespace MonsterApi.Models
{
    public class Image
    {
        public int Id { get; }
        public byte[] ImageData { get; set; }
        public Monster Monster { get; set; }
        public int MonsterId { get; set; }

        public Image(byte[] imageData, Monster monster, int monsterId)
        {
            ImageData = imageData;
            Monster = monster;
            MonsterId = monsterId;
        }

        public Image() { }
    }


}