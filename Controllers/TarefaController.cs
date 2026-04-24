using Microsoft.AspNetCore.Mvc;
using tarefa.Contexts;
using tarefa.Models;

namespace tarefa.Controllers;

public class TarefaController: Controller
{
    private readonly TarefasContext _context;
    public IActionResult Index()
    {
        var tarefa= new Tarefa
        {
            Id=1,
            Titulo = "teste",
            descricao= "nova"

        };

        return View(tarefa);
    }
}