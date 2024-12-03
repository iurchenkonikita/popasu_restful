using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.dto
{
    public class SectionNoRefDto
    {
        public String Id { get; set; }
        public String title { get; set; }
        public String description { get; set; }
        public DateTime time { get; set; }
        public List<String> reports { get; set; }
        public String conference { get; set; }
    }
}
