using Core.Utilities.Result.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserImageService
    {
        IResult Add(IFormFile file, UserImage userImage);
        IResult Delete(UserImage userImage);
        IResult Update(IFormFile file, UserImage userImage);
        IDataResult<List<UserImage>> GetAll();
        IDataResult<List<UserImage>> GetImagesByUserId(int id);
    }
}
