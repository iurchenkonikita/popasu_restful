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
        public Section create(SectionCreateDto createDto);
        public Section update(SectionUpdateDto updateDto);
        public void delete(Guid id);
        public Section findById(Guid id);
        public List<Section> findAll();
    }
}
