﻿using RESTFull.Domain.Base;

namespace RESTFull.Domain
{
    public class Report : BaseModel
    {
        public String title { get; set; }
        public String annotation { get; set; }
        public List<Participant> authors { get; set; } = [];
        public DateTime presentationTime { get; set; }
        public Section section { get; set; }
    }
}
