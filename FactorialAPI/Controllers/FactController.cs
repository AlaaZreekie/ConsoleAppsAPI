using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace FactorialApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FactorialController : ControllerBase
    {
        [HttpGet("{number}")]
        public IActionResult GetFactorial(int number, IWebHostEnvironment env)
        {
            string folder = Path.Combine(env.ContentRootPath, "apps\\Factorial\\Debug\\net8.0");
            var startInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = $"\"{folder}\\FactorialConsoleApp.dll\" {number}",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            try
            {
                using (var process = Process.Start(startInfo))
                {
                    using (var reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        return Ok(result.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("{left}/{right}")]
        public IActionResult Add(int left, int right, IWebHostEnvironment env)
        {
            string folder = Path.Combine(env.ContentRootPath, "apps\\Adder\\Debug\\net8.0");
            var startInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = $"\"{folder}\\AddConsoleApp.dll\" {left} {right}",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            try
            {
                using (var process = Process.Start(startInfo))
                {
                    using (var reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        return Ok(result.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

