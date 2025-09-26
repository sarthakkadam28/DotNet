using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AssessmentLib.Entities;
using AssessmentLib.Services.Interfaces;

namespace StudentManagementAPI.Controllers
{
    [ApiController ]
    [Route("api/[controller]")]
    public class AssessmentController : Controller
    {
        // GET: AssessmentController
        private readonly IAssessmentService _svc;
        private readonly ILogger<AssessmentController> _logger;
        public ActionResult Index()
        {
            return View();
        }

        // GET: AssessmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AssessmentController/Create
        public ActionResult Create()
        {
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
