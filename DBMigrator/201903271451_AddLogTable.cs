using FluentMigrator;

namespace DBMigrator
{
    [Migration(201903271451)]
    public class _201903271451_AddLogTable : Migration
    {
        public override void Down()
        {
            Delete.Table("Log");
        }

        public override void Up()
        {
            Create.Table("Log")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Text").AsString()
                .WithColumn("CreateTime").AsDateTime();
        }
    }
}
