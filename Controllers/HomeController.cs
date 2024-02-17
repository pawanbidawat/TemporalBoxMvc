using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using TemporalBox.Models;

namespace TemporalBox.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger , HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var Client = new HttpClient();
            var apiUrl = "https://localhost:44373/api/Category/GetAllCategory";
            var response = await _httpClient.GetAsync(apiUrl);
            var data = JsonConvert.DeserializeObject<List<Categories>>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                ViewData["Categories"] = data;
                return View(data);
            }
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
