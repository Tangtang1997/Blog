using System.Diagnostics;
using System.Threading.Tasks;
using Blog.Application.Services.Students;
using Blog.Application.Services.Students.Dto;
using Blog.Core.Students;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Blog.Web.Models;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentService _studentService;

        public HomeController(
            ILogger<HomeController> logger,
            IStudentService studentService
            )
        {
            _logger = logger;
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            var studentModel = new StudentDto
            {
                Name = "test",
                Age = 18
            };

            var isSucceed = await _studentService.AddAsync(studentModel);

            var studentDto = await _studentService.GetByIdAsync(1);

            var studentDtos = await _studentService.GetAllAsync();

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
