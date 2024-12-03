using RESTFull.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.gateway
{
    public interface IReportRepository : IBaseRepository<Report>
    {
        List<Report> getAllBySection(Guid sectionId);
        List<Report> getAllByParticipant(Guid participantId);
    }
}
