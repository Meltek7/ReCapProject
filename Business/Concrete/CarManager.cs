using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.InvalidName);
            }
        }

        public IResult Delete(Car car)
        {

            try
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.Deleted);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.Error);
            }
        }

        public IDataResult<List<Car>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.Listed);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Car>>((Messages.Error));
            }
        }

        public IDataResult<List<Car>> GetAllByBrand(int id)
        {
            try
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Car>>(Messages.Error);
            }

        }

        public IDataResult<List<Car>> GetAllByColor(int id)
        {
            try
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Car>>(Messages.Error);
            }

        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            try
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());

            }
            catch (Exception)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.Error);
            }

        }

        public IResult Update(Car car)
        {
            try
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.Updated);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.Error);

            }

        }
    }
}
