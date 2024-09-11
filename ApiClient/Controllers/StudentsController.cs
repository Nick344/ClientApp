using Microsoft.AspNetCore.Mvc;
using Data;
using Newtonsoft.Json;

namespace ApiClient.Controllers
{
    [ApiController]  
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(IHttpClientFactory httpClientFactory, ILogger<StudentsController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        { 
        var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5000/api/Student");

            if (response.IsSuccessStatusCode)
            { 
            var content = await response.Content.ReadAsStringAsync();

                var students = JsonConvert.DeserializeObject<List<Student>>(content);
                
                return Ok(students);
            }

            return StatusCode((int)response.StatusCode, "Error retrieving students");

        }
    }
}
