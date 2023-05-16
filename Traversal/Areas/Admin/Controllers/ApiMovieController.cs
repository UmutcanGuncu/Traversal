using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Traversal.Areas.Admin.Models;
using Microsoft.IdentityModel.JsonWebTokens;
using Newtonsoft.Json;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ApiMovieController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ApiMovieWithModel> apiMovies = new List<ApiMovieWithModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "7e7a205358msh8d9e1bf83dcd427p16ee8ejsna82d433e3c1d" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                apiMovies = JsonConvert.DeserializeObject<List<ApiMovieWithModel>>(body);
                return View(apiMovies);
            }
            
        }
    }
}
