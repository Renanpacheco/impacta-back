using Microsoft.EntityFrameworkCore;
using tarefa.Models;

namespace tarefa.Contexts;

public class TarefasContext: DbContext
{
    public DbSet<Tarefa> Tarefas => Set<Tarefa>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=TarefasDb;User Id=sa;Password=SenhaForte123!;TrustServerCertificate=True;");
    }
}