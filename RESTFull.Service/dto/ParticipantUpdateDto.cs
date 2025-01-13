using System.ComponentModel.DataAnnotations;

namespace RESTFull.Service.dto
{
    public class ParticipantUpdateDto
    {
        [Required]
        public Guid id { get; set; }

        [MinLength(1, ErrorMessage = "Participant's name can't be empty!")]
        public String name { get; set; }

        [MinLength(1, ErrorMessage = "Participant's role can't be empty!")]
        public String role { get; set; }

        [MinLength(1, ErrorMessage = "Participant's contactInfo can't be empty!")]
        public String contactInfo { get; set; }

        [MinLength(1, ErrorMessage = "Participant's organization can't be empty!")]
        public String organization { get; set; }
        public List<Guid> conferences { get; set; }
        public List<Guid> reports { get; set; }

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
        public ParticipantUpdateDto() { }
    }
}
