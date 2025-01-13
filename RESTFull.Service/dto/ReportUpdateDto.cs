using System.ComponentModel.DataAnnotations;

namespace RESTFull.Service.dto
{
    public class ReportUpdateDto
    {

        [Required(ErrorMessage = "Report's id must be specified!")]
        public Guid id { get; set; }

        [MinLength(1, ErrorMessage = "Report's title can't be empty!")]
        public String title { get; set; }

        [MinLength(1, ErrorMessage = "Report's title can't be empty!")]
        public String annotation { get; set; }

        [MinLength(1, ErrorMessage = "Report's authors must to contains no less than 1 author!")]
        public List<Guid> authors { get; set; }

        [Required(ErrorMessage = "Report's presintation time must be specified!")]
        public DateTime presentationTime { get; set; }

        [Required]
        public Guid section { get; set; }

        public ReportUpdateDto(Guid id, string title, string annotation, List<Guid> authors, DateTime presentationTime, Guid section)
        {
            this.id = id;
            this.title = title;
            this.annotation = annotation;
            this.authors = authors;
            this.presentationTime = presentationTime;
            this.section = section;
        }
        public ReportUpdateDto() { }
    }
}
