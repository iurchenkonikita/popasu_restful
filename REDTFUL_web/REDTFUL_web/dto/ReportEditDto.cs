using RESTFull.Service.dto;
using System.ComponentModel.DataAnnotations;

namespace REDTFUL_web.dto
{
    public class ReportEditDto
    {
        [Required(ErrorMessage = "Report's id must be specified!")]
        public String id { get; set; }

        [MinLength(1, ErrorMessage = "Report's title can't be empty!")]
        public String title { get; set; }

        [MinLength(1, ErrorMessage = "Report's title can't be empty!")]
        public String annotation { get; set; }

        [Required(ErrorMessage = "Report's presintation time must be specified!")]
        public DateTime presentationTime { get; set; }

        [Required]
        public String section { get; set; }


        public ReportEditDto(ReportPublicDto dto)
        {
            this.id = dto.Id;
            this.title = dto.title;
            this.annotation = dto.annotation;
            this.presentationTime = dto.presentationTime;
            this.section = dto.section.ToString();
        }

        public ReportEditDto()
        {
        }

        public ReportUpdateDto getUpdateDto()
        {
            ReportUpdateDto dto = new ReportUpdateDto();

           dto.id = Guid.Parse(id);
           dto.title = title;
           dto.annotation = annotation;
           dto.presentationTime = presentationTime;
           dto.section = Guid.Parse( section);

            return dto;
        }
    }
}
