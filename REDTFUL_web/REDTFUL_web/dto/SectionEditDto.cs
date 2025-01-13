using RESTFull.Service.dto;
using System.ComponentModel.DataAnnotations;

namespace REDTFUL_web.dto
{
    public class SectionEditDto
    {

        [Required(ErrorMessage = "Section's id must be specified!")]
        public String id { get; set; }

        [MinLength(1, ErrorMessage = "Section's title can't be empty!")]
        public String title { get; set; }

        [MinLength(1, ErrorMessage = "Section's description can't be empty!")]
        public String description { get; set; }

        [Required(ErrorMessage = "Section's conference can't be empty!")]
        public String conference { get; set; }

        [Required(ErrorMessage = "Section's time must be specified!")]
        public DateTime time { get; set; }
        public SectionEditDto(SectionPublicDto dto)
        {
            this.id = dto.Id.ToString();
            this.title = dto.title;
            this.description = dto.description;
            this.conference = dto.conference.ToString();
            this.time = dto.time;
        }

        public SectionEditDto()
        {
        }

        public SectionUpdateDto getUpdateDto()
        {
            SectionUpdateDto dto = new SectionUpdateDto();
            dto.id = Guid.Parse(id);
            dto.title = title;
            dto.description = description;
            dto.conference = Guid.Parse(conference);
            dto.time = time;

            return dto;
        }
    }
}
