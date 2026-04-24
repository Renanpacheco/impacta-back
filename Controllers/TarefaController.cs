using Microsoft.AspNetCore.Mvc;
using tarefa.Contexts;
using tarefa.Models;

namespace tarefa.Controllers;

public class TarefaController: Controller
{
    private readonly TarefasContext _context;
    public TarefaController(TarefasContext context)
    {
        _context=context;
    }
    public IActionResult Index()
    {
        /*var tarefa= new Tarefa
        {
            Id=1,
            Titulo = "teste",
            descricao= "nova"

        };*/
        var tarefas= _context.Tarefas.ToList();

        return View(tarefas);
    }
}