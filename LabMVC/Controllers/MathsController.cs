using LabMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace LabMVC.Controllers
{
    public class MathsController : Controller
    {
        // GET: MathController
        public IActionResult Index()
        {
            return View();
        }
        private readonly ILogger<MathsController> _logger;
        public List<string> result = new List<string>();
        public MathsController(ILogger<MathsController> logger)
        {
            _logger = logger;
            try
            {
                using (StreamReader sr=new StreamReader("result.json"))
                {
                    result=JsonConvert.DeserializeObject<List<string>>(sr.ReadToEnd());
                }
            }
            catch (Exception)
            {

                
            }
        }
        public static int GetNOD(int val1, int val2)
        {
            val1 = Math.Abs(val1);
            while ((val1 != 0) && (val2 != 0))
            {
                if (val1 > val2)
                    val1 %= val2;
                else
                    val2 %= val1;
            }
            return Math.Max(val1, val2);
        }
        [HttpPost]
        public async Task<ActionResult> Index(int numb1, int numb2, int numb3, int numb4, string sumbol)
        {
            Maths math = new Maths(numb1,numb2,numb3,numb4,sumbol);
            //if (numb2 == numb4)
            //{
            //    var n = numb1 + numb1;
            //    Response.ContentType = "text/html;charset=utf-8";
            //    await Response.WriteAsync($"<h2>{n}</h2>");

            //}
            Response.ContentType = "text/html;charset=utf-8";

            string res = "";
            if (numb2 != 0 && numb4 != 0)
            {
                if (numb2 == numb4 && sumbol == "+")
                {
                    float d = numb1 + numb3;
                    float d2 = d / numb2;
                    res = $" {d}/{numb2}={d2}";

                    // await Response.WriteAsync($"<h2>{res}</h2>");

                    //await Response.WriteAsync(res.ToString());
                    //return View((object)res);
                }
                if (numb2 != numb4 && sumbol == "+")
                {
                    int res1 = numb1 * numb4;
                    var res2 = numb2 * numb3;
                    var res3 = (res1 + res2);
                    var res4 = (numb2 * numb4);

                    float res5 = GetNOD(res3, res4);

                    float r = res3 / res5;
                    float r2 = res4 / res5;


                    float resf = r / r2;
                    // await Response.WriteAsync($"<h2>{r}/{r2}</h2>");
                    res = $"{r}/{r2}={resf}";
                    //await Response.WriteAsync(res.ToString());
                    //return View((object)res);

                }
                if (numb2 == numb4 && sumbol == "-")
                {
                    float d = numb1 - numb3;
                    float d2 = d / numb2;
                    res = $" {d}/{numb2}={d2}";

                    // await Response.WriteAsync($"<h2>{res}</h2>");

                    //await Response.WriteAsync(res.ToString());
                    //return View((object)res);
                }
                if (numb2 != numb4 && sumbol == "-")
                {
                    int res1 = numb1 * numb4;
                    int res2 = numb2 * numb3;
                    int res3 = (res1 - res2);
                    int res4 = (numb2 * numb4);

                    float res5 = GetNOD(res3, res4);

                    float r = res3 / res5;
                    float r2 = res4 / res5;


                    float resf = r / r2;
                    // await Response.WriteAsync($"<h2>{r}/{r2}</h2>");
                    res = $"{r}/{r2}={resf}";
                    //await Response.WriteAsync(res.ToString());
                    //return View((object)res);

                }
                if (sumbol == "*")
                {
                    int mat = numb1 * numb3;
                    int mat2 = numb2 * numb4;
                    //float resm = mat / mat2;
                    float nod = GetNOD(mat, mat2);
                    float res1 = mat / nod;
                    float res2 = mat2 / nod;
                    float resf = res1 / res2;
                    res = $"{res1}/{res2}={resf}";
                    //return View((object)res);
                }
                if (sumbol == "/")
                {
                    int mat = numb1 * numb4;
                    int mat2 = numb3 * numb2;
                    //float resm = mat / mat2;
                    float nod = GetNOD(mat, mat2);
                    float res1 = mat / nod;
                    float res2 = mat2 / nod;
                    float resf = res1 / res2;
                    res = $"{res1}/{res2}={resf}";
                    //return View((object)res);
                }
                result.Add($"{math.PrintInfo()}={res}");
                using (StreamWriter sw=new StreamWriter("result.json"))
                {
                    sw.WriteLine(JsonConvert.SerializeObject(result));
                }
            }
            else
            {
                List<string> prov = new List<string>();
                prov.Add("Ти ідіот на ноль ділити не можна");
                return View(prov);
            }

            return View(result);

        }


        //public string Index(Maths math) =>$"{math.PrintInfo()}";
        // GET: MathController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MathController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MathController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MathController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MathController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MathController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MathController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
