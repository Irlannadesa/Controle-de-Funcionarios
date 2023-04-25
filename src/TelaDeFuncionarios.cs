using ListaDePessoas.Modelo;

namespace ListaDePessoas
{
    public partial class TelaDeFuncionarios : Form
    {
        private List<Funcionario> _funcionarios;
        private int _ultimoId;
        public TelaDeFuncionarios()
        {
            InitializeComponent();
            _funcionarios = new List<Funcionario>();
            _ultimoId = 0;
        }

        private void AoClicarEmCadastrar(object sender, EventArgs e)
        {
            _ultimoId = _ultimoId + 1;
            TelaDeCadastro form = new TelaDeCadastro(_funcionarios, _ultimoId, false);
            form.ShowDialog();
            dataGrid_funcionarios.DataSource = null;
            dataGrid_funcionarios.DataSource = _funcionarios;            
        }

        private void AoClicarEmEditar(object sender, EventArgs e)
        {
            int idParaEditar = (int)dataGrid_funcionarios.SelectedRows[0].Cells["Id"].Value;
            TelaDeCadastro formularioDeCadastro = new TelaDeCadastro(_funcionarios, idParaEditar, true);
            formularioDeCadastro.ShowDialog();
            dataGrid_funcionarios.DataSource = null;
            dataGrid_funcionarios.DataSource = _funcionarios;
        }
        private void AoClicarEmExcluir(object sender, EventArgs e)        
        {
            int idParaExcluir;

            if (dataGrid_funcionarios.SelectedRows.Count > 0)
            {
                idParaExcluir = (int)dataGrid_funcionarios.SelectedRows[0].Cells["Id"].Value;
                var confirmacaoExcluir = MessageBox.Show("Deseja excluir este funcionário?", "Confirmação:", MessageBoxButtons.YesNo);
                if (confirmacaoExcluir == DialogResult.No)
                {
                    return;
                }

                foreach (var funcionario in _funcionarios)
                {
                    if (funcionario.Id == idParaExcluir)
                    {
                        _funcionarios.Remove(funcionario);
                        break;
                    }
                }
                dataGrid_funcionarios.DataSource = null;
                dataGrid_funcionarios.DataSource = _funcionarios;
            }
            else
            {
                MessageBox.Show("Por favor, selecione um item para excluir.");
                return;
            }
        }
    }
}
