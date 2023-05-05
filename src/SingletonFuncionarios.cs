
using ListaDePessoas.Modelo;

namespace ListaDePessoas
{
    public class SingletonFuncionarios
    {
        private static int _ultimoId = 0;
        private static List<Funcionario> _instance;
        public static List<Funcionario> ObterInstancia()
        {
            if (_instance == null)
            {
                _instance = new List<Funcionario>();

            }
            return _instance;
        }

        public static void AdicionarIDFuncionario(Funcionario funcionario)
        {
            _ultimoId++;
            funcionario.Id = _ultimoId;
        }

    }
}
