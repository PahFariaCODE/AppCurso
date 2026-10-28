
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppCurso.Models;
using AppCurso.Data;

public class AlunoTurmaController : Controller
{
    private readonly ApplicationDbContext _context;

    public AlunoTurmaController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: ALUNOTURMAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.AlunoTurmas.ToListAsync());
    }

    // GET: ALUNOTURMAS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var alunoturma = await _context.AlunoTurmas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (alunoturma == null)
        {
            return NotFound();
        }

        return View(alunoturma);
    }

    // GET: ALUNOTURMAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ALUNOTURMAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,AlunoId,Aluno,TurmaId,Turma")] AlunoTurma alunoturma)
    {
        if (ModelState.IsValid)
        {
            _context.Add(alunoturma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(alunoturma);
    }

    // GET: ALUNOTURMAS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var alunoturma = await _context.AlunoTurmas.FindAsync(id);
        if (alunoturma == null)
        {
            return NotFound();
        }
        return View(alunoturma);
    }

    // POST: ALUNOTURMAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,AlunoId,Aluno,TurmaId,Turma")] AlunoTurma alunoturma)
    {
        if (id != alunoturma.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(alunoturma);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoTurmaExists(alunoturma.Id))
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
        return View(alunoturma);
    }

    // GET: ALUNOTURMAS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var alunoturma = await _context.AlunoTurmas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (alunoturma == null)
        {
            return NotFound();
        }

        return View(alunoturma);
    }

    // POST: ALUNOTURMAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var alunoturma = await _context.AlunoTurmas.FindAsync(id);
        if (alunoturma != null)
        {
            _context.AlunoTurmas.Remove(alunoturma);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AlunoTurmaExists(int? id)
    {
        return _context.AlunoTurmas.Any(e => e.Id == id);
    }
}
