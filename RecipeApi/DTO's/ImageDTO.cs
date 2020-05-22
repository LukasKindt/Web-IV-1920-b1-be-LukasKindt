using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Monster.DTO_s
{
    public class ImageDTO
    {
        [Required]
        public byte[] ImageData { get; set; }

        [Required]
        public int MonsterId { get; set; }
    }
}