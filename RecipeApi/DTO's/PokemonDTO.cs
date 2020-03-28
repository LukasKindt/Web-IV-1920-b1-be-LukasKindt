using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemon.DTO_s
{
    public class PokemonDTO
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<MoveDTO> Moves { get; set; }
    }
}
