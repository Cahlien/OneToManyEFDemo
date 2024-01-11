using ApiDemo2.models;

namespace ApiDemo2.DbContext;

using Microsoft.EntityFrameworkCore;
public class ApiContext : DbContext
{
    
    public ApiContext(DbContextOptions<ApiContext> options) : base(options)
    {
    }
    
    public DbSet<ParentModel> ParentModels { get; set; }
    public DbSet<ChildModel> ChildModels { get; set; }
}