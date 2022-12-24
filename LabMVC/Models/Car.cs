namespace LabMVC.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string NameCar { get; set; }
        public string Color { get; set; }
        public string Manufacturer { get; set; }
        public int Year { get; set; }
        public int EngineVolume { get; set; }
         public Car(int id,string nameCar,string color,string manufacturer,int year, int engineVolume)
         {
            Id = id;
            NameCar = nameCar;
            Color = color;
            Manufacturer = manufacturer;
            Year = year;
            EngineVolume = engineVolume;
         }
        public Car(string nameCar, string color, string manufacturer, int year, int engineVolume)
        {
            
            NameCar = nameCar;
            Color = color;
            Manufacturer = manufacturer;
            Year = year;
            EngineVolume = engineVolume;
        }

        public string InfoCar() => $"Marka - {NameCar}, Color - {Color}, Manufacturer  - {Manufacturer}, Year - {Year}, Engine Volume - {EngineVolume}";
    }

}
