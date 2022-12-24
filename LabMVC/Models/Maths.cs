using Microsoft.AspNetCore.Mvc;

namespace LabMVC.Models
{
    public class Maths
    {
        public int Id { get; set; }
        public int Numb1 { get; set; }
        public int Numb2 { get; set; }
        public int Numb3 { get; set; }
        public int Numb4 { get; set; }
        public string Sumbol { get; set; }
        public Maths(Maths maths1)
        {

        }
        public Maths(int id, int numb1, int numb2, int numb3, int numb4, string sumbol)
        {
            Id = id;
            Numb1 = numb1;
            Numb2 = numb2;
            Numb3 = numb3;
            Numb4 = numb4;
            Sumbol = sumbol;
        }
        public Maths( int numb1, int numb2, int numb3, int numb4, string sumbol)
        {
            
            Numb1 = numb1;
            Numb2 = numb2;
            Numb3 = numb3;
            Numb4 = numb4;
            Sumbol = sumbol;
        }

        [HttpPost]
        public string PrintInfo() => $"{Numb1}/{Numb2} {Sumbol}  {Numb3}/{Numb4}";
    }
}
