using AssessmentLib.Entities;
using AssessmentLib.Repositories.Interface;
using AssessmentLib.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace StudentManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssessmentController : Controller
    {
        // GET: AssessmentController
        private readonly IAssessmentService _svc;
        private readonly ILogger<AssessmentController> _logger;
        public AssessmentController(IAssessmentService service, ILogger<AssessmentController> logger)
        {
            _svc = service;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            Assessment theAssessment = await _svc.GetDetails(id);
            _logger.LogInformation("Get details method invoked at {DT}", DateTime.UtcNow.ToLongTimeString());
            return Ok(theAssessment);
        }
        [HttpGet("creationdate/fromDate/{fromDate}/toDate/{toDate}")]
        // GET: AssessmentController/Create
        public async Task<IActionResult> GetAll(DateTime fromDate, DateTime toDate)
        {
            List<Assessment> assessments = await _svc.GetAll(fromDate, toDate);
            _logger.LogInformation("Get all Assessments method invoked at {DT}", DateTime.UtcNow.ToLongTimeString());
            return Ok(assessments);

        }

        // POST: AssessmentController/Create
        [HttpGet("assessments")]
        [Authorize(Roles = "sme,admin")]
        public async Task<IActionResult> GetAllAssessment()
        {
            List<Assessment> assessments = await _svc.GetAllTests();
            if (assessments == null || assessments.Count == 0)
            {
                _logger.LogWarning("No assessments found at {DT}", DateTime.UtcNow.ToLongTimeString());
                return NotFound("No Assessments found");
            }
            _logger.LogInformation("Get all tests method invoked at {DT}", DateTime.UtcNow.ToLongTimeString());
            return Ok(assessments);
        }
        //http://localhost:5238/api/assessment/employees
        [HttpGet("employees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            List<Employee> employees = await _svc.GetAllEmployees();
            _logger.LogInformation("Get all employee method invoked at {DT}", DateTime.UtcNow.ToLongTimeString());
            return Ok(employees);
        }

        // POST: AssessmentController/Edit/5
        [HttpGet("employee/{userId}")]
        public async Task<IActionResult> GetEmployeeById(int userid)
        {
            Employee employee = await _svc.GetEmployeeById(userid);
            _logger.LogInformation("Get all employee method invoked at {DT}", DateTime.UtcNow.ToLongTimeString());
            return Ok(employee);

        }

        // GET: AssessmentController/Delete/5
        public async Task<IActionResult> GetAllSubject()
        {
            List<Subject> subjects = await _svc.GetAllSubjects();
            _logger.LogInformation("Get all subject method invoked at {DT}", DateTime.UtcNow.ToLongTimeString());

            return Ok(subjects);
        }

        // POST: AssessmentController/Delete/5
        [HttpGet("criterias")]
        public async Task<IActionResult> GetEvalutionCriterias()
        {
            List<EvalutionCriteria> criterias = await _svc.GetEvalutionCriterias();
            _logger.LogInformation("Get evalution criteria method invoked at {DT} ", DateTime.UtcNow.ToLongTimeString());
            return Ok(criterias);
        }
        [HttpGet("criterias/subjects/{subjectId}")]
        public async Task<IActionResult> GetEvalutionCriteriasBySubject(int subjectId)
        {
            List<EvalutionCriteria> criterias = await _svc.GetEvalutionCriteriasBySubject(subjectId);
            _logger.LogInformation(" Get evalution criteria by subject method invoked at {DT}", DateTime.UtcNow.ToLongTimeString());
            return Ok(criterias);
        }
        [HttpGet("criterias/subjects/{subjectId}")]
        public async Task<IActionResult> GetAllBySubjectMatterExpert(int smeId)
        {
            List<Assessment> assessments = await _svc.GetAllBySubjectMatterExpert(smeId);
            _logger.LogInformation("Get all subject matter Expertise method invoked at {DT} ", DateTime.UtcNow.ToLongTimeString());
            return Ok(assessments);
        }
        [HttpPost("createtest")]
        public async Task<IActionResult> CreateTest([FromBody] CreateTestRequest request)
        {
            Console.WriteLine("Inside Create Test Controller");
            bool status = await _svc.CreateTest(request);
            _logger.LogInformation("Create test method invoked at  {DT}", DateTime.UtcNow.ToLongTimeString());
            if (status)
            {
                return Ok(new { message = "Test created successfully" });
            }
            else
            {
                return BadRequest(new { message = "Failed to create test" });
            }
        }

        [HttpPost("addquestion/assessments/{assessmentId}/questions/{questionId}")]
        public async Task<IActionResult> AddQuestion(int assessmentId, int questionId)
        {
            bool status = await _svc.AddQuestion(assessmentId, questionId);
            _logger.LogInformation("Add question method invoked at  {DT}", DateTime.UtcNow.ToLongTimeString());
            return Ok(status);
        }

        [HttpDelete("{assessmentId}/questions/{questionId}")]
        public async Task<IActionResult> RemoveQuestion(int assessmentId, int questionId)
        {
            bool status = await _svc.RemoveQuestion(assessmentId, questionId);
            _logger.LogInformation("Remove question method invoked at  {DT}", DateTime.UtcNow.ToLongTimeString());
            return Ok(status);
        }

        [HttpPut("{assessmentId}/duration/{duration}")]
        public async Task<IActionResult> ChangeDuration(int assessmentId, string duration)
        {
            bool status = await _svc.ChangeDuration(assessmentId, duration);
            _logger.LogInformation("Change duration method invoked at  {DT}", DateTime.UtcNow.ToLongTimeString());
            return Ok(status);
        }

        [HttpPut("{assessmentId}/reschedule/{date}")]
        public async Task<IActionResult> Reschedule(int assessmentId, DateTime date)
        {
            bool status = await _svc.Reschedule(assessmentId, date);
            _logger.LogInformation("Reschedule method invoked at  {DT}", DateTime.UtcNow.ToLongTimeString());
            return Ok(status);
        }

        [HttpDelete("deletequestions")]
        public async Task<IActionResult> RemoveQuestions(int[] testQuestions)
        {
            bool status = await _svc.RemoveQuestions(testQuestions);
            _logger.LogInformation("Remove questions method invoked at  {DT}", DateTime.UtcNow.ToLongTimeString());
            return Ok(status);
        }

        [HttpPost("addtest")]
        [Authorize(Roles = "sme")]
        public async Task<IActionResult> AddTest([FromBody] CreateTestWithQuestions request)
        {
            var testId = await _svc.CreateTestWithQuestionsAsync(request);
            if (testId == 0)
            {
                _logger.LogError("Failed to create test at {DT}", DateTime.UtcNow.ToLongTimeString());
                return BadRequest(new { message = "Failed to create test" });
            }
            return Ok(new { message = "Test created", testId });
        }

        [HttpGet("allquestionsbysubject/{subjectId}")]
        public async Task<IActionResult> GetAllQuestionsBySubject(int subjectId)
        {
            List<SubjectQuestions> questions = await _svc.GetAllQuestionsBySubject(subjectId);
            if (questions == null || questions.Count == 0)
            {
                _logger.LogWarning("No questions found for subject ID {SubjectId} at {DT}", subjectId, DateTime.UtcNow.ToLongTimeString());
                return NotFound(new { message = "No questions found for the specified subject." });
            }
            _logger.LogInformation("Get all questions by subject method invoked at  {DT}", DateTime.UtcNow.ToLongTimeString());
            return Ok(questions);
        }

        [HttpGet("getsme/{subjectId}")]
        public async Task<IActionResult> GetSmeBySubject(int subjectId)
        {
            List<Employee> smeList = await _svc.GetSmeBySubject(subjectId);
            if (smeList == null || smeList.Count == 0)
            {
                _logger.LogWarning("No SME found for subject ID {SubjectId} at {DT}", subjectId, DateTime.UtcNow.ToLongTimeString());
                return NotFound(new { message = "No SME found for the specified subject." });
            }
            _logger.LogInformation("Get SME by subject method invoked at  {DT}", DateTime.UtcNow.ToLongTimeString());
            return Ok(smeList);
        }

        [HttpGet("getalltest/from/{fromDate}/to/{toDate}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAllTests(DateTime fromDate, DateTime toDate)
        {
            List<Test> assessments = await _svc.GetAllTests(fromDate, toDate);
            if (assessments == null || assessments.Count == 0)
            {
                _logger.LogWarning("No tests found between {FromDate} and {ToDate} at {DT}", fromDate, toDate, DateTime.UtcNow.ToLongTimeString());
                return NotFound(new { message = "No tests found for the specified date range." });
            }
            _logger.LogInformation("Get all tests method invoked at  {DT}", DateTime.UtcNow.ToLongTimeString());
            return Ok(assessments);
        }

        [HttpGet("testdetails/{testId}")]
        public async Task<IActionResult> GetTestDetails(int testId)
        {
            var testDetails = await _svc.GetTestDetails(testId);
            if (testDetails == null)
            {
                _logger.LogWarning("No test details found for test ID {TestId} at {DT}", testId, DateTime.UtcNow.ToLongTimeString());
                return NotFound(new { message = "No test details found for the specified test ID." });
            }
            _logger.LogInformation("Get test details method invoked at  {DT}", DateTime.UtcNow.ToLongTimeString());
            return Ok(testDetails);

        }
    }
}
