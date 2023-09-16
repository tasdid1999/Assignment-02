using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class create_spGetById : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE spGetById
                                    @id int,
                                    @tableName varchar(128)
                                AS
                                BEGIN
                                   
                                    IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(@tableName) AND type = 'U')
                                    BEGIN
                                        DECLARE @sql nvarchar(max)

                                        SET @sql = N'SELECT * FROM ' + QUOTENAME(@tableName) + N' s
                                                     WHERE s.Id = @id and s.StatusId = 1'

                                       EXEC sp_executesql @sql, N'@id int', @id = @id
                                    END
                                END";

            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP PROCEDURE spGetById";
            migrationBuilder.Sql(procedure);
        }
    }
}
