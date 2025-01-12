using RESTFull.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.dto
{
    public class SectionUpdateDto
    {
        [Required(ErrorMessage = "Section's id must be specified!")]
        public Guid id { get; set; }

        [MinLength(1, ErrorMessage = "Section's title can't be empty!")]
        public String title { get; set; }

        [MinLength(1, ErrorMessage = "Section's description can't be empty!")]
        public String description { get; set; }

        [Required( ErrorMessage = "Section's conference can't be empty!")]
        public Guid conference { get; set; }

        [Required(ErrorMessage = "Section's time must be specified!")]
        public DateTime time { get; set; }
        public List<Guid> reports { get; set; }

        public SectionUpdateDto(Guid id, string title, string description, Guid conference, DateTime time, List<Guid> reports)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.conference = conference;
            this.time = time;
            this.reports = reports;
        }

        public SectionUpdateDto()
        {
        }
    }
}
