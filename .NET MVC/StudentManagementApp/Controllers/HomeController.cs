using Microsoft.AspNetCore.Mvc;
using StudentManagementApp.Services; // adjust namespace
using StudentManagementApp.Models;   // adjust namespace

public class StudentsController : Controller
{
    private readonly IStudentService _service;

    public StudentsController(IStudentService service)
    {
        _service = service;
    }

    // GET: /Students
    public async Task<IActionResult> Index()
    {
        try
        {
            var students = await _service.GetAllStudentsAsync();
            return View(students);
        }
        catch (Exception ex)
        {
            // Log error here (ILogger recommended)
            ViewBag.ErrorMessage = $"Error loading students: {ex.Message}";
            return View("Error");
        }
    }

    // GET: /Students/Details/5
    public async Task<IActionResult> Details(int id)
    {
        try
        {
            var student = await _service.GetStudentByIdAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = $"Error fetching student details: {ex.Message}";
            return View("Error");
        }
    }

    // GET: /Students/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Students/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Student student)
    {
        if (!ModelState.IsValid) return View(student);

        try
        {
            await _service.CreateStudentAsync(student);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = $"Error creating student: {ex.Message}";
            return View("Error");
        }
    }

    // GET: /Students/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var student = await _service.GetStudentByIdAsync(id);
        if (student == null) return NotFound();
        return View(student);
    }

    // POST: /Students/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Student student)
    {
        if (!ModelState.IsValid) return View(student);

        try
        {
            await _service.EditStudentAsync(student);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = $"Error editing student: {ex.Message}";
            return View("Error");
        }
    }

    // GET: /Students/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var student = await _service.GetStudentByIdAsync(id);
        if (student == null) return NotFound();
        return View(student);
    }

    // POST: /Students/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        try
        {
            await _service.RemoveStudentAsync(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = $"Error deleting student: {ex.Message}";
            return View("Error");
        }
    }
}