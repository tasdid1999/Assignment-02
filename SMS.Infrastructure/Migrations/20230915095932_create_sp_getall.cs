using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class create_sp_getall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE spGetAll
                                    @skip int,
                                    @take int,
                                    @tableName varchar(128)
                                AS
                                BEGIN
                                   
                                    IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(@tableName) AND type = 'U')
                                    BEGIN
                                        DECLARE @sql nvarchar(max)

                                        SET @sql = N'SELECT * FROM ' + QUOTENAME(@tableName) + N' s
                                                     WHERE s.StatusId = 1
                                                     ORDER BY Id
                                                     OFFSET @offset ROWS FETCH NEXT @fetchCount ROWS ONLY'

                                        EXEC sp_executesql @sql, N'@offset int, @fetchCount int', @offset = @skip, @fetchCount = @take
                                    END
                                END";

            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP PROCEDURE spGetAll";
            migrationBuilder.Sql(procedure);
        }
    }
}
