using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            TestingCar();
            TestingCarDetail();
            TestingColor();
            TestingBrand();

        }

        private static void TestingCarDetail()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(result.Message);
                    Console.WriteLine("Car " + car.CarId + ":" + car.Description + " / " + car.BrandName + " / " + car.ModelYear + " / " + car.ColorName);
                    Console.WriteLine("        Daily Price : " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void TestingCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAll();

            Console.WriteLine("Cars : ");
            foreach (var car in result.Data)
            {
                Console.WriteLine("Car ID:{0}, Brand ID:{1}, Color ID:{2}, Daily Price:{3}, Description:{4}", car.Id, car.BrandId, car.ColorId, car.DailyPrice, car.Description);
            }
        }

        private static void TestingColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("----------");
            Console.WriteLine("Colors : ");

            var result = colorManager.GetAll();
            if (result.Success==true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.Id + " " + color.Name);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            Color color1 = new Color() { Id = 4, Name = "White" };


            List<Color> list = result.Data;

            for (int i = 0; i < list.Count; i++)

            {
                Color color = list[i];
                if (color1.Id == color.Id)
                {
                    Console.WriteLine("----------");
                    colorManager.Delete(color1);
                    Console.WriteLine("Colors After Deleting : ");

                    foreach (var color2 in result.Data)
                    {
                        Console.WriteLine(color2.Id + " " + color2.Name);
                    }
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                Color color = list[i];
                if (color1.Id != color.Id)
                {
                    Console.WriteLine("----------");
                    colorManager.Add(color1);
                    Console.WriteLine("Colors After Adding : ");
                    foreach (var color3 in result.Data)
                    {
                        Console.WriteLine(color3.Id + " " + color3.Name);
                    }
                    break;
                }
            }

            Color color4 = new Color() { Id = 4, Name = "Black" };

            Console.WriteLine("----------");
            colorManager.Update(color4);
            Console.WriteLine("Colors After Updating : ");
            foreach (var color in result.Data)
            {
                Console.WriteLine(color.Id + " " + color.Name);
            }


        }

        private static void TestingBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("----------");
            Console.WriteLine("Brands : ");

            var result = brandManager.GetAll();
            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.Id + " " + brand.Name);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            

            Brand brand1 = new Brand() { Id = 4, Name = "Chevrolet" };

            List<Brand> list = result.Data;

            for (int i = 0; i < list.Count; i++)

            {
                Brand brand = list[i];
                if (brand1.Id == brand.Id)
                {
                    Console.WriteLine("----------");
                    brandManager.Delete(brand1);
                    Console.WriteLine("Brands After Deleting : ");

                    foreach (var brand2 in result.Data)
                    {
                        Console.WriteLine(brand2.Id + " " + brand2.Name);
                    }
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                Brand brand = list[i];
                if (brand1.Id != brand.Id)
                {
                    Console.WriteLine("----------");
                    brandManager.Add(brand1);
                    Console.WriteLine("Brands After Adding : ");
                    foreach (var brand3 in result.Data)
                    {
                        Console.WriteLine(brand3.Id + " " + brand3.Name);
                    }
                    break;
                }
            }

            foreach (var brand in result.Data)
            {
                if (brand.Name == "Chevrolet")
                {
                    Brand brand4 = new Brand() { Id = 4, Name = "Cadillac" };
                    Console.WriteLine("----------");
                    brandManager.Update(brand4);
                    Console.WriteLine("Brands After Updating : ");
                    foreach (var brand5 in result.Data)
                    {
                        Console.WriteLine(brand5.Id + " " + brand5.Name);
                    }

                }
                else if (brand.Name == "Cadillac")
                {
                    Brand brand5 = new Brand() { Id = 4, Name = "Chevrolet" };
                    Console.WriteLine("----------");
                    brandManager.Update(brand5);
                    Console.WriteLine("Brands After Updating : ");
                    foreach (var brand6 in result.Data)
                    {
                        Console.WriteLine(brand6.Id + " " + brand6.Name);
                    }
                }

            }

        }

    }
}
