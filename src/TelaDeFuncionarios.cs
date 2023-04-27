using ListaDePessoas.Modelo;

namespace ListaDePessoas
{
    public partial class TelaDeFuncionarios : Form
    {
       
        private int _ultimoId;
        public TelaDeFuncionarios()
        {
            InitializeComponent();            
            _ultimoId = 0;
        }
        private void AoClicarEmCadastrar(object sender, EventArgs e)
        {
            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();
            _ultimoId = _ultimoId + 1;
            var telaDeCadastro = new TelaDeCadastro(_ultimoId, false);
            telaDeCadastro.ShowDialog();
            dataGrid_funcionarios.DataSource = null;
            dataGrid_funcionarios.DataSource = repositorioFuncionario.ObterTodos();            
        }
        


        private void AoClicarEmEditar(object sender, EventArgs e)
        {
            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();
            if (dataGrid_funcionarios.SelectedRows.Count > 0)
            {
                var idParaEditar = (int)dataGrid_funcionarios.SelectedRows[0].Cells["Id"].Value;
                var formularioDeCadastro = new TelaDeCadastro(idParaEditar, true);
                formularioDeCadastro.ShowDialog();
                dataGrid_funcionarios.DataSource = null;
                dataGrid_funcionarios.DataSource = repositorioFuncionario.ObterTodos();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um item para Editar.");
                return;
            }

        }
        private void AoClicarEmExcluir(object sender, EventArgs e)        
        {
            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();

            if (dataGrid_funcionarios.SelectedRows.Count > 0)
            {
                var idParaExcluir = (int)dataGrid_funcionarios.SelectedRows[0].Cells["Id"].Value;
                var confirmacaoExcluir = MessageBox.Show("Deseja excluir este funcionário?", "Confirmação:", MessageBoxButtons.YesNo);
                if (confirmacaoExcluir == DialogResult.No)
                {
                    return;
                }

                foreach (var funcionario in SingletonFuncionarios.ObterInstancia())
                {
                    if (funcionario.Id == idParaExcluir)
                    {
                        repositorioFuncionario.Remover(funcionario.Id);
                        break;
                    }
                }
                dataGrid_funcionarios.DataSource = null;
                dataGrid_funcionarios.DataSource = repositorioFuncionario.ObterTodos();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um item para excluir.");
                return;
            }
        }
    }
}
