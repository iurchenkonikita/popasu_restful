namespace RESTFull.Service.dto
{
    public class SectionNoRefDto
    {
        public String Id { get; set; }
        public String title { get; set; }
        public String description { get; set; }
        public DateTime time { get; set; }
        public List<Guid> reports { get; set; }
        public Guid conference { get; set; }
    }
}
