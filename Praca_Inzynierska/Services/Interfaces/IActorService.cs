using Praca_Inzynierska.DTO;
using Praca_Inzynierska.Services.Communication;

namespace Praca_Inzynierska.Services.Interfaces
{
    public interface IActorService
    {
        ActorResponse AddActor(ActorSaveDto actorSave);
        ActorResponse EditActor(int id, ActorEditDto actorEditDto);
        ActorListResponse FindActor(FindActorDto findActor);

    }
}
