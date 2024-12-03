using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.dto
{
    public class ConferenceNoRefDto
    {
        public String id { get; set; }
        public String title { get; set; }
        public String status { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public String location { get; set; }
        public String description { get; set; }
        public List<String> organizationCommittee { get; set; }
        public List<String> programCommittee { get; set; }
        public List<String> sections { get; set; }
        public List<String> participants { get; set; }
    }
}
