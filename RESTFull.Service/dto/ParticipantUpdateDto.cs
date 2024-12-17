using RESTFull.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.dto
{
    public class ParticipantUpdateDto
    {
        [Required]
        public Guid id { get; }

        [MinLength(1, ErrorMessage = "Participant's name can't be empty!")]
        public String name { get; }

        [MinLength(1, ErrorMessage = "Participant's role can't be empty!")]
        public String role { get; }

        [MinLength(1, ErrorMessage = "Participant's contactInfo can't be empty!")]
        public String contactInfo { get; }

        [MinLength(1, ErrorMessage = "Participant's organization can't be empty!")]
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
