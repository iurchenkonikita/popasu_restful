using RESTFull.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTFull.Domain
{
    public class Participant : BaseModel
    {
        public String name { get; set; }
        public String role { get; set; }
        public String contactInfo { get; set; }
        public String organization { get; set; }
        [NotMapped]
        public List<Conference> conferences { get; set; }
        [NotMapped]
        public List<Report> reports { get; set; }

        public void addConference(Conference conference)
        {
            conferences.Add(conference);
        }
        public void removeConference(Conference conference)
        {
            conferences.Remove(conference);
        }
        public void addReport(Report report)
        {
            reports.Add(report);
        }
        public void removeReport(Report report) {
            reports.Remove(report);
            }
    }
}
