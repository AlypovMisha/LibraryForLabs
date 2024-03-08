using System;
namespace LibraryForLabs
{
    public class OffRoadCar : Cars 
    {
        //Полный привод
        private bool awd;
        //Тип бездорожья
        private string offRoadType;

        //Массив с типами бездорожья
        static String[] offRoadTypes = { "gravel roads", "sand dunes", "swamps and bogs", "mountain trails and passes", "forest roads", "desert plains", "snow and ice surfaces", "concrete or stone tracks" };

        //Конструктор без параметров
        public OffRoadCar():base()
        {
            awd = false;
            offRoadType = "gravel roads";
        }

        //Конструктор с параметрами
        public OffRoadCar(string brand, int releaseYear, string color, int cost, double clearance, bool awd, string offRoadType, int idNumber) : base(brand, releaseYear, color, cost, clearance, idNumber)
        {
            Awd = awd;
            OffRoadType = offRoadType;
        }

        // Свойство для доступа к полному приводу
        public bool Awd
        {
            get
            {
                return awd;
            }
            set
            {
                if (value)                
                    awd = value;               
                else
                    awd = false;
            }
        }

        // Свойство для доступа к типу бездорожья
        public string OffRoadType
        {
            get
            {
                return offRoadType;
            }
            set
            {
               bool isInArray = Array.Exists(offRoadTypes, element => element == value);
                if (isInArray)
                    offRoadType = value;
                else
                    offRoadType = "gravel roads";
            }
        }

        //Метод для вывода информации о машине
        public override void Show()
        {
            base.Show();
            Console.WriteLine("Присутствие полного привода: " + awd);
            Console.WriteLine("Тип бездорожья: " + offRoadType);
        }
        //Метод для вывода информации о машине не виртуальный
        public new void ShowNotVirtual()
        {
            base .ShowNotVirtual();
            Console.WriteLine("Присутствие полного привода: " + awd);
            Console.WriteLine("Тип бездорожья: " + offRoadType);
        }
        //Метод для ввода информации об автомобиле
        public override void Init()
        {
            base.Init();
            Console.Write("Введите привод (true - полный, false - не полный): ");
            string aw = Console.ReadLine();
            if (aw == "true")
                Awd= true;
            else
                Awd = false;
            Console.Write("Введите тип бездорожья: ");
            OffRoadType = Console.ReadLine();
        }

        //Метод для ввода информации об автомобиле случайно
        public override void RandomInit()
        {
            base.RandomInit();
            Awd = rand.Next(0, 2) == 1;
            OffRoadType = offRoadTypes[rand.Next(offRoadTypes.Length)];
        }

        //Метод для сравнения
        public override bool Equals(object obj)
        {
            if (obj is OffRoadCar car)
                return (Awd == car.Awd) && (OffRoadType == car.OffRoadType) && base.Equals(car);
            else
                return false;
        }
    }
}
