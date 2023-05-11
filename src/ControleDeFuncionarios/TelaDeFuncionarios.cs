using Infraestrutura;

namespace ControleDeFuncionarios
{
    public partial class TelaDeFuncionarios : Form
    {
        public IFuncionarios _repositorioFuncionarios;
     
        public TelaDeFuncionarios(IFuncionarios repositorioFuncionario)
        {
            InitializeComponent();
            _repositorioFuncionarios = repositorioFuncionario;
            AtualizarLista();          
        }
          

        private void AoClicarEmCadastrar(object sender, EventArgs e)
        {
            try
            {
                var telaDeCadastro = new TelaDeCadastro(0, false);
                telaDeCadastro.ShowDialog();          

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao tentar cadastrar um funcionário, Por favor, entre em contato com a equipe de suporte e informe o erro:" + ex.Message, "Erro");
            }
            AtualizarLista();
        }


        private void AoClicarEmEditar(object sender, EventArgs e)
        {
            try
            {
                if (dataGrid_funcionarios.SelectedRows.Count > 0)
                {
                    var idParaEditar = (int)dataGrid_funcionarios.SelectedRows[0].Cells["Id"].Value;
                    var formularioDeCadastro = new TelaDeCadastro(idParaEditar, true);
                    formularioDeCadastro.ShowDialog();
                    AtualizarLista();
                }
                else
                {
                    MessageBox.Show("Por favor, selecione um item para Editar.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao tentar editar os dados do funcionário, Por favor, entre em contato com a equipe de suporte e informe o erro:" + ex.Message, "Erro");
            }
        }

        private void AoClicarEmExcluir(object sender, EventArgs e)
        {
            try
            {
                if (dataGrid_funcionarios.SelectedRows.Count > 0)
                {
                    var idParaExcluir = (int)dataGrid_funcionarios.SelectedRows[0].Cells["Id"].Value;
                    var confirmacaoExcluir = MessageBox.Show("Deseja excluir este funcionário?", "Confirmação:", MessageBoxButtons.YesNo);
                    if (confirmacaoExcluir == DialogResult.No)
                    {
                        return;
                    }

                    _repositorioFuncionarios.Remover(idParaExcluir);

                    AtualizarLista();
                }
                else
                {
                    MessageBox.Show("Por favor, selecione um item para excluir.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar excluir o funcionário. Por favor, entre em contato com a equipe de suporte e informe o erro: " + ex.Message, "Erro");
            }
        }

        public void AtualizarLista()
        {
            dataGrid_funcionarios.DataSource = null;
            dataGrid_funcionarios.DataSource = _repositorioFuncionarios.ObterTodos();
        }
    } 
}
