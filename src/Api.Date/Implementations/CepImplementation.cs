using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Date.Context;
using Api.Date.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Date.Implementations
{
    public class CepImplementation : BaseRepository<CepEntity>, ICepRepository
    {

        private DbSet<CepEntity> _dataset;
        public CepImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<CepEntity>();
        }

        public async Task<CepEntity> SelectAsync(string cep)
        {
            return await _dataset.Include(c => c.Municipio)
                                 .ThenInclude(m => m.Uf)
                                 .SingleOrDefaultAsync(c => c.Cep.Equals(cep));
        }
    }
}
