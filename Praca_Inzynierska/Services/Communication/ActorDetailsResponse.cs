using System.Collections.Generic;
using Praca_Inzynierska.DTO;
using Praca_Inzynierska.DTO.ReturnDto;

namespace Praca_Inzynierska.Services.Communication
{
    public class ActorDetailsResponse : Response
    {
        public ActorReturnDetails ActorDetails { get; }

        private ActorDetailsResponse(bool success, Dictionary<string, string[]> message, ActorReturnDetails actorDetails)
            : base(success, message)
        {
            ActorDetails = actorDetails;
        }

        public ActorDetailsResponse(ActorReturnDetails actorDetails)
            : this(true, new Dictionary<string, string[]>(), actorDetails)
        {

        }

        public ActorDetailsResponse(Dictionary<string, string[]> message)
            : this(false, message, null)
        {
        }
    }
}
