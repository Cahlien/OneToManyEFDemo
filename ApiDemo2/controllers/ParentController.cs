using ApiDemo2.DbContext;
using ApiDemo2.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiDemo2.controllers;
[ApiController]
[Route("api/[controller]")]
public class ParentController : ControllerBase
{  
    private readonly ApiContext _context;

    public ParentController(ApiContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ParentModel>>> GetParentModels()
    {
        return await _context.ParentModels.Include(p => p.ChildModels).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ParentModel>> GetParentModel(int id)
    {
        var parentModel = await _context.ParentModels.FindAsync(id);

        if (parentModel == null)
        {
            return NotFound();
        }

        return parentModel;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutParentModel(int id, ParentModel parentModel)
    {
        if (id != parentModel.Id)
        {
            return BadRequest();
        }

        _context.Entry(parentModel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ParentModelExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<ParentModel>> PostParentModel(ParentModel parentModel)
    {
        _context.ParentModels.Add(parentModel);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetParentModel", new { id = parentModel.Id }, parentModel);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteParentModel(int id)
    {
        var parentModel = await _context.ParentModels.FindAsync(id);
        if (parentModel == null)
        {
            return NotFound();
        }

        _context.ParentModels.Remove(parentModel);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ParentModelExists(int id)
    {
        return _context.ParentModels.Any(e => e.Id == id);
    }
}