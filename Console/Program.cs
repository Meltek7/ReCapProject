using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager=new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Car ID:{0}, Brand ID:{1}, Color ID:{2}, Daily Price:{3}, Description:{4}", car.Id, car.BrandId, car.ColorId, car.DailyPrice, car.Description);
            }
        }
    }
}
