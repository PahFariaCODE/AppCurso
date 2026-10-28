
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppCurso.Models;
using AppCurso.Data;

public class ProfessorController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProfessorController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: PROFESSORS
    public async Task<IActionResult> Index()
    {
        return View(await _context.Professores.ToListAsync());
    }

    // GET: PROFESSORS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var professor = await _context.Professores
            .FirstOrDefaultAsync(m => m.Id == id);
        if (professor == null)
        {
            return NotFound();
        }

        return View(professor);
    }

    // GET: PROFESSORS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PROFESSORS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nome,Email,Salario")] Professor professor)
    {
        if (ModelState.IsValid)
        {
            _context.Add(professor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(professor);
    }

    // GET: PROFESSORS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var professor = await _context.Professores.FindAsync(id);
        if (professor == null)
        {
            return NotFound();
        }
        return View(professor);
    }

    // POST: PROFESSORS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nome,Email,Salario")] Professor professor)
    {
        if (id != professor.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(professor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorExists(professor.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(professor);
    }

    // GET: PROFESSORS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var professor = await _context.Professores
            .FirstOrDefaultAsync(m => m.Id == id);
        if (professor == null)
        {
            return NotFound();
        }

        return View(professor);
    }

    // POST: PROFESSORS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var professor = await _context.Professores.FindAsync(id);
        if (professor != null)
        {
            _context.Professores.Remove(professor);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProfessorExists(int? id)
    {
        return _context.Professores.Any(e => e.Id == id);
    }
}
