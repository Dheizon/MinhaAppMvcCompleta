using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{
    public class EnderecoTesteService : BaseService, IEnderecoTesteService
    {
        private readonly IEnderecoTesteRepository _enderecoTesteRepository;

        public EnderecoTesteService(IEnderecoTesteRepository enderecoTesteRepository, INotificador notificador) : base(notificador)
        {
            _enderecoTesteRepository = enderecoTesteRepository;
        }

        public async Task Adicionar(EnderecoTeste enderecoTeste)
        {
           
            if (!ExecutarValidacao(new EnderecoTesteValidation(), enderecoTeste)) return;

            if (_enderecoTesteRepository.Buscar(d => d.CEP == enderecoTeste.CEP).Result.Any())
            {
                Notificar("Já existe um Cep como mesmo código cadastrado.");
                return;
            }

            await _enderecoTesteRepository.Adicionar(enderecoTeste);
        }

        public async Task Atualizar(EnderecoTeste enderecoTeste)
        {
            if (!ExecutarValidacao(new EnderecoTesteValidation(), enderecoTeste)) return;

            await _enderecoTesteRepository.Atualizar(enderecoTeste);
        }

        public void Dispose()
        {
            _enderecoTesteRepository?.Dispose();
        }

        public async Task Remover(Guid id)
        {
            await _enderecoTesteRepository.Remover(id);
        }
    }
}
