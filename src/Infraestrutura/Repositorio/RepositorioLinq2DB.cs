using Dominio.Modelo;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider.SqlServer;
using System.Configuration;

namespace Infraestrutura.Repositorio
{
    public class RepositorioLinkTwoDB : IRepositorioFuncionario
    {
        public DataConnection Conectar()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Funcionarios"].ConnectionString;
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
            using var bancoSQL = Conectar();

            try
            {
                var obterPorid = bancoSQL.GetTable<Funcionario>().FirstOrDefault(funcionario => funcionario.Id == id);
                return obterPorid;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter por ID", ex);
            }

        }

        public Funcionario ObterPorCpf(string cpf)
        {
            using var bancoSQL = Conectar();

            try
            {
                var funcionario = bancoSQL.GetTable<Funcionario>().
                FirstOrDefault(f => f.CPF == cpf)
                ?? throw new Exception("O cpf não existe.");

                return funcionario;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter o funcionario pelo cpf.", ex);
            }
        }

    

        public List<Funcionario> ObterTodos()
        {
            using var bancoSQL = Conectar();

            try
            {
                var obterFuncionarios = bancoSQL.GetTable<Funcionario>().ToList();
                return obterFuncionarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter todos os funcionário", ex); ;
            }
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