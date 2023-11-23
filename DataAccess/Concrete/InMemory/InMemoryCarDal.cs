using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car {Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 1000, Description = "Volvo", ModelYear = 2010 },
                new Car {Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 700, Description = "Volkswagen", ModelYear = 2015 },
                new Car {Id = 3, BrandId = 3, ColorId = 3, DailyPrice = 1200, Description = "Audi", ModelYear = 2020 },
                new Car {Id = 4, BrandId = 4, ColorId = 4, DailyPrice = 1500, Description = "BMW", ModelYear = 2022 }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }
        public void Update(Car car)
        {
            Car carUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carUpdate.Id = car.Id;
            carUpdate.BrandId = car.BrandId;
            carUpdate.ColorId = car.ColorId;
            carUpdate.ModelYear = car.ModelYear;
            carUpdate.DailyPrice = car.DailyPrice;
            carUpdate.Description = car.Description;
        }
        public void Delete(Car car)
        {
            var deleteCar = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(deleteCar);
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
        
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
            }
    }
}
