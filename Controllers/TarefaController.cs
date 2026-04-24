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
        ViewData["Title"] = "Nova tarefa";
        if (ModelState.IsValid)
        {
            tarefa.Criacao = DateTime.Now;
            tarefa.Status="Em Andamento";
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        else
        {

            return View("Form", tarefa);
        }
    }

    public IActionResult Editar(int id)
    {
        
        ViewData["Title"] = "Editar tarefa";
        var tarefa = _context.Tarefas.Find(id);
        if(tarefa is null){
            return NotFound();
        }
        return View("Form", tarefa);
    }

    [HttpPost]
    public IActionResult Editar(Tarefa tarefa)
    {
        ViewData["Title"] = "Editar tarefa";
        if (ModelState.IsValid)
        {
            _context.Tarefas.Update(tarefa);
            _context.SaveChanges();
            return RedirectToAction("index");

        }
        else
        {
            return View("Form", tarefa);
        }
        
    }

    public IActionResult Delete(int id){
        

        var tarefa= _context.Tarefas.Find(id);
        if(tarefa is null){
            return NotFound();
        }
        ViewData["Title"]= "Excluir tarefa";

        return View(tarefa);
    }

    [HttpPost]
    public IActionResult Delete(Tarefa tarefa){

        _context.Tarefas.Remove(tarefa);
        _context.SaveChanges();
        

        return RedirectToAction("Index");
    }
}