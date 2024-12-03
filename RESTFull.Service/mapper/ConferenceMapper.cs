using RESTFull.API.dto;
using RESTFull.Domain;
using RESTFull.Service.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.mapper
{
    public class ConferenceMapper
    {
        public ConferenceMapper()
        {
        }

        public Conference map(ConferenceCreateDto createDto)
        {
            Conference result = new Conference();

            result.title = createDto.title;
            result.status = createDto.status;
            result.startDate = createDto.startDate;
            result.endDate = createDto.endDate;
            result.description = createDto.description;
            result.location = createDto.location;

            return result;
        }
        public Conference map(ConferenceUpdateDto updateDto)
        {
            Conference result = new Conference();

            result.Id = updateDto.id;
            result.title = updateDto.title;
            result.status = updateDto.status;
            result.startDate = updateDto.startDate;
            result.endDate = updateDto.endDate;
            result.description = updateDto.description;
            result.location = updateDto.location;
            

            return result;
        }
    }
}
