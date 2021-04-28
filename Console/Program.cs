using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            TestingCar();
            TestingColor();
            TestingBrand();
        }

        private static void TestingCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            Console.WriteLine("Cars : ");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Car ID:{0}, Brand ID:{1}, Color ID:{2}, Daily Price:{3}, Description:{4}", car.Id, car.BrandId, car.ColorId, car.DailyPrice, car.Description);
            }
        }

        private static void TestingColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("----------");
            Console.WriteLine("Colors : ");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Id + " " + color.Name );
            }
        }

        private static void TestingBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("----------");
            Console.WriteLine("Brands : ");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Id + " " + brand.Name);
            }
        }

    }
}
