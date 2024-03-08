﻿using System;

namespace LibraryForLabs
{
    public class TruckCar : Cars
    {
        //Грузоподъемность
        private int loadCapacity;

        //Конструктор без параметра
        public TruckCar() : base()
        {
            loadCapacity = 550;
        }

        //Конструктор с параметрами
        public TruckCar(string brand, int releaseYear, string color, int cost, double clearance, int loadCapacity, int idNumber) : base(brand, releaseYear, color, cost, clearance, idNumber)
        {
            LoadCapacity = loadCapacity;
        }

        // Свойство для доступа к грузоподъемности
        public int LoadCapacity
        {
            get
            {
                return loadCapacity;
            }
            set
            {
                if (value > 2000)
                    loadCapacity = 2000;
                else if (value < 550)
                    loadCapacity = 550;
                else
                    loadCapacity = value;
            }
        }

        //Метод для вывода информации о машине
        public override void Show()
        {
            base.Show();
            Console.WriteLine("Грузоподъемность (в кг): " + loadCapacity);
        }

        //Метод для вывода информации о машине не виртуальный
        public new void ShowNotVirtual()
        {
            base.ShowNotVirtual();
            Console.WriteLine("Грузоподъемность (в кг): " + loadCapacity);
        }
        //Метод для ввода информации об автомобиле
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите грузоподъемность");
            int vl = ParseToInt(Console.ReadLine());
            LoadCapacity = vl;
        }

        //Метод для ввода информации об автомобиле случайно
        public override void RandomInit()
        {
            base.RandomInit();
            LoadCapacity = rand.Next(550, 2000);
        }

        //Метод для сравнения
        public override bool Equals(object obj)
        {
            if (obj is TruckCar car)
                return (LoadCapacity == car.LoadCapacity) && base.Equals(car);
            else
                return false;
        }
    }
}
