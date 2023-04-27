using ListaDePessoas.Modelo;

namespace ListaDePessoas
{
    internal class RepositorioFuncionario : IFuncionarios
    {
        public void Criar(Funcionario novoFuncionario)
        {
            SingletonFuncionarios.ObterInstancia().Add(novoFuncionario);
        }

        public Funcionario ObterPorId(int id)
        {
            {

                foreach (Funcionario funcionario in SingletonFuncionarios.ObterInstancia())
                {
                    if (funcionario.Id == id)
                    {
                        return funcionario;
                    }
                }

                return null;
            }
        }

        public List<Funcionario> ObterTodos()
        {
            return SingletonFuncionarios.ObterInstancia();
        }

        public void Remover(int id)
        {
            var animalARemover = ObterPorId(id);
            SingletonFuncionarios.ObterInstancia().Remove(animalARemover);
        }

        public void Atualizar()
        {

        }
    }
}
