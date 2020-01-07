using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Praca_Inzynierska.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int MovieId { get; set; }
        public string CommentStrign { get; set; }

    }
}
