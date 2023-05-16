using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using Traversal.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class BookingHotelSearchController : Controller
    {
        public async Task<IActionResult> Index()
        {
            //List<BookingSearchOtelViewModel> model = new List<BookingSearchOtelViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?checkin_date=2023-09-05&checkout_date=2023-09-06&filter_by_currency=EUR&dest_id=-553173&room_number=1&units=metric&dest_type=city&locale=tr&adults_number=1&order_by=popularity&page_number=0&include_adjacency=true&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1"),
                Headers =
    {
        { "X-RapidAPI-Key", "7e7a205358msh8d9e1bf83dcd427p16ee8ejsna82d433e3c1d" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
               var values = JsonConvert.DeserializeObject<BookingSearchOtelViewModel>(body);
                return View(values.results);
            }

             
        }
        
    }
}
