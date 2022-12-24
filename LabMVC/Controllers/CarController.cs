using LabMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace LabMVC.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly ILogger<MathsController> _logger;

        public List<string> carRes=new List<string>();
        public CarController(ILogger<MathsController> logger)
        {
            _logger = logger;
            try
            {
                using (StreamReader sr = new StreamReader("car.json"))
                {
                    carRes = JsonConvert.DeserializeObject<List<string>>(sr.ReadToEnd());
                }
            }
            catch (Exception)
            {

                
            }
        }
        [HttpPost]
        public async Task<ActionResult> Index(string namecar,string color,string manuf,int year,int engvol)
        {
            Car car = new Car(namecar,color,manuf,year,engvol);
            carRes.Add($"{car.InfoCar()}");
            using (StreamWriter sw = new StreamWriter("car.json"))
            {
                sw.WriteLine(JsonConvert.SerializeObject(carRes));
            }
            return View(carRes);
        }
    }
}
