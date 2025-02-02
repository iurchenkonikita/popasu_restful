﻿using RESTFull.Service.dto;

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
