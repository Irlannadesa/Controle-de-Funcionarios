using Dominio.Modelo;
using Infraestrutura;


namespace ControleDeFuncionarios
{
    public partial class TelaDeCadastro : Form
    {
        private int _id;
        private bool _eEdicao;
        private static RepositorioBancoDeDadosSqlFuncionarios repositorioFuncionarioSQL = new RepositorioBancoDeDadosSqlFuncionarios();

        public TelaDeCadastro(int id, bool eEdicao)
        {
            InitializeComponent();
            _id = id;
            _eEdicao = eEdicao;

            if (eEdicao)
            {
                TituloFormularioDeCadastro.Text = "Atualização de Funcionário";

                var funcionario = repositorioFuncionarioSQL.ObterPorId(id);
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
                var cpf = campoDeCpf.Text;
                var telefone = campoDeTelefone.Text;
                var dataNascimento = campoDeDataDeNascimento.Text;
                var endereco = campoDeEndereco.Text;
                var nome = campoDeNome.Text;

                if (ValidacoesFuncionarios.ValidarCampos(cpf, telefone, dataNascimento, endereco, nome))
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

                        repositorioFuncionarioSQL.Atualizar(funcionario);
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

                        repositorioFuncionarioSQL.Criar(funcionario);
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar enviar os dados do funcionário. Por favor, entre em contato com a equipe de suporte e informe o erro: " + ex.Message, "Erro");
            }
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


