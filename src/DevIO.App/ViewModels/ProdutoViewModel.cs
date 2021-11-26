using DevIO.App.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DevIO.App.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Fornecedor")]       
        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage ="O campo é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre 2 e 200 caracteres", MinimumLength =2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Descrição")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre 2 e 1000 caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        
        [DisplayName("Imagem do Produto")]        
        public IFormFile ImagemUpload { get; set; }

        [Moeda]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        public DateTime DataCadastro { get; set; }
        
        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        public FornecedorViewModel Fornecedor { get; set; }
        
        public IEnumerable<FornecedorViewModel> Fornecedores { get; set; }
    }
}
