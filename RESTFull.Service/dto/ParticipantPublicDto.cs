﻿namespace RESTFull.Service.dto
{
    public class ParticipantPublicDto
    {
        public String id { get; set; }
        public String name { get; set; }
        public String role { get; set; }
        public String contactInfo { get; set; }
        public String organization { get; set; }
        public List<ConferenceNoRefDto> conferences { get; set; }
        public List<ReportNoRefDto> reports { get; set; }
    }
}
