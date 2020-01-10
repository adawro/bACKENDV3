using Praca_Inzynierska.DTO;
using Praca_Inzynierska.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska.Services.Interfaces
{
   public interface ICommentService
    {
        CommentResponse AddComment(CommentSaveDto comment);
        CommentListResponse GetCommentForMovie(int id);
    }
}
