using System;
using System.Xml.Linq;

namespace LibraryForLabs
{
    public class PassengerCar : Cars
    {
        //Количество мест
        private int numberOfSeats;
        //Максимальная скорость
        private int topSpeed;

        //Конструктор без параметров
        public PassengerCar() : base()
        {
            numberOfSeats = 5;
            topSpeed = 120;
        }

        public Cars BaseCar => new Cars(Brand, ReleaseYear, Color, Cost, Clearance, id.number);

        //Конструктор с параметрами
        public PassengerCar(string brand, int releaseYear, string color, int cost, double clearance, int numberOfSeats, int topSpeed, int idNumber) : base(brand, releaseYear, color, cost, clearance, idNumber)
        {
            NumberOfSeats = numberOfSeats;
            TopSpeed = topSpeed;
        }

        // Свойство для доступа к количеству мест
        public int NumberOfSeats
        {
            get
            {
                return numberOfSeats;
            }
            set
            {
                if (value > 7)
                    numberOfSeats = 7;
                else if (value < 2)
                    numberOfSeats = 2;
                else
                    numberOfSeats = value;
            }
        }

        // Свойство для доступа к максимальной скорости
        public int TopSpeed
        {
            get
            {
                return topSpeed;
            }
            set
            {
                if (value > 250)
                    topSpeed = 250;
                else if (value < 120)
                    topSpeed = 120;
                else
                    topSpeed = value;
            }
        }

        //Метод для вывода информации о машине
        public override void Show()
        {
            base.Show();
            Console.WriteLine("Количество мест: " + numberOfSeats);
            Console.WriteLine("Максимальная скорость: " + topSpeed);
        }
        
        //Метод для вывода информации о машине не виртуальный
        public new void ShowNotVirtual()
        {
            base.ShowNotVirtual();
            Console.WriteLine("Количество мест: " + numberOfSeats);
            Console.WriteLine("Максимальная скорость: " + topSpeed);
        }

        //Метод для ввода информации об автомобиле
        public override void Init()
        {
            base.Init();
            Console.Write("Введите количество мест: ");
            int vl = ParseToInt(Console.ReadLine());
            NumberOfSeats = vl;
            Console.Write("Введите максимальную скорость: ");
            vl = ParseToInt(Console.ReadLine());
            TopSpeed = vl;
        }

        //Метод для ввода информации об автомобиле случайно
        public override void RandomInit()
        {
            base.RandomInit();
            TopSpeed = rand.Next(120, 250);
            NumberOfSeats = rand.Next(2, 7);
        }

        //Метод для сравнения
        public override bool Equals(object obj)
        {           
            if (obj is PassengerCar car)            
                return (TopSpeed == car.TopSpeed) && (NumberOfSeats == car.NumberOfSeats) && base.Equals(car);
            else
                return false;
        }

        //Реализация интерфейса ICloneable
        public override object Clone()
        {
            return new PassengerCar(this.Brand, this.ReleaseYear, this.Color, this.Cost, this.Clearance, this.NumberOfSeats, this.TopSpeed, this.id.number);
        }

        //Поверхностное копирование
        public new object ShallowCopy()
        {
            return base.ShallowCopy();
        }

        public override string ToString()
        {
            return $"{Brand}, {ReleaseYear}, {Color}, {Cost}, {Clearance}, {NumberOfSeats}, {TopSpeed}, {id}";
        }

        //// Реализация метода CompareTo
        //public override int CompareTo(object obj)
        //{
        //    if (obj == null) return 1;

        //    if (obj is PassengerCar otherPassengerCar)
        //    {
        //        int baseComparisonResult = base.CompareTo(obj);

        //        // Сначала сравниваем общие атрибуты родительского класса
        //        if (baseComparisonResult != 0) return baseComparisonResult;

        //        // Затем сравниваем по уникальным для пассажирского автомобиля атрибутам
        //        if (NumberOfSeats != otherPassengerCar.NumberOfSeats)
        //        {
        //            return NumberOfSeats.CompareTo(otherPassengerCar.NumberOfSeats);
        //        }
        //        else
        //        {
        //            return TopSpeed.CompareTo(otherPassengerCar.TopSpeed);
        //        }
        //    }
        //    else
        //    {
        //        throw new ArgumentException("Объект не является экземпляром класса PassengerCar.");
        //    }
        //}
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Brand.GetHashCode();
                hash = hash * 23 + ReleaseYear.GetHashCode();
                hash = hash * 23 + Color.GetHashCode();
                hash = hash * 23 + Cost.GetHashCode();
                hash = hash * 23 + Clearance.GetHashCode();
                hash = hash * 23 + TopSpeed.GetHashCode();
                hash = hash * 23 + NumberOfSeats.GetHashCode();

                return hash;

            }
        }
    }
}
