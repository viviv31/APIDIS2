using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static APIDIS2.Models.Fireball_model;
using APIDIS2.Models;
using APIDIS2.DataAccess;
using Newtonsoft.Json;
using System.Net.Http;

namespace APIDIS2.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext dbContext;
        //Base URL for the IEXTrading API. Method specific URLs are appended to this base URL.
        string BASE_URL = "https://ssd-api.jpl.nasa.gov/fireball.api";
        HttpClient httpClient;

        public HomeController(ApplicationDbContext context)
        {
            dbContext = context;

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new
                System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<description_fireball> GetSymbols()
        {
            string NASA_API_PATH = BASE_URL + "ref-data/symbols";
            string description_fireballList = "";
            List<description_fireball> description_Fireballs = null;

            
            httpClient.BaseAddress = new Uri(NASA_API_PATH);
            HttpResponseMessage response = httpClient.GetAsync(NASA_API_PATH).GetAwaiter().GetResult();

            
            if (response.IsSuccessStatusCode)
            {
                description_fireballList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            
            if (!description_fireballList.Equals(""))
            {
                https://stackoverflow.com/a/46280739
                description_Fireballs = JsonConvert.DeserializeObject<List<description_fireball>>(description_fireballList);
                description_Fireballs = description_Fireballs.GetRange(0, 50);
            }

            return description_Fireballs;
        }

        public IActionResult Index()
        {
            //Set ViewBag variable first
            ViewBag.dbSuccessComp = 0;
            List<description_fireball> description_Fireballs = GetSymbols();

            
            TempData["description_Fireballs"] = JsonConvert.SerializeObject(description_Fireballs);

            return View(description_Fireballs);
        }

        
        public IActionResult Symbols()
        {
            //Set ViewBag variable first
            ViewBag.dbSuccessComp = 0;
            List<description_fireball> description_Fireballs = GetSymbols();

            //Save companies in TempData, so they do not have to be retrieved again
            TempData["description_Fireballs"] = JsonConvert.SerializeObject(description_Fireballs);

            return View(description_Fireballs);
        }

        /*
            Save the available symbols in the database
        */
        public IActionResult PopulateSymbols()
        {
            // Retrieve the companies that were saved in the symbols method
            List<description_fireball> description_Fireballs = JsonConvert.DeserializeObject<List<description_fireball>>(TempData["Description_Fireballs"].ToString());

            foreach (description_fireball description_Fireball in description_Fireballs)
            {
                //Database will give PK constraint violation error when trying to insert record with existing PK.
                //So add company only if it doesnt exist, check existence using symbol (PK)
                if (dbContext.description_fireballs.Where(c => c.date.Equals(description_Fireball.date)).Count() == 0)
                {
                    dbContext.description_fireballs.Add(description_Fireball);
                }
            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Index", description_Fireballs);
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
