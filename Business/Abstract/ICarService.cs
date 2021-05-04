using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByColor(int id);
        IDataResult<List<Car>> GetAllByBrand(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails(); 

        IResult Update(Car car);
        IResult Add(Car car);
        IResult Delete(Car car);
    }
}
