using System.Diagnostics;
using System.Threading.Tasks;
using Blog.Application.DomainServices.Students;
using Blog.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Blog.Web.Models;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITestService _testService;
        private readonly IStudentService _studentService;

        public HomeController(
            ILogger<HomeController> logger,
            ITestService testService,
            IStudentService studentService
            )
        {
            _logger = logger;
            _testService = testService;
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            var studentModel = new Student
            {
                Name = "test"
            };

            var isInsert = await _studentService.AddAsync(studentModel);

            var student = await _studentService.GetByIdAsync(1);

            var studentList = await _studentService.GetAllListAsync();


            var number = await _testService.TestAsync();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
