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

        public ConferencePublicDto create(ConferenceCreateDto createDto)
        {
            Conference conference = _mapper.map(createDto);
            conference = _conferenceRepository.Create(conference);
            return _mapper.map(conference);
        }

       

        public void delete(Guid id)
        {
            _conferenceRepository.Delete(id);
        }


        public List<ConferencePublicDto> findAll()
        {
            List<Conference> conferences = _conferenceRepository.GetAll(); 
            foreach(Conference conference in  conferences)
            {
                List<Section> sections = _sectionRepository.GetByConferenceId(conference.Id);
                List<Participant> participants = _participantRepository.GetAllByConferenceId(conference.Id);
                conference.sections = sections;
                conference.participants = participants;
            }
            List<ConferencePublicDto> dtos = conferences.Aggregate(new List<ConferencePublicDto>(), 
                (t, c) => {
                    t.Add(_mapper.map(c)); return t;
                });
            return dtos;
        }

        public ConferencePublicDto findById(Guid id)
        {
            Conference conference = _conferenceRepository.GetById(id); 
            
            List<Section> sections = _sectionRepository.GetByConferenceId(conference.Id);
            List<Participant> participants = _participantRepository.GetAllByConferenceId(conference.Id);
            conference.sections = sections;
            conference.participants = participants;

            return _mapper.map(conference);

        }

        public ConferencePublicDto update(ConferenceUpdateDto updateDto)
        {
            Conference conference = _mapper.map(updateDto);
            conference= _conferenceRepository.Update(conference);

            return _mapper.map(conference);
        }
    }
}
