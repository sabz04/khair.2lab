using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using khair._2lab.Models;

namespace khair._2lab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Task1()
        {
            return View();
        }
        public IActionResult Task2()
        {
            return View();
        }
        public IActionResult Task3()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Task1(string firstTextBox, string secondTextBox, string thirdTextBox)
        {
            try
            {
                var nums = new List<double>();
                nums.AddRange(new[]
                {
                    Double.Parse(firstTextBox),
                    Double.Parse(secondTextBox),
                    Double.Parse(thirdTextBox)
                });
                nums
                    .Where(p => p > 3 && p <= 9)
                    .ToList().ForEach(p => @ViewBag.result += p.ToString() + " ");
            }
            catch(Exception ex)
            {
                @ViewBag.result = ex.Message;
            }
            return View();
        }
        [HttpPost]
        public IActionResult Task2(string strTextBox)
        {
            try
            {
                var last = 0;
                var first = strTextBox.IndexOf('я');
                for (int i = 0; i < strTextBox.Length; i++)
                {
                    if (strTextBox[i] == 'я')
                    {
                        last = i;
                    }
                }
                if (first < 0)
                {
                    ViewBag.result = $@"Символ ""я"" не найден.";
                }
                else
                {
                    ViewBag.result = $@"Слово = {strTextBox}, Позиция первой ""я"" = {first}, последней = {last}";
                }
            }
            catch (Exception e)
            {
                ViewBag.result = e.Message;
            }
            return View();
        }
        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}