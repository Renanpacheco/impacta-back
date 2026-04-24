using System.ComponentModel.DataAnnotations;

namespace tarefa.Models;

public class Tarefa
{
    public int Id { get; set; }

    [Display(Name = "Título")]    
    [Required(ErrorMessage = "Campo obrigatório")]
    [StringLength(50, MinimumLength = 5, ErrorMessage =" o campo {0} deve ter entre {2} e {1} caracteres")]
    public string Titulo { get; set; } = string.Empty;

    [Display(Name = "Descrição")]    
    [Required(ErrorMessage = "Campo obrigatório")]
    [StringLength(200, MinimumLength = 5, ErrorMessage =" o campo {0} deve ter entre {2} e {1} caracteres")]
    public string Descricao { get; set; }  = string.Empty;
    
    public string Status { get; set; } = string.Empty;

    public DateTime Criacao { get; set; }
    
}