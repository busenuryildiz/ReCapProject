using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
       

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int BrandId)
        {
            return _carDal.GetAll(c => c.BrandId == BrandId);
        }


        public List<Car> GetCarsByColorId(int ColorId)
        {
            return _carDal.GetAll(c => c.ColorId == ColorId);
        }
        public void Add(Car car)
        {
            if (car.Name.Length >= 2 && car.DailyPrice >= 0)
            {
                _carDal.Add(car);
            }
        }

        public void Delete(Car car)
        {
            throw new NotImplementedException();
        }
        public void Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
