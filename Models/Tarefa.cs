using System.ComponentModel.DataAnnotations;

namespace tarefa.Models;

public class Tarefa
{
    public int Id { get; set; }

    [Required] 
    public string Titulo { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;
    
    
    public string? Status { get; set; }

    public DateTime? Criacao { get; set; } 
}