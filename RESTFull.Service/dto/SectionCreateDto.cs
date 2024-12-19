using RESTFull.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.dto
{
    public class SectionCreateDto
    {

        [MinLength(1, ErrorMessage = "Section's title can't be empty!")]
        public String title { get; }

        [MinLength(1, ErrorMessage = "Section's description can't be empty!")]
        public String description { get; }

        [Required(ErrorMessage = "Section's conference can't be empty!")]
        public Guid conference { get; }

        [Required(ErrorMessage = "Section's time must be specified!")]
        public DateTime time { get; }

        public SectionCreateDto(string title, string description, Guid conference, DateTime time)
        {
            this.title = title;
            this.description = description;
            this.conference = conference;
            this.time = time;
        }
    }
}
