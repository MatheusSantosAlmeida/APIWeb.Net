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
    public class UfImplementation : BaseRepository<UfEntity>, IUfRepository
    {

        private DbSet<UfEntity> _dataset;
        public UfImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<UfEntity>();
        }

        public async Task<UfEntity> SelectAsync(string sigla)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Sigla.Equals(sigla));
        }
    }
}
