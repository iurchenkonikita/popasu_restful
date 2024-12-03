using RESTFull.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.dto
{
    public class ParticipantCreateDto
    {
        public String name { get; }
        public String role { get; }
        public String contactInfo { get; }
        public String organization { get; }

        public ParticipantCreateDto(string name, string role, string contactInfo, string organization)
        {
            this.name = name;
            this.role = role;
            this.contactInfo = contactInfo;
            this.organization = organization;
        }
    }
}
