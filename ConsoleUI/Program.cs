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

            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());


            // COLOR
            Console.WriteLine("---Renkler---");
            foreach (var c in colorManager.GetAll())
            {
                Console.WriteLine(c.Name);
            }
            Console.WriteLine("0 id li renk : " + colorManager.GetById(0).Name);
            Console.WriteLine();



            // BRAND 
            Console.WriteLine("---Markalar---");

            foreach (var b in brandManager.GetAll())
            {
                Console.WriteLine(b.Name);
            }
            Console.WriteLine("0 id li marka : " + brandManager.GetById(0).Name);

            Console.WriteLine();



            // CAR
            Console.WriteLine("---Arabalar---");

            //carManager.Add(new Car { Id = 8, BrandId = 1, ColorId = 2, DailyPrice = 100000, Description = "Clio", ModelYear = 2000 });
            //carManager.Delete(new Car { Id = 8, BrandId = 1, ColorId = 2, DailyPrice = 100000, Description = "Clio", ModelYear = 2000 });
            //carManager.Add(new Car { Id = 2, BrandId = 1, ColorId = 2, DailyPrice = 100000, Description = "Clio", ModelYear = 2000 });
            //carManager.Update(new Car { Id = 5, BrandId = 0, ColorId = 0, DailyPrice = 100000, Description = "Dacia Duster", ModelYear = 2000 });
            foreach (var c in carManager.GetAll())
            {
                 Console.WriteLine(c.Description);
            }
            Console.WriteLine("2 id li araba : "+carManager.GetById(2).Description);
            Console.WriteLine();



            // GetCarsByBrandId
            Console.WriteLine("---0 Marka Idli Arabalar---");
            foreach (var brandIdCar in carManager.GetCarsByBrandId(0))
            {
                Console.WriteLine(brandIdCar.Description);
            }
            Console.WriteLine();


            // GetCarsByColorId
            Console.WriteLine("---0 Renk Idli Arabalar---");
            foreach (var colorIdCar in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine(colorIdCar.Description);
            }
            Console.WriteLine();





            //CarName, BrandName, ColorName, DailyPrice listelenmesi
            foreach (var carDetail in carManager.GetCarDetails())
            {
                Console.WriteLine(carDetail.CarName+"\t"+ carDetail.BrandName + "\t"+ carDetail.ColorName + "\t"+ carDetail.DailyPrice + "\t");
            }
        }
    }
}
