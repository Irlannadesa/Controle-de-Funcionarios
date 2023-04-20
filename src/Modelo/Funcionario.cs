using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDePessoas.Modelo
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataAdmissao { get; set; }
        public Sexo Genero { get; set; }
        public enum Sexo {
            Masculino,
            Feminino
        }
    }
}
