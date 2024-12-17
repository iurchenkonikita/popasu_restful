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
        public Guid id { get; }

        [MinLength(1, ErrorMessage = "Section's title can't be empty!")]
        public String title { get; }

        [MinLength(1, ErrorMessage = "Section's description can't be empty!")]
        public String description { get; }

        [MinLength(1, ErrorMessage = "Section's conference can't be empty!")]
        public String conference { get; }

        [Required(ErrorMessage = "Section's time must be specified!")]
        public DateTime time { get; }
        public List<Guid> reports { get; }

        public SectionUpdateDto(Guid id, string title, string description, string conference, DateTime time, List<Guid> reports)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.conference = conference;
            this.time = time;
            this.reports = reports;
        }
    }
}
