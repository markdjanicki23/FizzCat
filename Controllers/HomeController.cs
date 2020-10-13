using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FizzCat.Models;

namespace FizzCat.Controllers
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

        [HttpGet]
        public IActionResult FizzBuzz()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FizzBuzz(int input1, int input2, int range1, int range2)
        {
            string output1 = "";

            for (int i = range1; i <= range2; i++)
            {

                if (i % input1 == 0 && i % input2 == 0)
                {
                    output1 += ("FizzBuzz, ");
                        
                }
                else if (i % input1 == 0)
                {
                    output1 += ("Fizz, ");
                }
                else if (i % input2 == 0)
                {
                    output1 += ("Buzz, ");
                }
                else
                {
                    output1 += i + ", ";
                }           
                ViewData["Result"] = output1;                             
            }
            return View();
        }

        [HttpGet]
        public IActionResult TacocaT()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TacocaT(string theWord)
        {
            ViewData["Result"] = string.Join("", theWord.Reverse().ToArray());
            return View();
        }

        [HttpGet]
        public IActionResult SunsetHills()
        {
            return View();
        }


        // This doesnt work yet
        [HttpPost]
        public IActionResult SunsetHills(int input0, int input1, int input2, int input3, int input4)
        {

            int[] oneArray = new int[] { input0, input1, input2, input3, input4 };
            List<int> newArray = new List<int>();
            int count = 1;
            int currMax = oneArray[0];
            newArray.Add(currMax);

            for (int i = 0; i < oneArray.Length; i++)
            {

                if (oneArray[i] > currMax)
                {
                    count++;
                    newArray.Add(oneArray[i]);
                    currMax = oneArray[i];
                }
                ViewData["Result"] = ($"{count} + {newArray}");
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
