using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IEnderecoTesteService : IDisposable
    {
        Task Adicionar(EnderecoTeste enderecoTeste);
        Task Atualizar(EnderecoTeste enderecoTeste);
        Task Remover(Guid id);
    }
}
