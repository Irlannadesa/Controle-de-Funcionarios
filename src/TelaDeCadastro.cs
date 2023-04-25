using ListaDePessoas.Modelo;
using System.Text.RegularExpressions;


namespace ListaDePessoas
{
    public partial class TelaDeCadastro : Form
    {
        private List<Funcionario> _funcionarios;
        private int _id;
        private bool _eEdicao;

        public TelaDeCadastro(List<Funcionario> funcionarios, int id, bool eEdicao)
        {
            InitializeComponent();
            _funcionarios = funcionarios;
            _id = id;
            _eEdicao = eEdicao;

            if (eEdicao)
            {
                lbl_text_form_cadastro.Text = "Atualização de Funcionário";
                foreach (var funcionario in _funcionarios)
                {
                    if (funcionario.Id == id)
                    {
                        text_nome.Text = funcionario.Nome;
                        mtb_cpf.Text = funcionario.CPF;
                        text_endereco.Text = funcionario.Endereco;
                        mtb_telefone.Text = funcionario.Telefone;
                        mtb_dtNascimento.Value = funcionario.DataNascimento;
                        mtb_dtAdimissao.Value = funcionario.DataAdmissao;

                    }
                }
            }
        }

        private void AoClicarEmEnviar(object sender, EventArgs e)
        {
            if (Validar())
            {

                if (_eEdicao)
                {
                    foreach (var funcionario in _funcionarios)
                    {
                        if (funcionario.Id == _id)
                        {
                            funcionario.Nome = text_nome.Text;
                            funcionario.CPF = mtb_cpf.Text;
                            funcionario.Endereco = text_endereco.Text;
                            funcionario.Telefone = mtb_telefone.Text;
                            funcionario.DataNascimento = mtb_dtNascimento.Value;
                            funcionario.DataAdmissao = mtb_dtAdimissao.Value;
                        }
                    }
                }
                else
                {
                    var funcionario = new Funcionario();
                    funcionario.Nome = text_nome.Text;
                    funcionario.CPF = mtb_cpf.Text;
                    funcionario.Endereco = text_endereco.Text;
                    funcionario.Telefone = mtb_telefone.Text;
                    funcionario.DataNascimento = mtb_dtNascimento.Value;
                    funcionario.DataAdmissao = mtb_dtAdimissao.Value;
                    funcionario.Id = _id;

                    _funcionarios.Add(funcionario);
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Precisa preencher todos os campos", "Erro:");
            }

        }

        private bool Validar()
        {

            var ValidaCPF = mtb_cpf.Text;
            if (!Regex.IsMatch(ValidaCPF, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$") || string.IsNullOrEmpty(mtb_cpf.Text))
            {
                MessageBox.Show("CPF inválido!");
                return false;
            }

            var ValidaTelefone = mtb_telefone.Text;
            if (!Regex.IsMatch(ValidaTelefone, @"^\(\d{2}\)\s\d{4}-\d{4}$") || string.IsNullOrEmpty(mtb_telefone.Text))
            {
                MessageBox.Show("Telefone Inválido!");
                return false;
            }

            var ValidaDataNascimento = new DateTime();
            if (!DateTime.TryParse(mtb_dtNascimento.Text, out ValidaDataNascimento))
            {
                MessageBox.Show("Selecione uma data de Nascimento Válida!");
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


