using Microsoft.EntityFrameworkCore;
using tarefas.Models;

namespace tarefa.Contexts;

public class TarefasContext: DbContext
{
    public DbSet<Tarefa> Tarefas => Set<Tarefa>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;");
    }
}