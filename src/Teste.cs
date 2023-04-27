

using ListaDePessoas.Modelo;

namespace ListaDePessoas
{
    public class Teste
    {
       public Funcionario ObterNovoFunciorio()
        {
            return new Funcionario();
        }

        public void MostrarNaTelaNovoFuncionario()
        {
            var novoFuncionario = new Funcionario();
            Console.WriteLine(novoFuncionario.Nome);
        
        }
        
        
    }
}
