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
        
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        
        IDataResult< List<Car>> GetCarsByColorId(int id);
        
        IDataResult<List<Car>> GetByDaylyUnitPrice(decimal min, decimal max);
        
        IDataResult<List<CarDetailDto>> GetCarDetails();
        
        IDataResult<Car> GetById(int id);
        
        IResult Add(Car entity);
        
        IResult Delete(Car entity);
        
        IResult Update(Car entity);
        IResult AddTransactionalTest(Car car);
    }
}
