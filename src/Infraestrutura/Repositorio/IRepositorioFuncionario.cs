using Dominio.Modelo;

namespace Infraestrutura.Repositorio
{
    public interface IRepositorioFuncionario
    {
        public List<Funcionario> ObterTodos();
        public void Criar(Funcionario novoFuncionario);
        public Funcionario ObterPorId(int id);
        public void Remover(int id);
        public Funcionario Atualizar(Funcionario funcionario);
        public Funcionario ObterPorCpf(string cpf);

    }
}
