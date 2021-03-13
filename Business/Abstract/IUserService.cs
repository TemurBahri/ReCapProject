using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using User = Entities.Concrete.User;

namespace Business.Abstract
{

    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        List<OperationClaim> GetClaims(User user); IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);

        User GetByMail(string email);
        object GetClaims(Core.Entities.Concrete.User user);
    }
}
