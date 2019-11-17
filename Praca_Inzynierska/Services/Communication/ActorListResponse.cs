using System.Collections.Generic;
using Praca_Inzynierska.DTO;
using Praca_Inzynierska.DTO.ReturnDto;

namespace Praca_Inzynierska.Services.Communication
{
    public class ActorListResponse : Response
    {
        public ActorListReturnDto ActorList { get; }

        private ActorListResponse(bool success, Dictionary<string, string[]> message, ActorListReturnDto actorList)
            : base(success, message)
        {
            ActorList = actorList;
        }

        public ActorListResponse(ActorListReturnDto actorList)
            : this(true, new Dictionary<string, string[]>(), actorList)
        {

        }

        public ActorListResponse(Dictionary<string, string[]> message)
            : this(false, message, null)
        {
        }   
    }
}
