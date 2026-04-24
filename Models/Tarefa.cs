namespace tarefa.Models;

public class Tarefa
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string descricao { get; set; }  = string.Empty;
    
    public string Status { get; set; } = string.Empty;

    public DateTime Criacao { get; set; }
    
}