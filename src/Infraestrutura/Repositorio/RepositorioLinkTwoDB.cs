using Dominio.Modelo;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider.SqlServer;
using System.Configuration;


namespace Infraestrutura.Repositorio
{
    internal class RepositorioLinkTwoDB : IFuncionarios
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["Funcionarios"].ConnectionString;

        public DataConnection Conectar()
        {
            DataConnection conexao = SqlServerTools.CreateDataConnection(connectionString);
            return conexao;
        }

        public Funcionario Atualizar(Funcionario funcionario)
        {
            using var bancoSQL = Conectar();

            try
            {
                bancoSQL.Update(funcionario);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar funcionario", ex);
            }

            return funcionario;

        }

        public void Criar(Funcionario novoFuncionario)
        {
            using var bancoSQL = Conectar();
           
            try
            {
                bancoSQL.Insert(novoFuncionario);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar novo funcionário", ex);
            }
        }

        public Funcionario ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Funcionario> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            using var bancoSQL = Conectar();

            try
            {
                bancoSQL.GetTable<Funcionario>().Delete(funcionario => funcionario.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover funcionário", ex);
            }
        }
    }
}
