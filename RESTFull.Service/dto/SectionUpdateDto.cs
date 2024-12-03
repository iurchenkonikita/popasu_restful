using RESTFull.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.dto
{
    public class SectionUpdateDto
    {
        public Guid id { get; }
        public String title { get; }
        public String description { get; }
        public DateTime time { get; }
        public List<Guid> reports { get; }

        public SectionUpdateDto(Guid id, string title, string description, DateTime time, List<Guid> reports)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.time = time;
            this.reports = reports;
        }
    }
}
