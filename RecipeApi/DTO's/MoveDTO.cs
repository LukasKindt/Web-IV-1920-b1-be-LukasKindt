using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemon.DTO_s
{
    public class MoveDTO
    {
        [Required]
        public string Name { get; set; }
        public int PowerPoints { get; set; }
        public int BasePower { get; set; }
        public int Accuracy { get; set; }
        public string Effect { get; set; }
    }
}
