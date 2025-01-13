using RESTFull.Domain;

namespace RESTFull.Service.gateway
{
    public interface IConferenceRepository : IBaseRepository<Conference>
    {
        List<Conference> getAllByParticipant(Guid participantId);
    }
}
