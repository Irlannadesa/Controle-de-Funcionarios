
using ListaDePessoas.Modelo;

namespace ListaDePessoas
{
    public class SingletonFuncionarios
    {
        private static List<Funcionario> _instance;

        public static List<Funcionario> ObterInstancia()
        {
            if (_instance == null)
            {
                _instance = new List<Funcionario>();
            }
            return _instance;
        }
    }
}
