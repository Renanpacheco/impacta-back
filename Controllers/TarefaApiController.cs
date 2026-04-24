using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tarefa.Contexts;
using tarefa.Models;

namespace tarefa.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefaApiController : ControllerBase
{
    private readonly TarefasContext _context;

    public TarefaApiController(TarefasContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Tarefas.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var tarefa = _context.Tarefas.Find(id);
        if (tarefa == null) return NotFound();

        return Ok(tarefa);
    }

    
    [HttpPost]
    public IActionResult Create([FromBody] Tarefa tarefa)
    {
    
        if (!ModelState.IsValid) 
        {
            return BadRequest(ModelState);
        }

        tarefa.Criacao = DateTime.Now; // Sobrescreve o que veio do front para garantir
        tarefa.Status = "Pendente";

        _context.Tarefas.Add(tarefa);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = tarefa.Id }, tarefa);
}
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Tarefa tarefaModificada)
    {
        var tarefaNoBanco = _context.Tarefas.Find(id);

        if (tarefaNoBanco == null) 
        {
            return NotFound();
        }

        tarefaNoBanco.Titulo = tarefaModificada.Titulo;
        tarefaNoBanco.Descricao = tarefaModificada.Descricao;
    
    
        if (!string.IsNullOrEmpty(tarefaModificada.Status))
        {
            tarefaNoBanco.Status = tarefaModificada.Status;
        }

        try
        {

            _context.SaveChanges();
        }catch (DbUpdateException ex)
        {
            return StatusCode(500, "Erro ao atualizar o banco de dados: " + ex.Message);
        }

        return NoContent();
    }   

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var tarefa = _context.Tarefas.Find(id);
        if (tarefa == null) return NotFound();

        _context.Tarefas.Remove(tarefa);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}/finalizar")]
    public IActionResult Finalizar(int id)
    {
        var tarefa = _context.Tarefas.Find(id);
        if (tarefa == null) return NotFound();

        tarefa.Status = "Concluída";
        _context.SaveChanges();

        return NoContent();
    }
}