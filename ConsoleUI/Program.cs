using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            // CarManager carManager = new CarManager(new InMemoryCarDal()); 

            //CarManager carManager = new CarManager(new EFCarDal());

            

            //foreach (var car in carManager.GetAll())
            //foreach (var car in carManager.GetByDaylyUnitPrice(150, 200))
            //{
            //    Console.WriteLine(car.CarName + " " + car.ModelYear + " " + car.DailyPrice + " " + car.Description);
            //}
            //foreach (var car in carManager.GetCarDetails())         
            //{
            //    Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName+" " +car.DailyPrice);
            //}
        }
    }
}
