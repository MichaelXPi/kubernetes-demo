using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Refit;
using TestMvc1.ApiClients;
using TestMvc1.Models;

namespace TestMvc1.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _configuration { get; }
        private IHostingEnvironment _hostingEnvironment { get;  }

        public HomeController(IConfiguration configuration, IHostingEnvironment env)
        : base()
        {
            _configuration = configuration;
            _hostingEnvironment = env;
        }

        public async Task<IActionResult> Index()
        {
            var url = _configuration.GetValue("TestApi1Url", "http://testapi1:60001");

            IEnumerable<Customer> customers = new []
            {
                new Customer()
                {
                    Id = 20001,
                    Name = "David",
                    Location = Environment.MachineName
                } 
            };

            try
            {
                var customerClient = RestService.For<ICustomerApi>(url);
                customers = await customerClient.GetCustomersAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Customer2 customer2 = new Customer2()
            {
                Customers = customers,
                ApiServerUrl =  url,
                HostingEnvironment = _hostingEnvironment.EnvironmentName
            };

            return View(customer2);
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
