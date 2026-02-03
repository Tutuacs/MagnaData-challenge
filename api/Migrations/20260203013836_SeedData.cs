using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "todo",
                columns: ["Id", "Description", "Completed", "CreatedAt"],
                values: new object[,]
                {
                    { Guid.NewGuid().ToString(), "Ao atualizar esta tarefa ela vai mudar o valor da data de conclusão, mesmo sem alterar os valores...", DateTime.UtcNow.AddDays(-7), DateTime.UtcNow.AddDays(-14) },
                    { Guid.NewGuid().ToString(), "Tarefa de exemplo 2", null, DateTime.UtcNow }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
