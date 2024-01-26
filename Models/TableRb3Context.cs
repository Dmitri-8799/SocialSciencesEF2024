using Microsoft.EntityFrameworkCore;
using SocialSciencesEF2024.Models;

public partial class TableRB3Context : DbContext
{
    public DbSet<TableRb3Model> questionList => Set<TableRb3Model>();

    public TableRB3Context() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=SocialSciencesEF2024.db");
    }

}
