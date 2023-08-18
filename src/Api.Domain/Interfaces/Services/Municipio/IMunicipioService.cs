using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;

namespace Api.Domain.Interfaces.Services.Municipio
{
    public interface IMunicipioService
    {
        Task<MunicipioDto> Get(Guid id);

        Task<MunicipioDtoCompleto> GetCompleteById(Guid id);

        Task<MunicipioDtoCompleto> GetCompleteByIBGE(int codIBGE);

        Task<IEnumerable<MunicipioDto>> GetAll();

        Task<MunicipioCreatDtoResult> Post(MunicipioDtoCreat user);

        Task<MunicipioDtoUpdateResult> Put(MunicipioDtoUpdate user);

        Task<bool> Delete(Guid id);
    }
}
