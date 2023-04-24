using ListaDePessoas.Modelo;
using System.Text.RegularExpressions;


namespace ListaDePessoas
{
    public partial class Form_Cadastro : Form
    {
        private List<Funcionario> _funcionarios;
        private int _id;

        public Form_Cadastro(List<Funcionario> funcionarios, int id)
        {
            InitializeComponent();
            _funcionarios = funcionarios;
            _id = id;

        }

        private void btn_enviar_cadastro_Click(object sender, EventArgs e)
        {
            if (Validacoes())
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

                this.Close();

            }
            else
            {
                MessageBox.Show("Precisa preencher todos os campos", "Erro:");
            }
        }

        private bool Validacoes()
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



        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void text_nome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}


