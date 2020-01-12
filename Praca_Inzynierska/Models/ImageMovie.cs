using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska.Models
{
    public class ImageMovie
    {
        [Key]
        public int ImageId { get; set; }
        public string FileName { get; set; }
        public Movie Movie { get; set; }
    }
}

