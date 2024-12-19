using RESTFull.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.dto
{
    public class ReportUpdateDto
    {

        [Required(ErrorMessage = "Report's id must be specified!")]
        public Guid id { get; }

        [MinLength(1, ErrorMessage = "Report's title can't be empty!")]
        public String title { get; }

        [MinLength(1, ErrorMessage = "Report's title can't be empty!")]
        public String annotation { get; }

        [MinLength(1, ErrorMessage = "Report's authors must to contains no less than 1 author!")]
        public List<Guid> authors { get; }

        [Required(ErrorMessage = "Report's presintation time must be specified!")]
        public DateTime presentationTime { get; }

        [Required]
        public Guid section { get; }

        public ReportUpdateDto(Guid id, string title, string annotation, List<Guid> authors, DateTime presentationTime, Guid section)
        {
            this.id = id;
            this.title = title;
            this.annotation = annotation;
            this.authors = authors;
            this.presentationTime = presentationTime;
            this.section = section;
        }
    }
}
