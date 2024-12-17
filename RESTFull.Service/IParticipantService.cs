using RESTFull.Domain;
using RESTFull.Service.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service
{
    public interface IParticipantService
    {
        public ParticipantPublicDto create(ParticipantCreateDto createDto);
        public ParticipantPublicDto update(ParticipantUpdateDto updateDto);
        public void delete(Guid id);
        public ParticipantPublicDto findById(Guid id);
        public List<ParticipantPublicDto> findAll();
    }
}
