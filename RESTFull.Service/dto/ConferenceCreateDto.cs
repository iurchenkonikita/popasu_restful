using RESTFull.Domain;

namespace RESTFull.API.dto
{
    public class ConferenceCreateDto
    {
        public String title { get; }
        public String status { get; }
        public DateTime startDate { get; }
        public DateTime endDate { get; }
        public String location { get; }
        public String description { get; }
        public List<String> organizationCommittee { get; }

        public ConferenceCreateDto(string title, string status, DateTime startDate, DateTime endDate, string location, string description, List<String> organizationCommittee)
        {
            this.title = title;
            this.status = status;
            this.startDate = startDate;
            this.endDate = endDate;
            this.location = location;
            this.description = description;
            this.organizationCommittee = organizationCommittee;
        }
    }
}
