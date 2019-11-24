using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Praca_Inzynierska.Models
{
    public class MovieToActors
    {
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int Actor { get; set; }
        public string ActorNameInMovie { get; set; }
    }
}
