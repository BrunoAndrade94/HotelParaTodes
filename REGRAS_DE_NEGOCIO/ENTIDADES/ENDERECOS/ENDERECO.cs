using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES.ENDERECOS
{
    public class ENDERECO : TABELA_ENTIDADE
    {
        public string Numero { get; set; }
        [Required(ErrorMessage = "CEP é obrigatório.")]
        public string cep { get; set; }
        [Required(ErrorMessage = "Logradouro é obrigatório.")]
        public string logradouro { get; set; }
        public string complemento { get; set; }
        [Required(ErrorMessage = "Bairro é obrigatório.")]
        public string bairro { get; set; }
        public string localidade { get; set; }
        [Required(ErrorMessage = "UF é obrigatório.")]
        public string uf { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }
        public string ddd { get; set; }
        public string siafi { get; set; }
        
        public static ENDERECO DESSERIALIZAR_JSON(string json)
        {
            return JsonConvert.DeserializeObject<ENDERECO>(json);
        }

        public void VALIDAR_CLASSE()
        {
            var contextos = new ValidationContext(this, serviceProvider: null, items: null);
            var resultados = new List<ValidationResult>();
            var valido = Validator.TryValidateObject(this, contextos, resultados, true);

            if (valido == false)
            {
                var sbErros = new StringBuilder();
                foreach (var validarResultado in resultados)
                {
                    sbErros.AppendLine(validarResultado.ErrorMessage);
                }
                throw new ValidationException(sbErros.ToString());
            }
        }

        public override string ToString()
        {
            return $"{logradouro} {bairro}";
        }
    }
}
