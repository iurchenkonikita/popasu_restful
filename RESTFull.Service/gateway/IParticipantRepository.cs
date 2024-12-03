using RESTFull.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.gateway
{
    public interface IParticipantRepository : IBaseRepository<Participant>
    {
        public List<Participant> GetAllByReport(Guid reportId);
        public List<Participant> GetAllByConferenceId(Guid conferenceId);
    }
}
