using System;
using System.Globalization;

namespace LibraryForLabs
{
    public class DialClock : IInit
    {
        private int hours;
        private int minutes;
        private static int objectCount;
        static readonly Random rand = new Random();
        //Конструктор без параметров
        public DialClock()
        {
            objectCount++;
            hours = 0;
            minutes = 0;
        }

        // Конструктор с параметрами
        public DialClock(int hours, int minutes)
        {
            objectCount++;
            this.hours = hours;
            this.minutes = minutes;
            hours = this.hours % 24;
        }
        public DialClock(string hour, string minute)
        {
            objectCount++;
            int hours = ParseToDC(hour, "1");
            int minutes = ParseToDC(minute, "2");
            this.hours = hours;
            this.minutes = minutes;
            hours = this.hours % 24;

        }

        // Конструктор копирования
        public DialClock(DialClock clock)
        {
            objectCount++;
            this.hours = clock.hours;
            this.minutes = clock.minutes;
        }

        // Свойство для доступа к часам
        public int Hours
        {
            get
            {
                if (hours == 24)
                {
                    hours = 0;
                }
                if (hours == -1)
                {
                    hours = 23;
                }
                if (hours != 24 && hours != -1)
                    hours = hours % 24 + minutes / 60;
                return hours;
            }
            set
            {
                hours = value;
                if (hours == 24)
                    hours = 0;
                if (hours == -1)
                    hours = 23;

            }
        }

        // Свойство для доступа к минутам
        public int Minutes
        {
            get
            {
                if (minutes == 60)
                {
                    minutes = 0;
                    hours++;
                }

                if (minutes == -1)
                {
                    minutes = 59;
                    hours--;
                }
                return minutes % 60;
            }
            set
            {
                minutes = value;
            }
        }

        // Метод для показа времени
        public void Show()
        {
            objectCount++;
            DialClock dialClock = new DialClock(hours, minutes);
            int d = dialClock.Minutes;
            Console.WriteLine($"{dialClock.Hours}:{d}");
        }

        // Метод для вычисления угла между стрелками
        public double GetLittleAngle()
        {
            double hourAngle = (hours % 12 * 30) + (minutes / 2);
            double minuteAngle = minutes * 6;
            double angle = Math.Abs(hourAngle - minuteAngle);

            if (angle > 180)
                angle = 360 - angle;

            return Math.Round(angle, 4);
        }
        //Статическая функция
        public static double GetLittleAngleStatic(DialClock dialClock)
        {
            double hourAngle = (dialClock.hours % 12 * 30) + (dialClock.minutes / 2);
            double minuteAngle = dialClock.minutes * 6;
            double angle = Math.Abs(hourAngle - minuteAngle);

            if (angle > 180)
                angle = 360 - angle;

            return Math.Round(angle, 4);
        }


        public int ParseToDC(string str, string numberFunction)
        {
            switch (numberFunction)
            {
                case "1":
                    int hours;
                    bool isDigit1 = int.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out hours);
                    while (!isDigit1 || (hours < 0) || (hours > 1000))
                    {
                        Console.Write("Вы неправильно ввели кол-во часов, пожалуйста, повторите ввод: ");
                        str = Console.ReadLine();
                        isDigit1 = int.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out hours);
                    }
                    return hours;
                case "2":
                    int minutes;
                    bool isDigit2 = int.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out minutes);
                    while (!isDigit2 || (minutes < 0) || (minutes > 1000))
                    {
                        Console.Write("Вы неправильно ввели кол-во минут, пожалуйста, повторите ввод: ");
                        str = Console.ReadLine();
                        isDigit2 = int.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out minutes);
                    }
                    return minutes;
            }
            return 1;
        }


        public bool IsEquals(DialClock dialClock1, DialClock dialClock2)
        {
            if (dialClock1 == null && dialClock2 == null)
                return false;
            if (dialClock1.hours == dialClock2.hours && dialClock1.minutes == dialClock2.minutes)
                return true;
            else
                return false;
        }

        //Добавление минуты к времени
        public static DialClock operator ++(DialClock clock)
        {
            objectCount++;
            DialClock newClock = new DialClock(clock.hours, clock.minutes + 1);
            return newClock;
        }

        //Убавление минуты от времени           
        public static DialClock operator --(DialClock clock)
        {
            objectCount++;
            DialClock newClock = new DialClock(clock.hours, clock.minutes - 1);
            return newClock;
        }

        //Операции приведения типа
        public static explicit operator bool(DialClock clock)
        {
            objectCount++;
            DialClock newClock = new DialClock(clock.hours, clock.minutes);
            return newClock.GetLittleAngle() % 2.5 == 0;
        }

        public static implicit operator int(DialClock clock)
        {
            objectCount++;
            DialClock newClock = new DialClock(clock.hours, clock.minutes);
            return newClock.minutes + newClock.hours * 60;
        }


        //Добавление минут с лева и справа
        public static DialClock operator +(DialClock clock, int minutesToAdd)
        {
            objectCount++;
            DialClock newClock = new DialClock(clock.hours, clock.minutes);
            newClock.minutes += minutesToAdd;
            if (newClock.minutes >= 60)
            {
                int additionalHours = newClock.minutes / 60;
                newClock.minutes = newClock.minutes % 60;
                newClock.hours += additionalHours;
                if (newClock.hours >= 24)
                {
                    newClock.hours = newClock.hours % 24;
                }
            }
            return newClock;
        }
        public static DialClock operator +(int minutesToAdd, DialClock clock)
        {
            objectCount++;
            DialClock newClock = new DialClock(clock.hours, clock.minutes);
            newClock.minutes += minutesToAdd;
            if (newClock.minutes >= 60)
            {
                int additionalHours = newClock.minutes / 60;
                newClock.minutes = newClock.minutes % 60;
                newClock.hours += additionalHours;
                if (newClock.hours >= 24)
                {
                    newClock.hours = newClock.hours % 24;
                }
            }
            return newClock;
        }

        //Убавление минут с лева и справа
        public static DialClock operator -(DialClock clock, int minutesToSubtract)
        {
            objectCount++;
            DialClock newClock = new DialClock(clock.hours, clock.minutes);
            newClock.minutes -= minutesToSubtract;
            if (newClock.minutes < 0)
            {
                int borrowHours = Math.Abs(newClock.minutes / 60) + 1;
                newClock.minutes = 60 + (newClock.minutes % 60);
                newClock.hours -= borrowHours;
                if (newClock.hours < 0)
                {
                    newClock.hours = 24 + (newClock.hours % 24);
                }
            }
            return newClock;
        }


        //Кол-во созданных объектов в классе 
        public static int GetObjectCount()
        {
            return objectCount;
        }
        public double CalculateClockAngleMethod()
        {
            return GetLittleAngle();
        }

        public void Init()
        {
            
            int vl;            
            Console.Write("Введите часы: ");
            vl = ParseToInt(Console.ReadLine());
            Hours = vl;
            Console.Write("Введите минуты: ");
            vl = ParseToInt(Console.ReadLine());
            Minutes = vl;
        }

        //Метод для ввода информации об автомобиле случайно
        public void RandomInit()
        {            
            Hours = rand.Next(0, 25);
            Minutes = rand.Next(0, 61);
        }

        //Для преобразования в int
        protected int ParseToInt(string str)
        {
            int vl;
            bool success = int.TryParse(str, out vl);
            if (success)
                return vl;
            else
            {
                Console.WriteLine("Вы неправильно ввели значение, будет присвоено значение по умолчанию.");
                return 0;
            }
        }
    }
}


