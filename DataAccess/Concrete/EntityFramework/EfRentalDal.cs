using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalsDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                                 on r.CarId equals c.Id
                             join cu in context.Customers
                                 on r.CustomerId equals cu.Id
                             join u in context.Users
                                 on cu.Id equals u.Id
                             join b in context.Brands
                                 on c.BrandId equals b.Id
                             select new RentalDetailDto
                             {
                                 Id = r.RentalId,
                                 CarId = c.Id,
                                 CustomerId = cu.Id,
                                 ReturnDate = r.ReturnDate,
                                 RentDate = r.RentDate

                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
    }
}