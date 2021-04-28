using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetAllByColor(int id);
        List<Car> GetAllByBrand(int id);

        void Update(Car car);
        void Add(Car car);
        void Delete(Car car);
    }
}
