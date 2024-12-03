using RESTFull.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.dto
{
    public class ParticipantUpdateDto
    {
        public Guid id { get; }
        public String name { get; }
        public String role { get; }
        public String contactInfo { get; }
        public String organization { get; }
        public List<Guid> conferences { get; }
        public List<Guid> reports { get; }

        public ParticipantUpdateDto(Guid id, string name, string role, string contactInfo, string organization, List<Guid> conferences, List<Guid> reports)
        {
            this.id = id;
            this.name = name;
            this.role = role;
            this.contactInfo = contactInfo;
            this.organization = organization;
            this.conferences = conferences;
            this.reports = reports;
        }
    }
}
