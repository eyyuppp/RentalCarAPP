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
    public class BrandManager : IBrandService
    {
        //_brandDal.GetRepository<Brand>() her defasında yazmamak için bir algoritma geliştir
        IUnitOfWork _unitOfWork;
        
        public BrandManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IResult Add(Brand entity)
        {
            _unitOfWork.GetRepository<Brand>().Add(entity);
           
            if (_unitOfWork.Save()>=0)
            {
                return new SuccessResult(Messages.CarAdded);
            }
            return new ErrorResult(Messages.CarError);

        }

        public IResult Delete(int id)
        {
            var deleteBrand= _unitOfWork.GetRepository<Brand>().GetById(id);
            _unitOfWork.GetRepository<Brand>().Delete(deleteBrand);
            if (_unitOfWork.Save()>=0)
            {
                return new SuccessResult(Messages.CarDeleted);
            }
            return new ErrorResult(Messages.CarError);  
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var getAll = _unitOfWork.GetRepository<Brand>().GetAll();
                return new SuccessDataResult<List<Brand>>(getAll, Messages.CarsListed);
        }


        public IResult Update(Brand entity)
        {
            _unitOfWork.GetRepository<Brand>().Update(entity);
          
            if (_unitOfWork.Save()>=0)
            {
                return new SuccessResult(Messages.CarUpdated);
            }
            return new ErrorResult(Messages.CarError);

        }
    }
}
