using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO;

namespace Business.Abstract
{
    public interface ICarService :IEntityService<Car>
    {
       
        IDataResult<List<Car>> GetCarsBrandId(int  id);
        IDataResult<List<Car>> GetCarsColorId(int id);
        List<CarDetail>GetDetail();
        IDataResult<Car> GetCarID(int id);
        IResult DeleteCarBrandId(int carId,int brandId);
        IResult AddCarColor(AddCarColor addCarColor);

        

    }
}
