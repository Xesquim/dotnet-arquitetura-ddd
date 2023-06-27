using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Si;
using Api.Domain.Interfaces.Services.Si;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services.Si
{
    public class SiService : ISiService
    {
        private ISiRepository _repository;
        private readonly IMapper _mapper;

        public SiService(ISiRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SiDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<SiDto>(entity);
        }

        public async Task<IEnumerable<SiDto>> GetAll()
        {
            var listEntities = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<SiDto>>(listEntities);
        }
    }
}