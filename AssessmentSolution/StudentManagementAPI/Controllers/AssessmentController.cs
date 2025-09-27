using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AssessmentLib.Entities;
using AssessmentLib.Services.Interfaces;
using AssessmentLib.Repositories.Interface;

namespace StudentManagementAPI.Controllers
{
    [ApiController ]
    [Route("api/[controller]")]
    public class AssessmentController : Controller
    {
        // GET: AssessmentController
        private readonly IAssessmentService _svc;
        private readonly ILogger<AssessmentController> _logger;
        public AssessmentController(IAssessmentService service,ILogger<AssessmentController> logger )
        {
            _svc = service;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetDetails(int id)
        {
            Assessment theAssessment = await _svc.GetDetails(id);
            _logger.LogInformation("Get details method invoked at {DT}", DateTime.UtcNow.ToLongTimeString());
            return Ok(theAssessment);
        }
        [HttpGet("creationdate/fromDate/{fromDate}/toDate/{toDate}")]
        // GET: AssessmentController/Create
        public async Task<IActionResult> GetAll(DateTime fromDate,DateTime toDate)
        {
            List<Assessment> assessments = await _svc.GetAll(fromDate, toDate);
            _logger.LogInformation()
            return View();
        }

        // POST: AssessmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssessmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AssessmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssessmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AssessmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
