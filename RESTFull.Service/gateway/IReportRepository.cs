using RESTFull.Domain;

namespace RESTFull.Service.gateway
{
    public interface IReportRepository : IBaseRepository<Report>
    {
        List<Report> getAllBySection(Guid sectionId);
        List<Report> getAllByParticipant(Guid participantId);
    }
}
