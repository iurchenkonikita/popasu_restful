namespace RESTFull.Service.dto
{

    public class ConferencePublicDto
    {
        public Guid id { get; set; }
        public String title { get; set; }
        public String status { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public String location { get; set; }
        public String description { get; set; }
        public List<SectionNoRefDto> sections { get; set; }
        public List<ParticipantNoRefDto> participants { get; set; }
    }
}
