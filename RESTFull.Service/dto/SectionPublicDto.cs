using RESTFull.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.dto
{
    public class SectionPublicDto
    {
        public String Id { get; set; }
        public String title { get; set; }
        public String description { get; set; }
        public DateTime time { get; set; }
        public List<ReportNoRefDto> reports { get; set; }
        public ConferenceNoRefDto conference { get; set; }

    }
}
