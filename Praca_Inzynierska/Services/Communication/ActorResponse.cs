using System.Collections.Generic;
using Praca_Inzynierska.DTO.ReturnDto;

namespace Praca_Inzynierska.Services.Communication
{
    public class ActorResponse : Response
    {
        public ActorReturnDto Actor { get; }

        private ActorResponse(bool success, Dictionary<string, string[]> message, ActorReturnDto actor)
            : base(success, message)
        {
            Actor = actor;
        }

        public ActorResponse(ActorReturnDto actor)
            : this(true, new Dictionary<string, string[]>(), actor)
        {
        }

        public ActorResponse(Dictionary<string, string[]> message)
            : this(false, message, null)
        {
        }
    }
}
