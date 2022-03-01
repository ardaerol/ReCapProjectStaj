using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if(car.Description.Length>=2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new Result(true, "Araba eklendi.");
            }
            return new Result(false, "Araba eklenemedi."); 
            
        }

        public IResult Delete(int id)
        {
            var car = _carDal.Get(c => c.CarId == id);
            _carDal.Delete(car);
            return new Result(true, "Araba silindi.");
            
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int carId)
        {
            return _carDal.Get(c => c.CarId == carId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("araba güncellendi");
        }
    }
}
