using FluentMigrator;

namespace MigrationsPlayGround.Mirgations
{
    [Migration(202106280001)]
    public class InitialTables_202106280001 : Migration
    {
        

        public override void Down()
        {
            Delete.Table("Companies");
            Delete.Table("Employee");
        }

        public override void Up()
        {
            Create.Table("Companies")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Address").AsString(50).NotNullable()
                .WithColumn("Country").AsString(50).NotNullable();

            Create.Table("Employee")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Age").AsInt32().NotNullable()
                .WithColumn("Position").AsString(50).NotNullable()
                .WithColumn("CompanyId").AsString(50).NotNullable();
        }
    }
}
