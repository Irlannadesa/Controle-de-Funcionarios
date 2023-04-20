using ListaDePessoas.Modelo;
using static ListaDePessoas.Modelo.Funcionario;

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
            if (ChecarDados())
            {
                var funcionario = new Funcionario();
                funcionario.Nome = text_nome.Text;
                funcionario.CPF = mtb_cpf.Text;
                funcionario.Endereco = text_endereco.Text;
                funcionario.Telefone = mtb_telefone.Text;
                funcionario.DataNascimento = mtb_dtNascimento.Value;
                funcionario.DataAdmissao = mtb_dtAdimissao.Value;
                funcionario.Id = _id;
                if (mtb_sexo.Text == "Masculino")
                {
                    funcionario.Genero = Sexo.Masculino;
                }
                else
                {
                    funcionario.Genero = Sexo.Feminino;
                }
                _funcionarios.Add(funcionario);

                this.Close();

            }
            else
            {
                MessageBox.Show("Precisa preencher todos os campos", "Erro:");
            }
        }
        private bool ChecarDados()
        {
            if (!string.IsNullOrEmpty(text_nome.Text) && !string.IsNullOrEmpty(text_endereco.Text) &&
                !string.IsNullOrEmpty(mtb_telefone.Text) &&
                mtb_sexo.SelectedItem != null)


                return true;

            else

                return false;

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


