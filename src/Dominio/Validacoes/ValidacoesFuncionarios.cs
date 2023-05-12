using Dominio.Modelo;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio.Validacoes
{
    public class ValidacoesFuncionarios
    {
        public static bool ValidarCPF(string cpf)
        {
            return Regex.IsMatch(cpf, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$");
        }

        public static bool ValidarTelefone(string telefone)
        {
            return Regex.IsMatch(telefone, @"^\(\d{2}\)\s\d{4}-\d{4}$");
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

        }
    }
}

