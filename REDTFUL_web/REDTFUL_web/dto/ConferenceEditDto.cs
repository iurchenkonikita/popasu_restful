using RESTFull.Service.dto;
using System.ComponentModel.DataAnnotations;

namespace REDTFUL_web.dto
{
    public class ConferenceEditDto
    {
        [Required]
        public String id { get; set; }

        [Required(ErrorMessage = "Conference's title must be specified!")]
        [StringLength(int.MaxValue, MinimumLength = 1, ErrorMessage = "Conference's title must be longer than 1 symbol!")]
        public String title { get; set; }

        [Required(ErrorMessage = "Conference's status must be specified!")]
        [StringLength(int.MaxValue, MinimumLength = 1, ErrorMessage = "Conference's status must be longer than 1 symbol!")]
        public String status { get; set; }

        [Required(ErrorMessage = "Conference's startDate must be specified!")]
        public DateTime startDate { get; set; }

        [Required(ErrorMessage = "Conference's endDate must be specified!")]
        public DateTime endDate { get; set; }

        [Required(ErrorMessage = "Conference's location must be specified!")]
        [StringLength(int.MaxValue, MinimumLength = 1, ErrorMessage = "Conference's location must be longer than 1 symbol!")]
        public String location { get; set; }
        public String description { get; set; }



        public ConferenceEditDto(ConferencePublicDto dto)
        {
            this.id = dto.id.ToString();
            this.title = dto.title;
            this.status = dto.status;
            this.startDate = dto.startDate;
            this.endDate = dto.endDate;
            this.location = dto.location;
            this.description = dto.description;
        }
        public ConferenceEditDto() { }

        public ConferenceUpdateDto getUpdateDto()
        {
            ConferenceUpdateDto conferenceUpdate = new ConferenceUpdateDto();
            conferenceUpdate.id = id;
            conferenceUpdate.title = title;
            conferenceUpdate.status = status;
            conferenceUpdate.startDate = startDate;
            conferenceUpdate.endDate = endDate;
            conferenceUpdate.location = location;
            conferenceUpdate.description = description;

            return conferenceUpdate;
        }
    }
}
