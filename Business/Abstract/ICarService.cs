using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetById(int carId);

        void Add(Car car);

        void Update(Car car);

        void Delete(Car car);


    }
}
