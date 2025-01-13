using RESTFull.Domain.Base;

namespace RESTFull.Domain
{
    public class Section : BaseModel
    {
        public String title { get; set; }
        public String description { get; set; }
        public DateTime time { get; set; }
        public List<Report> reports { get; set; } = [];
        public Conference conference { get; set; }

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
