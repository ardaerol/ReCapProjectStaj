﻿using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new CarDetailDto
                             {
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 BrandName = b.BrandName,
                                 Description =c.Description

                             };
                return result.ToList(); 
            }
        }
    }
}