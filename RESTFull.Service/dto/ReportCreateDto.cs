using RESTFull.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.dto
{
    public class ReportCreateDto
    {
        public String title { get; }
        public String annotation { get; }
        public List<String> authors { get; }
        public DateTime presentationTime { get; }
        public String section { get; }

        public ReportCreateDto(string title, string annotation, List<String> authors, DateTime presentationTime, String section)
        {
            this.title = title;
            this.annotation = annotation;
            this.authors = authors;
            this.presentationTime = presentationTime;
            this.section = section;
        }
    }
}
