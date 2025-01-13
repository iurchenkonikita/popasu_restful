using RESTFull.Service.dto;

namespace RESTFull.Service
{
    public interface ISectionService
    {
        public SectionPublicDto create(SectionCreateDto createDto);
        public SectionPublicDto update(SectionUpdateDto updateDto);
        public void delete(Guid id);
        public SectionPublicDto findById(Guid id);
        public List<SectionPublicDto> findAll();
    }
}
