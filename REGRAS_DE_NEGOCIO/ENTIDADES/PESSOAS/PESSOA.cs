using HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES;
using HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES.ENDERECOS;
using System;
using System.ComponentModel.DataAnnotations;

namespace HPT_DLL.Entidades
{
    public class PESSOA : TABELA_ENTIDADE
    {
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Sobreome é obrigatório!")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "RG é obrigatório!")]
        public string RG { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório!")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório!")]
        [RegularExpression(@"^([\w.]+)(@)([\w]+)([.\w]+)([.\w]+)?$", ErrorMessage = "Informe um email válido!")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Sexo é obrigatório!")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório!")]
        public ENDERECO Endereco { get; set; } = new ENDERECO();

        [Required(ErrorMessage = "Data de nascimento é obrigatório!")]
        public DateTime Nascimento { get; set; }
    }
}
