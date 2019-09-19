using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] {"Id", "Content", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Title"},
                values: new object[,]
                {
                    {1, "Course Content", null, null, null, null, "Course1"},
                    {2, "Course2 Content", null, null, null, null, "Course2"},
                    {3, "Course3 Content", null, null, null, null, "Course3"}
                });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[]
                    {"Id", "Content", "CreatedBy", "CreatedOn", "Duration", "ModifiedBy", "ModifiedOn", "Title"},
                values: new object[,]
                {
                    {1, "Exam Content", null, null, null, null, null, "Exam1"},
                    {2, "Exam2 Content", null, null, null, null, null, "Exam2"},
                    {3, "Exam3 Content", null, null, null, null, null, "Exam3"}
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] {"Id", "CreatedBy", "CreatedOn", "FirstName", "LastName", "ModifiedBy", "ModifiedOn"},
                values: new object[,]
                {
                    {1, null, null, "User1", "User1", null, null},
                    {2, null, null, "User2", "User2", null, null},
                    {3, null, null, "User3", "User3", null, null}
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] {"StudentId", "CourseId", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn"},
                values: new object[,]
                {
                    {1, 1, null, null, null, null},
                    {1, 2, null, null, null, null},
                    {1, 3, null, null, null, null},
                    {2, 1, null, null, null, null},
                    {2, 2, null, null, null, null},
                    {3, 3, null, null, null, null}
                });

            migrationBuilder.InsertData(
                table: "StudentExams",
                columns: new[] {"StudentId", "ExamId", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn"},
                values: new object[,]
                {
                    {1, 1, null, null, null, null},
                    {1, 2, null, null, null, null},
                    {1, 3, null, null, null, null},
                    {2, 1, null, null, null, null},
                    {2, 2, null, null, null, null},
                    {3, 3, null, null, null, null}
                });
        }



        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "StudentExams");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
