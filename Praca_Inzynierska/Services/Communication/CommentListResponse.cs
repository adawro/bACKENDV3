using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Praca_Inzynierska.DTO.ReturnDto;

namespace Praca_Inzynierska.Services.Communication
{
    public class CommentListResponse : Response
    {
        public CommentListReturnDto Comments { get; }

        private CommentListResponse(bool success, Dictionary<string, string[]> message, CommentListReturnDto comments)
            : base(success, message)
        {
            Comments = comments;
        }

        public CommentListResponse(CommentListReturnDto comments)
            : this(true, new Dictionary<string, string[]>(), comments)
        {
        }

        public CommentListResponse(Dictionary<string, string[]> message)
            : this(false, message, null)
        {
        }
    }
}
