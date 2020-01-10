using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Praca_Inzynierska.Models;

namespace Praca_Inzynierska.Services.Communication
{
    public class CommentResponse : Response
    {
        public Comment Comment { get; }

        private CommentResponse(bool success, Dictionary<string, string[]> message, Comment comment)
            : base(success, message)
        {
            Comment = comment;
        }

        public CommentResponse(Comment comment)
            : this(true, new Dictionary<string, string[]>(), comment)
        {
        }

        public CommentResponse(Dictionary<string, string[]> message)
            : this(false, message, null)
        {
        }
    }
}
