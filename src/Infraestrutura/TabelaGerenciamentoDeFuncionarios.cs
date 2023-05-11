using FluentMigrator;

namespace test
{
    [Migration(20230504084700)]
    public class AddFuncionarioTable : Migration
    {
        public override void Up()
        {
            Create.Table("Funcionario")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("Endereco").AsString().NotNullable()
                .WithColumn("CPF").AsString().NotNullable()
                .WithColumn("Telefone").AsString().NotNullable()
                .WithColumn("Data_Nascimento").AsDateTime().NotNullable()
                .WithColumn("Data_Admissao").AsDateTime().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Log");
        }
    }
}
