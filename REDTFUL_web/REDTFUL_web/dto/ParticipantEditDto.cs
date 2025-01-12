using RESTFull.Service.dto;
using System.ComponentModel.DataAnnotations;

namespace REDTFUL_web.dto
{
    public class ParticipantEditDto
    {

        [Required]
        public String id { get; set; }

        [MinLength(1, ErrorMessage = "Participant's name can't be empty!")]
        public String name { get; set; }

        [MinLength(1, ErrorMessage = "Participant's role can't be empty!")]
        public String role { get; set; }

        [MinLength(1, ErrorMessage = "Participant's contactInfo can't be empty!")]
        public String contactInfo { get; set; }

        [MinLength(1, ErrorMessage = "Participant's organization can't be empty!")]
        public String organization { get; set; }


        public ParticipantEditDto(ParticipantPublicDto dto)
        {
            this.id = dto.id;
            this.name = dto.name;
            this.role = dto.role;
            this.contactInfo = dto.contactInfo;
            this.organization = dto.organization; 
        }
        public ParticipantEditDto() { }

        public ParticipantUpdateDto getUpdateDto()
        {
            ParticipantUpdateDto update = new ParticipantUpdateDto();
           update.id = Guid.Parse(id);                      
           update.name = name;                  
           update.role = role;                  
           update.contactInfo = contactInfo;    
            update.organization = organization; 

            return update;
        }
    }
}
