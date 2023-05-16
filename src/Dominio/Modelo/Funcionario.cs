using LinqToDB.Mapping;

namespace Dominio.Modelo
{
    public class Funcionario
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }

        [Column("Nome"), NotNull]
        public string Nome { get; set; }

        [Column("Endereco"), NotNull]
        public string Endereco { get; set; }

        [Column("CPF"), NotNull]
        public string CPF { get; set; }

        [Column("Telefone"), NotNull]
        public string Telefone { get; set; }

        [Column("Data_Nascimento"), NotNull]
        public DateTime DataNascimento { get; set; }

        [Column("Data_Admissao"), NotNull]
        public DateTime DataAdmissao { get; set; }
      
    }
}
