using Dominio.Modelo;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio.Validacoes
{
    public class ValidacoesFuncionarios
    {
        public static bool ValidarCPF(string cpf)
        {
           
            cpf = Regex.Replace(cpf, @"[^0-9]", "");
            
            if (cpf.Length != 11)
            {
                return false;
            }
            
            if (new string(cpf[0], 11) == cpf)
            {
                return false;
            }

            
            int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string cpfSemDigitos = cpf.Substring(0, 9);
            string digito1 = cpf.Substring(9, 1);
            string digito2 = cpf.Substring(10, 1);

            int soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpfSemDigitos[i].ToString()) * multiplicadores1[i];
            }

            int resto = soma % 11;
            int resultado1 = (resto < 2) ? 0 : 11 - resto;

            if (digito1 != resultado1.ToString())
            {
                return false;
            }

            soma = 0;
            cpfSemDigitos += resultado1;

            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpfSemDigitos[i].ToString()) * multiplicadores2[i];
            }

            resto = soma % 11;
            int resultado2 = (resto < 2) ? 0 : 11 - resto;

            return digito2 == resultado2.ToString();
        }


        public static bool ValidarTelefone(string telefone)
        {
            return Regex.IsMatch(telefone, @"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$");
        }

        public static bool ValidarDataNascimento(DateTime dataNascimento)
        {           

            DateTime dataAtual = DateTime.Now;
            int idade = dataAtual.Year - dataNascimento.Year;
            
            if (dataNascimento.AddYears(idade) > dataAtual)
                idade--;

            if (dataNascimento.Month < 1 || dataNascimento.Month > 12)
                return false;
            else if (dataNascimento.Day < 1 || dataNascimento.Day > DateTime.DaysInMonth(dataNascimento.Year, dataNascimento.Month))
                return false;
            else if (idade < 18 || idade >= 60)
                return false;

            return true;

        }


        public static void ValidarCampos(Funcionario funcionario)
        {

            if (!ValidarDataNascimento(funcionario.DataNascimento))
            {
                throw new Exception("Campo Data de Nascimento não foi preenchido ou esta inválido!");
            }

            if (string.IsNullOrEmpty(funcionario.Endereco))
            {
                throw new Exception("Campo Endereço não foi preenchido ou esta inválido!");
            }

            if (string.IsNullOrEmpty(funcionario.Nome))
            {
                throw new Exception("Campo Nome não foi preenchido ou esta inválido!");
            }
            if (!ValidarCPF(funcionario.CPF) || string.IsNullOrEmpty(funcionario.CPF))
            {
                throw new Exception("Campo CPF não foi preenchido ou esta inválido!");

            }
            if (!ValidarTelefone(funcionario.Telefone) || string.IsNullOrEmpty(funcionario.Telefone))
            {
                throw new Exception("Campo Telefone não foi preenchido ou esta inválido!");
            }
            if (!ValidarCPF(funcionario.CPF))
            {
                throw new Exception("Campo CPF é inválido.");
            }
            if (!ValidarTelefone(funcionario.Telefone))
            {
                throw new Exception("Campo Telefone é inválido.");
            }

            if (!ValidarDataNascimento(funcionario.DataNascimento))
            {
                throw new Exception("Campo Data de Nascimento é inválido.");
            }

        }
    }
}

