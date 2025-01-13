namespace RESTFull.Service.dto
{
    public class ReportPublicDto
    {
        public String Id { get; set; }
        public String title { get; set; }
        public String annotation { get; set; }
        public DateTime presentationTime { get; set; }
        public SectionNoRefDto section { get; set; }
        public List<ParticipantNoRefDto> authors { get; set; }
    }
}
