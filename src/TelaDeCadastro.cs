using ListaDePessoas.Modelo;
using System.Text.RegularExpressions;

namespace ListaDePessoas
{
    public partial class TelaDeCadastro : Form
    {
        private int _id;
        private bool _eEdicao;
        private static RepositorioBancoDeDadosSqlFuncionarios repositorioFuncionario = new RepositorioBancoDeDadosSqlFuncionarios();

        public TelaDeCadastro(int id, bool eEdicao)
        {
            InitializeComponent();
            _id = id;
            _eEdicao = eEdicao;

            if (eEdicao)
            {
                TituloFormularioDeCadastro.Text = "Atualização de Funcionário";

                var funcionario = repositorioFuncionario.ObterPorId(id);
                campoDeNome.Text = funcionario.Nome;
                campoDeCpf.Text = funcionario.CPF;
                campoDeEndereco.Text = funcionario.Endereco;
                campoDeTelefone.Text = funcionario.Telefone;
                campoDeDataDeNascimento.Value = funcionario.DataNascimento;
                campoDeDataDeAdmissao.Value = funcionario.DataAdmissao;
            }
        }

        private void AoClicarEmEnviar(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    if (_eEdicao)
                    {
                        var funcionario = new Funcionario();
                        funcionario.Nome = campoDeNome.Text;
                        funcionario.CPF = campoDeCpf.Text;
                        funcionario.Endereco = campoDeEndereco.Text;
                        funcionario.Telefone = campoDeTelefone.Text;
                        funcionario.DataNascimento = campoDeDataDeNascimento.Value;
                        funcionario.DataAdmissao = campoDeDataDeAdmissao.Value;
                        funcionario.Id = _id;

                        repositorioFuncionario.Atualizar(funcionario);
                    }
                    else
                    {
                        var funcionario = new Funcionario();
                        funcionario.Nome = campoDeNome.Text;
                        funcionario.CPF = campoDeCpf.Text;
                        funcionario.Endereco = campoDeEndereco.Text;
                        funcionario.Telefone = campoDeTelefone.Text;
                        funcionario.DataNascimento = campoDeDataDeNascimento.Value;
                        funcionario.DataAdmissao = campoDeDataDeAdmissao.Value;
                        funcionario.Id = _id;

                        repositorioFuncionario.Criar(funcionario);
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar enviar os dados do funcionário. Por favor, entre em contato com a equipe de suporte e informe o erro: " + ex.Message, "Erro");
            }
        }

        private bool Validar()
        {
            var ValidaCPF = campoDeCpf.Text;
            if (!Regex.IsMatch(ValidaCPF, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$") || string.IsNullOrEmpty(campoDeCpf.Text))
            {
                MessageBox.Show("CPF inválido!");
                return false;
            }

            var ValidaTelefone = campoDeTelefone.Text;
            if (!Regex.IsMatch(ValidaTelefone, @"^\(\d{2}\)\s\d{4}-\d{4}$") || string.IsNullOrEmpty(campoDeTelefone.Text))
            {
                MessageBox.Show("Telefone Inválido!");
                return false;
            }

            var ValidaDataNascimento = new DateTime();
            if (!DateTime.TryParse(campoDeDataDeNascimento.Text, out ValidaDataNascimento))
            {
                MessageBox.Show("Selecione uma data de Nascimento Válida!");
                return false;
            }

            var ValidaEndereco = campoDeEndereco.Text;
            if (string.IsNullOrEmpty(campoDeEndereco.Text))
            {
                MessageBox.Show("O campo Endereço não pode estar vazio!");
                return false;
            }

            var ValidaNome = campoDeNome.Text;
            if (string.IsNullOrEmpty(campoDeNome.Text))
            {
                MessageBox.Show("O campo Nome não pode estar vazio!");
                return false;
            }

            return true;
        }

        private void AoClicarEmCancelar(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AoDigitarNoCampoNome(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}


