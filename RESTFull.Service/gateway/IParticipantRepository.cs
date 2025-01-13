using RESTFull.Domain;

namespace RESTFull.Service.gateway
{
    public interface IParticipantRepository : IBaseRepository<Participant>
    {
        public List<Participant> GetAllByReport(Guid reportId);
        public List<Participant> GetAllByConferenceId(Guid conferenceId);
    }
}
