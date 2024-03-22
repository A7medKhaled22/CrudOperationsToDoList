using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperationsToDoList.DAL;

public class ToDoContext : DbContext
{
    public DbSet<ToDo> ToDos => Set<ToDo>();

    public ToDoContext(DbContextOptions<ToDoContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ToDoConfiguration());
    }
}