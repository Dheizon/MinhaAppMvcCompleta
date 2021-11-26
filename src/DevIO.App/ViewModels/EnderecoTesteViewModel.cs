using System;
using System.ComponentModel.DataAnnotations;

namespace DevIO.App.ViewModels
{
    public class EnderecoTesteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(8, ErrorMessage = "O campo {0} precisa ter 8 caracteres", MinimumLength = 8)]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre 2 e 200 caracteres", MinimumLength = 2)]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(32, ErrorMessage = "O campo {0} precisa ter entre 3 e 32 caracteres", MinimumLength = 3)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(32, ErrorMessage = "O campo {0} precisa ter entre 3 e 32 caracteres", MinimumLength = 3)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(2, ErrorMessage = "O campo {0} precisa ter 2 caracteres", MinimumLength = 2)]
        public string UF { get; set; }
        
        public string IBGE { get; set; }
        public string SIAFI { get; set; }

    }
}
