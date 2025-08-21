using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistent;

public class DbHelper : DbContext
{
    public DbSet<TaskModel> Tasks { get; set; }

    public DbHelper(DbContextOptions<DbHelper> options) : base(options)
    {
    }
}