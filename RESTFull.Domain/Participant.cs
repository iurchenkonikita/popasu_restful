using RESTFull.Domain.Base;

namespace RESTFull.Domain
{
    public class Participant : BaseModel
    {
        public String name { get; set; }
        public String role { get; set; }
        public String contactInfo { get; set; }
        public String organization { get; set; }
        public List<Conference> conferences { get; set; } = new List<Conference>();
        public List<Report> reports { get; set; } = new List<Report>();

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
        public void removeReport(Report report)
        {
            reports.Remove(report);
        }
    }
}
