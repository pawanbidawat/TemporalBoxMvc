using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using TemporalBox.Models;

namespace TemporalBox.Controllers
{
    public class SharedController : Controller
    {
        private readonly HttpClient _httpClient;
        public SharedController(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }

        public async Task<IActionResult> Category()
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
    }
}
