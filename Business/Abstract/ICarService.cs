using Core.DataAccess;
using DataAccess.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService
    {
        List<Car> GetAll();
        List<CarDetailDto> GetCarDetails();
        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int id);
        Car GetById(int carId);
        IResult Add(Car car);
        void Update(Car car);
        IResult Delete(int id);
    }
}
