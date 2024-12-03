using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using RESTFull.API.dto;
using RESTFull.Domain;
using RESTFull.Service.dto;
using RESTFull.Service.gateway;
using RESTFull.Service.mapper;

namespace RESTFull.Service
{
    
    public class ConferenceService : IConferenceService
    {
        private IConferenceRepository _conferenceRepository { get; set; }
        private IParticipantRepository _participantRepository { get; set; }
        private IReportRepository _reportRepostory { get; set; }
        private ISectionReporitory _sectionRepository { get; set; }
        private ConferenceMapper _mapper { get; set; }

        public ConferenceService(IConferenceRepository conferenceRepository, IParticipantRepository participantRepository, IReportRepository reportRepostory, ISectionReporitory sectionRepository, ConferenceMapper mapper)
        {
            // IConferenceRepository conference = new ConferenceRepository(context);
            //IParticipantRepository participantRepository = new ParticipantRepository(context);
            //IReportRepository reportRepository = new ReportRepository(context);
            //ISectionReporitory sectionReporitory = new SectionRepository(context);
            //ConferenceMapper mapper = new ConferenceMapper();
            _conferenceRepository = conferenceRepository;
            _participantRepository = participantRepository;
            _reportRepostory = reportRepostory;
            _sectionRepository = sectionRepository;
            _mapper = mapper;
        }

        public Conference create(ConferenceCreateDto createDto)
        {
            Conference conference = _mapper.map(createDto);
            return _conferenceRepository.Create(conference);
        }

       

        public void delete(Guid id)
        {
            _conferenceRepository.Delete(id);
        }


        public List<Conference> findAll()
        {
            List<Conference> conferences = _conferenceRepository.GetAll(); 
            foreach(Conference conference in  conferences)
            {
                List<Section> sections = _sectionRepository.GetByConferenceId(conference.Id);
                List<Participant> participants = _participantRepository.GetAllByConferenceId(conference.Id);
                conference.sections = sections;
                conference.participants = participants;
            }
            return conferences;
        }

        public Conference findById(Guid id)
        {
            Conference conference = _conferenceRepository.GetById(id); 
            
            List<Section> sections = _sectionRepository.GetByConferenceId(conference.Id);
            List<Participant> participants = _participantRepository.GetAllByConferenceId(conference.Id);
            conference.sections = sections;
            conference.participants = participants;

            return conference;

        }

        public Conference update(ConferenceUpdateDto updateDto)
        {
            Conference conference = _mapper.map(updateDto);
            return _conferenceRepository.Update(conference);
        }
    }
}
