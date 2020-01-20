using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska.Models
{
    public class ImageActor
    {
        [Key]
        public int ImageId { get; set; }
        public string FileName { get; set; }
        public Actor Actor { get; set; }
    }
}
