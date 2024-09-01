using Microsoft.EntityFrameworkCore;

namespace SecondTask.Infrastructure.DbContext;

public class TestDbContext : ApplicationDbContext
{
    public TestDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}