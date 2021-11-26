using AppMvcBasica.Models;

namespace DevIO.Business.Models
{
    public class EnderecoTeste : Entity
    {
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Bairro { get; set; }
        public string IBGE { get; set; }
        public string SIAFI { get; set; }

    }
}
