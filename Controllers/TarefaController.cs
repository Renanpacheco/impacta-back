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
        var tarefas= _context.Tarefas.ToList();

        return View(tarefas);
    }

    public IActionResult Criar()
    {
        ViewData["Title"] = "Nova tarefa";
        return View("Form");
    }

    [HttpPost]
    public IActionResult Criar(Tarefa tarefa)
    {
        _context.Tarefas.Add(tarefa);
        _context.SaveChanges();
        return RedirectToAction("index");
    }
}