using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUnitOfWork _user;
        public UserManager(IUnitOfWork user) 
        {
            _user = user;
        }
        public IResult Add(User entity)
        {
             _user.GetRepository<User>().Add(entity);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(int id)
        {
            var deleteUser= _user.GetRepository<User>().GetById(id);
            _user.GetRepository<User>().Delete(deleteUser);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_user.GetRepository<User>().GetAll(),Messages.CarsListed);
        }

        

        public IResult Update(User entity)
        {
            _user.GetRepository<User>().Update(entity);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
