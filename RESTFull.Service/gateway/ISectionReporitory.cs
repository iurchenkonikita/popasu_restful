using RESTFull.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.gateway
{
    public interface ISectionReporitory : IBaseRepository<Section>
    {
        List<Section> GetByConferenceId(Guid conferenceId);
    }
}
