using RESTFull.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.dto
{
    public class ConferenceUpdateDto
    {
        public Guid id { get; }
        public String title { get; }
        public String status { get; }
        public DateTime startDate { get; }
        public DateTime endDate { get; }
        public String location { get; }
        public String description { get; }
        public List<String> organizationCommittee { get; }
        public List<String> programCommittee { get; }
        public List<String> sections { get; }
        public List<String> participants { get; }

        public ConferenceUpdateDto(Guid id, string title, string status, DateTime startDate, DateTime endDate, string location, string description, List<String> organizationCommittee, List<String> programCommittee, List<String> sections, List<String> participants)
        {
            this.id = id;
            this.title = title;
            this.status = status;
            this.startDate = startDate;
            this.endDate = endDate;
            this.location = location;
            this.description = description;
            this.organizationCommittee = organizationCommittee;
            this.programCommittee = programCommittee;
            this.sections = sections;
            this.participants = participants;
        }
    }
}
