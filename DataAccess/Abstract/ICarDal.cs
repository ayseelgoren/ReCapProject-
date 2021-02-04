using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        // GetById, GetAll, Add, Update, Delete

        List<Car> GetAll();

        List<Car> GetById(int carId);

        void Add(Car car);

        void Update(Car car);

        void Delete(Car car);

    }
}
