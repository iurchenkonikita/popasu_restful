using RESTFull.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTFull.Domain
{
    public class Conference : BaseModel
    {
        public String title { get; set; }
        public String status { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public String location { get; set; }
        public String description { get; set; }
        [NotMapped]
        public List<Participant> organizationCommittee { get; set; }
        [NotMapped]
        public List<Participant> programCommittee { get; set; }
        [NotMapped]
        public List<Section> sections { get; set; }
        [NotMapped]
        public List<Participant> participants { get; set; }

        public void addOrganizationCommittee(Participant member)
        {
            organizationCommittee.Add(member);
        }
        public void removeOrganizationCommittee(Participant member)
        {
            organizationCommittee.Remove(member);
        }

        public void addProgramCommittee(Participant member)
        {
            programCommittee.Add(member);
        }
        public void removeProgramCommittee(Participant member) 
        { 
            programCommittee.Remove(member); 
        }

        public void addSection(Section section)
        {
            sections.Add(section);
        }
        public void removeSection(Section section) 
        { 
            sections.Remove(section); 
        }

        public void addParticipant(Participant participant)
        {
            participants.Add(participant);
        }
        public void removeParticipant(Participant participant) 
        { 
            participants.Remove(participant); 
        }
    }
}