using DataAccess.Concrete.InMemory;
using Business.Concrete;
using System;
using Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Business.Abstract;
using DataAccess.Abstract;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //hoj
            //CarManager carManager = new CarManager(new EfCarDal());
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.CarId);
            //}
            //CarAddTest();
            Car car1 = new Car { CarId = 4, BrandId = 2, ColorId = 5, DailyPrice = 310000, Description = "2.el audi", ModelYear = 2021 };
            ICarDal carDal = new EfCarDal();
            ICarService carServicer = new CarManager(carDal);
            carServicer.Update(car1);
            

            // CarDetailsTest(carService);
            Color color1 = new Color { ColorId = 5, ColorName = "siyah" };
            IColorDal colorDal = new EfColorDal();
            IColorService colorService = new ColorManager(colorDal);
            // colorService.Add(color1);
            CarDetailsTest(carServicer);


            //BrandTest();

            //ColorAddTest();

            // ColorGetAllTest(colorService);
        }

        private static void ColorAddTest()
        {
            Color color1 = new Color { ColorId = 2, ColorName = "fıstık yeşili" };
            IColorDal colorDal = new EfColorDal();
            IColorService colorService = new ColorManager(colorDal);
            colorService.Add(color1);
        }

        private static void ColorGetAllTest(IColorService colorService)
        {
            var colors = colorService.GetAll();
            foreach (var item in colors)
            {
                Console.WriteLine(item.ColorName);
            }
        }

        private static void CarAddTest()
        {
            Car car1 = new Car { CarId = 3, BrandId = 1, ColorId = 1, DailyPrice = 310000, Description = "2.el golf", ModelYear = 2021 };
            ICarDal carDal = new EfCarDal();
            ICarService carServicer = new CarManager(carDal);
            carServicer.Add(car1);
        }
        
        private static void CarDetailsTest(ICarService carServicer)
        {
            ICarDal carDal = new EfCarDal();
            ICarService carService = new CarManager(carDal);
            var car2 = carServicer.GetCarDetails();
            foreach (var item in car2)
            {
                Console.WriteLine(item.ColorName + " " + item.BrandName + " " + item.DailyPrice + " " + item.Description);
            }
        }

        private static void BrandTest()
        {
            Brand brand1 = new Brand { BrandId = 4, BrandName = "Mercedes" };
            IBrandDal brandDal = new EfBrandDal();
            IBrandService brandService = new BrandManager(brandDal);
            brandService.Add(brand1);
            var brands = brandService.GetAll();
            foreach (var item in brands)
            {
                Console.WriteLine(item.BrandName);
            }
        }
    }
}
