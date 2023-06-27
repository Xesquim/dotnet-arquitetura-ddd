using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.ZipCode;

namespace Api.Domain.Interfaces.Services.ZipCode
{
    public interface IZipCodeService
    {
        Task<ZipCodeDto> Get(Guid id);
        Task<ZipCodeDto> Get(string zipCode);
        Task<ZipCodeDtoCreateResult> Post(ZipCodeDtoCreate zipCode);
        Task<ZipCodeDtoUpdateResult> Put(ZipCodeDtoUpdate zipCode);
        Task<bool> Delete(Guid id);
    }
}