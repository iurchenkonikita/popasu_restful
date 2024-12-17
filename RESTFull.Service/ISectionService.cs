using RESTFull.Domain;
using RESTFull.Service.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
