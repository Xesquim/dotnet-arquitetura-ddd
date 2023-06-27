using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Si;

namespace Api.Domain.Interfaces.Services.Si
{
    public interface ISiService
    {
        Task<SiDto> Get(Guid id);
        Task<IEnumerable<SiDto>> GetAll();
    }
}