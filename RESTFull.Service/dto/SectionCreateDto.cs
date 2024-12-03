using RESTFull.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.dto
{
    public class SectionCreateDto
    {
        public String title { get; }
        public String description { get; }
        public DateTime time { get; }

        public SectionCreateDto(string title, string description, DateTime time)
        {
            this.title = title;
            this.description = description;
            this.time = time;
        }
    }
}
