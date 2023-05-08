using ListaDePessoas.Modelo;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;

namespace ListaDePessoas
{
    internal class RepositorioBancoDeDadosSqlFuncionarios : IFuncionarios
    {
        private static string conectionString = ConfigurationManager.ConnectionStrings["Funcionarios"].ConnectionString;
        SqlConnection sqlconecxao = new SqlConnection(conectionString);
        protected List<Funcionario> listaDeFuncionario = new List<Funcionario>();


        public List<Funcionario> ObterTodos()
        {           

            try
            {
                sqlconecxao.Open();
                SqlCommand comando = new SqlCommand("SELECT * FROM Funcionario", sqlconecxao);
                comando.CommandType = System.Data.CommandType.Text;
                SqlDataReader dataReader = comando.ExecuteReader();
            
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Erro de conexão com o banco de dados" + ex.Message, "Erro:");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar enviar os dados do funcionário. Por favor, entre em contato com a equipe de suporte e informe o erro:" + ex.Message, "Erro:");
            }
            finally
            {
                sqlconecxao.Close();
            }

            return listaDeFuncionario;
        }

        public void Atualizar(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public void Criar(Funcionario novoFuncionario)
        {
            try
            {
                sqlconecxao.Open();
                var incluirFuncionarioNoSQL = @"INSERT INTO Funcionario (Nome, Endereco, CPF, Telefone, Data_Nascimento, Data_Admissao) VALUES (@Nome, @Endereco, @CPF, @Telefone, @Data_Nascimento, @Data_Admissao) ";
                SqlCommand comandoAddFuncionario = new SqlCommand(incluirFuncionarioNoSQL, sqlconecxao);

                comandoAddFuncionario.Parameters.AddWithValue("@Nome", novoFuncionario.Nome);
                comandoAddFuncionario.Parameters.AddWithValue("@Endereco", novoFuncionario.Endereco);
                comandoAddFuncionario.Parameters.AddWithValue("@CPF", novoFuncionario.CPF);
                comandoAddFuncionario.Parameters.AddWithValue("@Telefone", novoFuncionario.Telefone);
                comandoAddFuncionario.Parameters.AddWithValue("@Data_Nascimento", novoFuncionario.DataNascimento);
                comandoAddFuncionario.Parameters.AddWithValue("@Data_Admissao", novoFuncionario.DataAdmissao);

                comandoAddFuncionario.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro de conexão com o banco de dados: " + ex.Message);
            }
            finally
            {
                sqlconecxao.Close();
            }
        }


        public void Remover(int id)
        {
            throw new NotImplementedException();
        }

        public Funcionario ObterPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
