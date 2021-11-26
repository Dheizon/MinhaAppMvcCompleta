using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IEnderecoTesteRepository : IRepository<EnderecoTeste>
    {
        Task<EnderecoTeste> ObterEnderecoTestePorId (Guid enderecoId);
        Task<IEnumerable<EnderecoTeste>> ObterEnderecosTeste();
    }
}
