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
    public class ColorManager : IColorService
    {
        IUnitOfWork _unitOfWorkColor;
        public ColorManager(IUnitOfWork colorDal)
        {
            _unitOfWorkColor = colorDal;
        }

        public IResult Add(Color entity)
        {
            _unitOfWorkColor.GetRepository<Color>().Add(entity);
            if (_unitOfWorkColor.Save()>0)
            {
                return new SuccessResult(Messages.CarAdded);
            }
            return new ErrorResult(Messages.CarError);
        }

        public IResult Delete(int id)
        {
            var deleteColor= _unitOfWorkColor.GetRepository<Color>().GetById(id);
            _unitOfWorkColor.GetRepository<Color>().Delete(deleteColor);
            if (_unitOfWorkColor.Save() > 0)
            {
                return new SuccessResult(Messages.CarDeleted);
            }
           return new ErrorResult(Messages.CarError);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_unitOfWorkColor.GetRepository<Color>().GetAll(),Messages.CarsListed);
        }

       
        public IResult Update(Color entity)
        {
            _unitOfWorkColor.GetRepository<Color>().Update(entity);
            if (_unitOfWorkColor.Save()>0)
            {
                return new SuccessResult(Messages.CarUpdated);
            }
            return new ErrorResult(Messages.CarError);
        }
    }
}
