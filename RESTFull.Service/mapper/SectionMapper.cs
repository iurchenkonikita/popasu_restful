using RESTFull.Domain;
using RESTFull.Service.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.mapper
{
    public class SectionMapper
    {
        public SectionMapper()
        {
        }

        public Section map(SectionCreateDto createDto)
        {
            Section section = new Section();

            section.title = createDto.title;
            section.description = createDto.description;
            section.time = createDto.time;

            return section;
        }
        public Section map(SectionUpdateDto updateDto)
        {
            Section section = new Section();

            section.Id = updateDto.id;
            section.title = updateDto.title;
            section.description = updateDto.description;
            section.time = updateDto.time;

            return section;
        }
    }
}
