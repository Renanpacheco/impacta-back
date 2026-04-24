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
        tarefa.Criacao = DateTime.Now;
        _context.Tarefas.Add(tarefa);
        _context.SaveChanges();
        return RedirectToAction("index");
    }

    public IActionResult Editar(int id)
    {
        ViewData["Title"] = "Editar tarefa";
        var tarefa = _context.Tarefas.Find(id);
        return View("Form", tarefa);
    }

    [HttpPost]
    public IActionResult Editar(Tarefa tarefa)
    {
        _context.Tarefas.Update(tarefa);
        _context.SaveChanges();
        return RedirectToAction("index");
    }

    public IActionResult Delete(int id){

        var todo= _context.Tarefas.Find(id);
        ViewData["Title"]= "Delete";

        return View(todo);
    }

    [HttpPost]
    public IActionResult Delete(Tarefa tarefa){

        _context.Tarefas.Remove(tarefa);
        _context.SaveChanges();
        

        return RedirectToAction("Index");
    }
}