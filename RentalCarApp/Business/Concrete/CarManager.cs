using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.DTO;

namespace Business.Concrete
{
    //Dependency Injection kullandık
    public class CarManager : ICarService
    {
        //Örneğin,"invoke" kelimesi, bir methodu çağırmak için kullanılabilir:

        //unitTOfork araştır //birden fazla veri aynı anda veri tabanına kaydedmek için kullanırız.
        //Bu pattern, iş katmanında yapılan her değişikliğin anlık olarak database e yansıması yerine, 
        //işlemlerin toplu halde tek bir kanaldan gerçekleşmesini sağlar.

        IUnitOfWork _unitOfWork;

        public CarManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;


        }

        public IResult Add(Car car)
        {
            _unitOfWork.GetRepository<Car>().Add(car);

            if (_unitOfWork.Save() > 0)
            {
                if (car.ModelYear > 0 && car.UnitPrice > 0)
                {

                    return new SuccessResult(Messages.CarAdded);
                }
            }
            return new ErrorResult(Messages.CarNameInvaled);
        }

        public IResult AddCarColor(AddCarColor addCarColor)
        {
            if (addCarColor.Car != null && addCarColor.Color != null)
            {
                _unitOfWork.GetRepository<Color>().Add(addCarColor.Color);
                _unitOfWork.GetRepository<Car>().Add(addCarColor.Car);
                if (_unitOfWork.Save() > 0)
                {
                    return new SuccessResult(Messages.CarAdded);
                }
            }
            return new ErrorResult(Messages.CarError);

        }

        public IResult Delete(int id)
        {
            var deleteCar = _unitOfWork.GetRepository<Car>().GetById(id);

            _unitOfWork.GetRepository<Car>().Delete(deleteCar);
            if (_unitOfWork.Save() > 0)
            {
                return new SuccessResult(Messages.CarDeleted);
            }
            return new ErrorResult(Messages.CarError);

        }


        public IResult DeleteCarBrandId(int carId, int brandId)
        {
            if (carId > 0 && brandId > 0)
            {
                Car carDelete = _unitOfWork.GetRepository<Car>().GetById(carId);
                Brand brandDelete = _unitOfWork.GetRepository<Brand>().GetById(brandId);

                if (carDelete != null && brandDelete != null)
                {
                    _unitOfWork.GetRepository<Car>().Delete(carDelete);
                    _unitOfWork.GetRepository<Brand>().Delete(brandDelete);
                    if (_unitOfWork.Save() > 0)
                    {

                    }
                
                    return new SuccessResult(Messages.CarDeleted);
                }


            }

            return new ErrorResult(Messages.CarError);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_unitOfWork.GetRepository<Car>().GetAll(), Messages.CarsListed);
        }

        public IDataResult<Car> GetCarID(int id)
        {
            return new SuccessDataResult<Car>(_unitOfWork.GetRepository<Car>().GetById(id));
        }

        public IDataResult<List<Car>> GetCarsBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_unitOfWork.GetRepository<Car>().GetAll().Where(p => p.CarID == id).ToList(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_unitOfWork.GetRepository<Car>().GetAll().Where(p => p.CarID == id).ToList(), Messages.CarsListed);
        }

        public List<CarDetail> GetDetail()
        {
            var _carContext = _unitOfWork.GetRepository<Car>().GetContext();
            var detailtojoin = _carContext.Cars.Join((_carContext.Brands),
                c => c.BrandID, b => b.BrandID, (car, brand) => new
                {
                 //araba nesnesini oluşturduk
                 Car=car,
                 BrandName=brand.BrandName

                }).Join(_carContext.Colors, c => c.Car.ColorID, cl => cl.ColorID, (car, color) => new CarDetail()
                {
                   BrandName=car.BrandName,
                   CarDetailId=car.Car.CarID,
                   ColorName=color.ColorName,
                   ModelYear=car.Car.ModelYear,
                   UnitPrice=car.Car.UnitPrice
                }).ToList();
            

            return detailtojoin;

           

        }

       

        public IResult Update(Car car)
        {
            _unitOfWork.GetRepository<Car>().Update(car);
            if (_unitOfWork.Save() > 0)
            {
                return new SuccessResult(Messages.CarUpdated);
            }
            return new ErrorResult(Messages.CarError);
        }
    }
}
