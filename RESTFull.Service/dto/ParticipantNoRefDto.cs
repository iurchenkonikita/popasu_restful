namespace RESTFull.Service.dto
{
    public class ParticipantNoRefDto
    {
        public String id { get; set; }
        public String name { get; set; }
        public String role { get; set; }
        public String contactInfo { get; set; }
        public String organization { get; set; }
        public List<String> conferences { get; set; }
        public List<String> reports { get; set; }
    }
}
