using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class create_spGetStudentById : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE spGetStudentById
                     @studentId int
                     AS
                     BEGIN

                     SELECT *
                     FROM students s
                     WHERE s.Id = @studentId and s.StatusId = 1

                     END";

            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP PROCEDURE spGetStudentById";
            migrationBuilder.Sql(procedure);
        }
    }
}
