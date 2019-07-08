using Icatu.Integration.BusinessEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Integration.BusinessEntities
{
    public class AuthorizationVO
    {
        public string CardholderName { get; set; }
        public Int64 Number { get; set; }
        public int SecureCode { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CardBrand { get; set; }
        public string Password { get; set; }
        public string TypeCard { get; set; }
        public string HasPassword { get; set; }
        public decimal Limit { get; set; }
        public string ActiveCard { get; set; }

        public TransactionVO Transcao { get; set; }

        //public int IdCard { get; set; }

        //[Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
        //[StringLength(30)]
        //public string Nome { get; set; }

        //[Required(ErrorMessage = "O campo idade é obrigatório")]
        //public int Idade { get; set; }

        //[StringLength(11)]
        //[Required(ErrorMessage = "CPF obrigatório")]
        //[CustomValidationCPF(ErrorMessage = "CPF inválido")]
        //public string Cpf { get; set; }
    }
}
