using ListaDePessoas.Modelo;

namespace ListaDePessoas
{
    public partial class Janela_Principal : Form
    {
        private List<Funcionario> _funcionarios;
        private int _ultimoId;
        public Janela_Principal()
        {
            InitializeComponent();
            _funcionarios = new List<Funcionario>();
            _ultimoId = 0;
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            _ultimoId = _ultimoId + 1;
            Form_Cadastro form = new Form_Cadastro(_funcionarios, _ultimoId);
            form.ShowDialog();
            dataGrid_funcionarios.DataSource = null;
            dataGrid_funcionarios.DataSource = _funcionarios;
            dataGrid_funcionarios.Refresh();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {

        }
        private void btn_excluir_Click(object sender, EventArgs e)        {


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
