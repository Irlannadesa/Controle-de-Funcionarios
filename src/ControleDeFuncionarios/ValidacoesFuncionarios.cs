using System.Text.RegularExpressions;

namespace ControleDeFuncionarios
{
    internal class ValidacoesFuncionarios
    {
        public static bool ValidarCampos(string cpf, string telefone, string dataNascimento, string endereco, string nome)
        {
            if (!ValidarCPF(cpf) || string.IsNullOrEmpty(cpf))
            {
                MessageBox.Show("CPF inválido!");
                return false;
            }

            if (!ValidarTelefone(telefone) || string.IsNullOrEmpty(telefone))
            {
                MessageBox.Show("Telefone Inválido!");
                return false;
            }

            if (!ValidarDataNascimento(dataNascimento))
            {
                MessageBox.Show("Selecione uma data de Nascimento Válida!");
                return false;
            }

            if (string.IsNullOrEmpty(endereco))
            {
                MessageBox.Show("O campo Endereço não pode estar vazio!");
                return false;
            }

            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("O campo Nome não pode estar vazio!");
                return false;
            }

            return true;
        }

        private static bool ValidarCPF(string cpf)
        {
            return Regex.IsMatch(cpf, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$");
        }

        private static bool ValidarTelefone(string telefone)
        {
            return Regex.IsMatch(telefone, @"^\(\d{2}\)\s\d{4}-\d{4}$");
        }

        private static bool ValidarDataNascimento(string dataNascimento)
        {
            return DateTime.TryParse(dataNascimento, out _);
        }
    }
}

