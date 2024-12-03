using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.dto
{
    public class ReportNoRefDto
    {
        public String Id { get; set; }
        public String title { get; set; }
        public String annotation { get; set; }
        public DateTime presentationTime { get; set; }
        public String section { get; set; }
        public List<String> authors { get; set; }
    }
}
