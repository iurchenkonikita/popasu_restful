using System.ComponentModel.DataAnnotations;

namespace RESTFull.Service.dto
{
    public class ConferenceUpdateDto
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

        public List<Guid> sections { get; set; }
        public List<Guid> participants { get; set; }

        public ConferenceUpdateDto(String id, string title, string status, DateTime startDate, DateTime endDate, string location, string description, List<Guid> sections, List<Guid> participants)
        {
            this.id = id;
            this.title = title;
            this.status = status;
            this.startDate = startDate;
            this.endDate = endDate;
            this.location = location;
            this.description = description;
            this.sections = sections;
            this.participants = participants;
        }
        public ConferenceUpdateDto() { }
    }
}
