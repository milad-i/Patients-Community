using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PatientsCommunity.Models;

namespace PatientsCommunity.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<AnswerModel> tbl_Answers { get; set; }
    public DbSet<QuestionModel> tbl_Question { get; set; }
    public DbSet<CategoryModel> tbl_Category { get; set; }
    public DbSet<QuestionCategoryModel> tbl_QuestionCategory { get; set; }
}
