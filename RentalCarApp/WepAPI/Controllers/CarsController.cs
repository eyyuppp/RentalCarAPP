using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess;
using Entities.Concrete;
using Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace WepAPI.Controllers
//body=json
//query=link
//IActionResult kullanmamın nedeni kulanıcı örneğin olmayan bir ıd girdiğinde hata gönder 
{
    [Route("api/[controller]")]
    [ApiController]//Validation işlemlerini kontrol eder(başarılı veya başarısız)
    public class CarsController : ControllerBase
    {
        ICarService _carService;
        MyCarContext _context;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }
       

        /// <summary>
        /// Tüm arabaları getir
        /// </summary>
        /// <returns></returns>

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteCarBrandID")]
        public IActionResult DeleteCarBrandID(DeleteCarBrand carBrand)
        {
            var result = _carService.DeleteCarBrandId(carBrand.CarId, carBrand.BrandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("GetDetilAll")]
        public List<CarDetail> GetDetail()
        {
            var result = _carService.GetDetail().ToList();

            return result;
        }

        [HttpGet("GetCarId")]
        public IActionResult GetCarId(int id)
        {
            var result = _carService.GetCarID(id);
            if (result.Success)
            {
                return Ok(result);//200+ gönder success(başarılı) gönder
            }
            return BadRequest(result);//404+ gönder hata gönder
        }

        [HttpGet("GetBrandId")]
        public IActionResult GetCarsBrandId(int id)
        {
            var result = _carService.GetCarsBrandId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult AddCar(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("AddCarColor")]
        public IActionResult AddCarColor(AddCarColor addCarColor)
        {
            var result = _carService.AddCarColor(addCarColor);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteCar(int id)
        {
            var result = _carService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        //Patch kısmi güncelleme(istediğin yeri güncelemek için)
        [HttpPut("Update")]
        public IActionResult UpdateCar(Car car)
        {
            var result = _carService.Update(car);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


       
        

    }
}
