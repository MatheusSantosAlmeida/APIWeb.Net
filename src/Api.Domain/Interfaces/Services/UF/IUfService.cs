using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Uf;

namespace Api.Domain.Interfaces.Services.UF
{
    public interface IUfService
    {
        Task<UfDto> Get(Guid id);

        Task<UfDto> Get(string sigla);

        Task<IEnumerable<UfDto>> GetAll();
    }
}
