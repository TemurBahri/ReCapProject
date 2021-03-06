using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
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

        [ValidationAspect(typeof(CarValidator))]

        public IResult Add(Car entity)
        {
            if(entity.CarName.Length<10)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }

            ValidationTool.Validate(new CarValidator(), entity);

            _carDal.Add(entity);
            
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car entity)
        {
            
            var car = _carDal.GetById(entity.CarId);
            
            if(car == null)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarDeletedError);

            }
            
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }


        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if(DateTime.Now.Hour == default)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        public IDataResult< List<Car>> GetByDaylyUnitPrice(decimal min, decimal max)
        {
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.DailyPrice >= min && x.DailyPrice <= max));
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails());
        }

        [CacheAspect]
        public IDataResult< List<Car>> GetCarsByBrandId(int id)
        {
            

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b => b.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }
        
        public IResult Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult(Messages.CarUpdate);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);

            if (car.DailyPrice < 30)
            {
                throw new Exception("20 birim fiyatını geçemez");
            }
            Add(car);

            return null;
        }
    }
}
