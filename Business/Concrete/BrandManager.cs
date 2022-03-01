using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
             _brandDal.Add(brand);
            Console.WriteLine("marka eklendi");
        }

        public void Delete(int id)
        {
            var brand = _brandDal.Get(b => b.BrandId == id);
            _brandDal.Delete(brand);
            Console.WriteLine("marka silindi");
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.Get(b=>b.BrandId==id);
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
            Console.WriteLine("marka güncellendi");
        }
    }
}
