using RESTFull.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.dto
{
    public class ConferenceUpdateDto
    {
        [Required]
        public Guid id { get; }

        [Required(ErrorMessage = "Conference's title must be specified!")]
        [StringLength(int.MaxValue, MinimumLength = 1, ErrorMessage = "Conference's title must be longer than 1 symbol!")]
        public String title { get; }

        [Required(ErrorMessage = "Conference's status must be specified!")]
        [StringLength(int.MaxValue, MinimumLength = 1, ErrorMessage = "Conference's status must be longer than 1 symbol!")]
        public String status { get; }

        [Required(ErrorMessage = "Conference's startDate must be specified!")]
        public DateTime startDate { get; }

        [Required(ErrorMessage = "Conference's endDate must be specified!")]
        public DateTime endDate { get; }

        [Required(ErrorMessage = "Conference's location must be specified!")]
        [StringLength(int.MaxValue, MinimumLength = 1, ErrorMessage = "Conference's location must be longer than 1 symbol!")]
        public String location { get; }
        public String description { get; }

        public List<Guid> sections { get; }
        public List<Guid> participants { get; }

        public ConferenceUpdateDto(Guid id, string title, string status, DateTime startDate, DateTime endDate, string location, string description, List<Guid> sections, List<Guid> participants)
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
    }
}
