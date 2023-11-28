using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            using (ReCapContext _context = new ReCapContext())
            {
                var userExist = _userDal.GetAll(x => x.Id == user.Id).Any();

                if (userExist)
                {
                    return new ErrorResult(Messages.UsersExistErrorMessage);
                }

                _userDal.Add(user);

                var isUserAdded = _context.Set<User>().Any(x => x.Id == user.Id);

                return isUserAdded
                    ? new SuccessResult(Messages.UsersAddedSuccessMessage)
                    : new ErrorResult(Messages.UsersAddedErrorMessage);
            }
        }
        public IResult Delete(User user)
        {
            _userDal.Delete(user);

            using (ReCapContext _context = new ReCapContext())
            {
                var isUserDeleted = !_context.Set<User>().Any(x => x.Id == user.Id);

                return isUserDeleted
                    ? new SuccessResult(Messages.UsersDeletedSuccessMessage)
                    : new ErrorResult(Messages.UsersDeletedErrorMessage);
            }
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(c => c.Id == id), Messages.UsersListedSuccessMessage);
        }
        public IDataResult<List<User>> GetAll(Expression<Func<User, bool>> filter = null)
        {
            var userList = filter == null ? _userDal.GetAll() : _userDal.GetAll(filter);

            if (!userList.Any())
            {
                return new ErrorDataResult<List<User>>(null, Messages.UsersListedErrorMessage);
            }

            return new SuccessDataResult<List<User>>(userList, Messages.UsersListedSuccessMessage);
        }


        public IResult Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
