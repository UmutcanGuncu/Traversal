using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Traversal.Areas.Admin.Models;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class VisitorApiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VisitorApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44356/api/Visitor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<VisitorViewModel>>(jsonData);
                return View(data);
            }
            else
                return View();
        }
        [HttpGet]
        public IActionResult AddVisitor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddVisitor(VisitorViewModel model)
        {
            var client= _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:44356/api/Visitor",stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }else
            {
                return View();
            }
            
        }
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44356/api/Visitor/{id}");
            if(responseMessage.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index","Default");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> UpdateVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            
            var responseMessage = await client.GetAsync($"https://localhost:44356/api/Visitor/{id}");
            if(responseMessage.IsSuccessStatusCode )
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<VisitorViewModel>(jsonData);
                return View(data);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateVisitor(VisitorViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44356/api/Visitor",stringContent);
            if(responseMessage.IsSuccessStatusCode ) 
            {
                return RedirectToAction("Index","Default");
            }
            else
            {
                return View();
            }
        }
    }
}
