using LinqToDB.Mapping;

namespace Dominio.Modelo
{
    public class Funcionario
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }        
        public string Nome { get; set; }        
        public string Endereco { get; set; }
        public string CPF { get; set; }       
        public string Telefone { get; set; }
        [Column("Data_Nascimento"), NotNull]
        public DateTime DataNascimento { get; set; }
        [Column("Data_Admissao"), NotNull]
        public DateTime DataAdmissao { get; set; }
      
    }
}
