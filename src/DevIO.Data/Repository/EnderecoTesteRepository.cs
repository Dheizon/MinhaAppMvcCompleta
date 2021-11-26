using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class EnderecoTesteRepository : Repository<EnderecoTeste>, IEnderecoTesteRepository
    {
        public EnderecoTesteRepository(MeuDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<EnderecoTeste>> ObterEnderecosTeste()
        {
            return await Db.EnderecosTeste.AsNoTracking()
                .OrderBy(p => p.Cidade).ToListAsync();
        }

        public async Task<EnderecoTeste> ObterEnderecoTestePorId(Guid enderecoId)
        {
            return await Db.EnderecosTeste.AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == enderecoId);
        }
    }
}
