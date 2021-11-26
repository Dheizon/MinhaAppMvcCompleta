using AutoMapper;
using DevIO.App.ViewModels;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.App.Controllers
{
    [Authorize]
    public class EnderecosTesteController : BaseController
    {
        private readonly IEnderecoTesteRepository _enderecoTesteRepository;
        private readonly IEnderecoTesteService _enderecoTesteService;
        private readonly IMapper _mapper;

        public EnderecosTesteController(IEnderecoTesteRepository enderecoTesteRepository, IMapper mapper, IEnderecoTesteService enderecoTesteService, INotificador notificador) : base(notificador)
        {
            _enderecoTesteRepository = enderecoTesteRepository;
            _mapper = mapper;
            _enderecoTesteService = enderecoTesteService;
        }

        [Route("lista-enderecos")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<EnderecoTesteViewModel>>(await _enderecoTesteRepository.ObterEnderecosTeste()));
        }

        [Route("dados-do-enderecoTeste/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var enderecoTesteViewModel = await ObterEnderecoTeste(id);

            if (enderecoTesteViewModel == null)
            {
                return NotFound();
            }

            return View(enderecoTesteViewModel);
        }

        [Route("novo-enderecoTeste")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("novo-enderecoTeste")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EnderecoTesteViewModel enderecoTesteViewModel)
        {
            if (!ModelState.IsValid) return View(enderecoTesteViewModel);

            var enderecoTeste = _mapper.Map<EnderecoTeste>(enderecoTesteViewModel);
            await _enderecoTesteService.Adicionar(enderecoTeste);

            if (!OperacaoValida()) return View(enderecoTesteViewModel);

            return RedirectToAction(nameof(Index));
            
        }

        [Route("editar-enderecoTeste/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enderecoTesteViewModel = await ObterEnderecoTeste(id);

            if (enderecoTesteViewModel == null)
            {
                return NotFound();
            }
            return View(enderecoTesteViewModel);
        }

        [Route("editar-enderecoTeste/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EnderecoTesteViewModel enderecoTesteViewModel)
        {
            if (id != enderecoTesteViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(enderecoTesteViewModel);

            var enderecoTeste = _mapper.Map<EnderecoTeste>(enderecoTesteViewModel);
            await _enderecoTesteService.Atualizar(enderecoTeste);

            if (!OperacaoValida()) return View(await ObterEnderecoTeste(id));

            return RedirectToAction("Index");
            
        }

        [Route("excluir-enderecoTeste/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enderecoTesteViewModel = await ObterEnderecoTeste(id);                
            if (enderecoTesteViewModel == null)
            {
                return NotFound();
            }

            return View(enderecoTesteViewModel);
        }

        [Route("excluir-enderecoTeste/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var endereco = await ObterEnderecoTeste(id);

            if (endereco == null) return NotFound();

            await _enderecoTesteRepository.Remover(id);

            if (!OperacaoValida()) return View(endereco);

            TempData["Sucesso"] = "Endereço excluído com sucesso!";
            
            return RedirectToAction(nameof(Index));
        }

        private async Task<EnderecoTesteViewModel> ObterEnderecoTeste(Guid id)
        {
            return _mapper.Map<EnderecoTesteViewModel>(await _enderecoTesteRepository.ObterEnderecoTestePorId(id));
        }

    }
}
