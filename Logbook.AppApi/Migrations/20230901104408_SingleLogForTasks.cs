using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logbook.AppApi.Migrations
{
    /// <inheritdoc />
    public partial class SingleLogForTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectLogProjectTask");

            migrationBuilder.AddColumn<int>(
                name: "ProjectLogId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectLogId",
                table: "Tasks",
                column: "ProjectLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Logs_ProjectLogId",
                table: "Tasks",
                column: "ProjectLogId",
                principalTable: "Logs",
                principalColumn: "LogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Logs_ProjectLogId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ProjectLogId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ProjectLogId",
                table: "Tasks");

            migrationBuilder.CreateTable(
                name: "ProjectLogProjectTask",
                columns: table => new
                {
                    LogsLogId = table.Column<int>(type: "int", nullable: false),
                    TasksTaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectLogProjectTask", x => new { x.LogsLogId, x.TasksTaskId });
                    table.ForeignKey(
                        name: "FK_ProjectLogProjectTask_Logs_LogsLogId",
                        column: x => x.LogsLogId,
                        principalTable: "Logs",
                        principalColumn: "LogId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectLogProjectTask_Tasks_TasksTaskId",
                        column: x => x.TasksTaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLogProjectTask_TasksTaskId",
                table: "ProjectLogProjectTask",
                column: "TasksTaskId");
        }
    }
}
