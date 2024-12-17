using RESTFull.API.dto;
using RESTFull.Service.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Domain
{
    public interface IConferenceService
    {
        public ConferencePublicDto findById(Guid id);
        public List<ConferencePublicDto> findAll();
        public ConferencePublicDto create(ConferenceCreateDto createDto);
        public ConferencePublicDto update(ConferenceUpdateDto updateDto);
        public void delete(Guid id);

        }
}
