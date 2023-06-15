using Dominio.Modelo;
using Microsoft.Data.SqlClient;
using System.Configuration;


namespace Infraestrutura.Repositorio
{
    public class RepositorioBancoDeDadosSqlFuncionarios : IFuncionarios
    {
        private static string conectionString = ConfigurationManager.ConnectionStrings["Funcionarios"].ConnectionString;
        SqlConnection sqlconecxao = new SqlConnection(conectionString);
        protected List<Funcionario> listaDeFuncionario = new List<Funcionario>();

        public List<Funcionario> ObterTodos()
        {
            List<Funcionario> listaDeFuncionario = new List<Funcionario>();

            try
            {
                sqlconecxao.Open();
                SqlCommand comando = new SqlCommand("SELECT * FROM Funcionario", sqlconecxao);
                comando.CommandType = System.Data.CommandType.Text;
                SqlDataReader dataReader = comando.ExecuteReader();

                while (dataReader.Read())
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.Id = Convert.ToInt32(dataReader["Id"]);
                    funcionario.Nome = dataReader["Nome"].ToString();
                    funcionario.Endereco = dataReader["Endereco"].ToString();
                    funcionario.CPF = dataReader["CPF"].ToString();
                    funcionario.Telefone = dataReader["Telefone"].ToString();
                    funcionario.DataNascimento = Convert.ToDateTime(dataReader["Data_Nascimento"]);
                    funcionario.DataAdmissao = Convert.ToDateTime(dataReader["Data_Admissao"]);

                    listaDeFuncionario.Add(funcionario);
                }

                dataReader.Close();
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                sqlconecxao.Close();
            }

            return listaDeFuncionario;
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
            catch (Exception)
            {
                throw;

            }
            finally
            {
                sqlconecxao.Close();
            }
        }

        public Funcionario Atualizar(Funcionario funcionario)
        {
            var Id = funcionario.Id;
            try
            {
                sqlconecxao.Open();
                var atualizarFuncionarioNoSQL = @"UPDATE Funcionario SET Nome=@Nome, Endereco=@Endereco, CPF=@CPF, Telefone=@Telefone, Data_Nascimento=@Data_Nascimento, Data_Admissao=@Data_Admissao WHERE Id=@Id";
                SqlCommand comandoAtualizarFuncionario = new SqlCommand(atualizarFuncionarioNoSQL, sqlconecxao);
                comandoAtualizarFuncionario.CommandType = System.Data.CommandType.Text;

                comandoAtualizarFuncionario.Parameters.AddWithValue("@Nome", funcionario.Nome);
                comandoAtualizarFuncionario.Parameters.AddWithValue("@Endereco", funcionario.Endereco);
                comandoAtualizarFuncionario.Parameters.AddWithValue("@CPF", funcionario.CPF);
                comandoAtualizarFuncionario.Parameters.AddWithValue("@Telefone", funcionario.Telefone);
                comandoAtualizarFuncionario.Parameters.AddWithValue("@Data_Nascimento", funcionario.DataNascimento);
                comandoAtualizarFuncionario.Parameters.AddWithValue("@Data_Admissao", funcionario.DataAdmissao);
                comandoAtualizarFuncionario.Parameters.AddWithValue("@Id", funcionario.Id);

                comandoAtualizarFuncionario.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlconecxao.Close();
            }

            funcionario = ObterPorId(Id);
            return funcionario;
        }


        public void Remover(int id)
        {
            try
            {
                sqlconecxao.Open();
                var excluirFuncionarioNoSQL = @"DELETE FROM Funcionario WHERE id=" + id;
                SqlCommand comandoExcluirFuncionario = new SqlCommand(excluirFuncionarioNoSQL, sqlconecxao);
                comandoExcluirFuncionario.CommandType = System.Data.CommandType.Text;
                comandoExcluirFuncionario.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlconecxao.Close();
            }
        }

        public Funcionario ObterPorId(int id)
        {
            var funcionarioBuscado = new Funcionario();

            try
            {
                sqlconecxao.Open();
                string consultaSql = "SELECT * FROM Funcionario WHERE Id = @Id";
                SqlCommand comandoBuscarFuncionario = new SqlCommand(consultaSql, sqlconecxao);
                comandoBuscarFuncionario.Parameters.AddWithValue("@Id", id);
                comandoBuscarFuncionario.CommandType = System.Data.CommandType.Text;
                SqlDataReader dataReader = comandoBuscarFuncionario.ExecuteReader();

                if (dataReader.Read())
                {
                    funcionarioBuscado.Id = Convert.ToInt32(dataReader["Id"]);
                    funcionarioBuscado.Nome = dataReader["Nome"].ToString();
                    funcionarioBuscado.Endereco = dataReader["Endereco"].ToString();
                    funcionarioBuscado.CPF = dataReader["CPF"].ToString();
                    funcionarioBuscado.Telefone = dataReader["Telefone"].ToString();
                    funcionarioBuscado.DataNascimento = Convert.ToDateTime(dataReader["Data_Nascimento"]);
                    funcionarioBuscado.DataAdmissao = Convert.ToDateTime(dataReader["Data_Admissao"]);
                }

                dataReader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlconecxao.Close();
            }

            return funcionarioBuscado;
        }

        public Funcionario ObterPorCpf(string cpf)
        {
            throw new NotImplementedException();
        }

    }
}
