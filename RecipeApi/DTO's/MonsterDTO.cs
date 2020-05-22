using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Monster.DTO_s
{
    public class MonsterDTO
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int HealthPoints { get; set; }
        public int Speed { get; set; }
        public IList<MoveDTO> Moves { get; set; }
    }
}
