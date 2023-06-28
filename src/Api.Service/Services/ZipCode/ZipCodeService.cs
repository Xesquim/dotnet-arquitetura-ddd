using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.ZipCode;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.ZipCode;
using Api.Domain.Models.ZipCode;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services.ZipCode
{
    public class ZipCodeService : IZipCodeService
    {
        private IZipCodeRepository _repository;
        private readonly IMapper _mapper;

        public ZipCodeService(IZipCodeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ZipCodeDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<ZipCodeDto>(entity);
        }

        public async Task<ZipCodeDto> Get(string zipCode)
        {
            var entity = await _repository.SelectAsync(zipCode);
            return _mapper.Map<ZipCodeDto>(entity);
        }

        public async Task<ZipCodeDtoCreateResult> Post(ZipCodeDtoCreate zipCode)
        {
            var model = _mapper.Map<ZipCodeModel>(zipCode);
            var entity = _mapper.Map<ZipCodeEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<ZipCodeDtoCreateResult>(result);
        }

        public async Task<ZipCodeDtoUpdateResult> Put(ZipCodeDtoUpdate zipCode)
        {
            var model = _mapper.Map<ZipCodeModel>(zipCode);
            var entity = _mapper.Map<ZipCodeEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<ZipCodeDtoUpdateResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}