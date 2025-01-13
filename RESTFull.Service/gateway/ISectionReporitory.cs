using RESTFull.Domain;

namespace RESTFull.Service.gateway
{
    public interface ISectionReporitory : IBaseRepository<Section>
    {
        List<Section> GetByConferenceId(Guid conferenceId);
    }
}
