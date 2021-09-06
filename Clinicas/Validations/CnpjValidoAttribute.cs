using System.ComponentModel.DataAnnotations;

namespace Clinicas.Validations
{
    public class CnpjValidoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var propriedade = context.ObjectType.GetProperty("Cnpj");
            var valor = (string)propriedade.GetValue(context.ObjectInstance);

            return ValidarCnpj(valor) ?
                ValidationResult.Success :
                new ValidationResult("Informe um CNPJ válido");
        }

        private static bool ValidarCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma;
            int resto;
            string digito;
            string tempCnpj;

            if (cnpj.Length != 14)
                return false;

            if (cnpj == "00000000000000")
                return false;

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito = resto.ToString();
            tempCnpj += digito;

            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            return cnpj.EndsWith(digito += resto.ToString());
        }
    }
}