using RESTFull.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.dto
{
    public class ParticipantCreateDto
    {
        [MinLength(1, ErrorMessage = "Participant's name can't be empty!")]
        public String name { get; }

        [MinLength(1, ErrorMessage = "Participant's role can't be empty!")]
        public String role { get; }

        [MinLength(1, ErrorMessage = "Participant's contactInfo can't be empty!")]
        public String contactInfo { get; }

        [MinLength(1, ErrorMessage = "Participant's organization can't be empty!")]
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
