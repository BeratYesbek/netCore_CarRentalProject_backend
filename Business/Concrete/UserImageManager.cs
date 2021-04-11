using Business.Abstract;
using Business.Validation.FluentValidation;
using Core.Autofac.Caching;
using Core.Autofac.Performance;
using Core.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileManage.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class UserImageManager : IUserImageService
    {
        IUserImageDal _userImageDal;

        public UserImageManager(IUserImageDal userImageDal)
        {
            _userImageDal = userImageDal;
        }


        [CacheRemoveAspect("IUserImageService.Get")]
        [PerformanceAspect(5)]
        public IResult Add(IFormFile file, UserImage userImage)
        {
           

            var imageResult = FileHelper.Upload(file);

            if (!imageResult.Success)
            {
                return new ErrorResult("");
            }
            userImage.ImagePath = imageResult.Message;
            _userImageDal.Add(userImage);

            return new SuccessResult("Car image added");
        }

        [CacheRemoveAspect("IUserImageService.Get")]
        [ValidationAspect(typeof(UserImageValidator))]
        [PerformanceAspect(5)]
        public IResult Delete(UserImage userImage)
        {
            var result = _userImageDal.Get(u => u.UserImageId == userImage.UserImageId);
            if (result == null)
            {
                return new ErrorResult("Image not found");
            }

            FileHelper.Delete(result.Data.ImagePath);
            _userImageDal.Delete(userImage);
            return new SuccessResult("Image was deleted successfully");
        }

        [ValidationAspect(typeof(UserImageValidator))]
        [CacheRemoveAspect("IUserImageService.Get")]
        [PerformanceAspect(5)]
        public IResult Update(IFormFile file, UserImage userImage)
        {
         
            var updatedFile = FileHelper.Update(file, userImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            userImage.ImagePath = updatedFile.Message;
            _userImageDal.Update(userImage);

            return new SuccessResult("Image updated");
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<UserImage>> GetAll()
        {
            return _userImageDal.GetAll();
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<UserImage>> GetImagesByUserId(int id)
        {
            IResult result = BusinessRules.run(CheckIfUserImageNull(id));

            if (result != null)
            {
                return new ErrorDataResult<List<UserImage>>();
            }

            return new SuccessDataResult<List<UserImage>>(CheckIfUserImageNull(id).Data);
        }

        private IDataResult<List<UserImage>> CheckIfUserImageNull(int id)
        {
            try
            {
                string path = @"\images\logo.jpg";
                var result = _userImageDal.GetAll(u => u.UserId == id);
                if (result.Success)
                {
                    List<UserImage> image = new List<UserImage>();
                    image.Add(new UserImage { UserId = id, ImagePath = path});
                    return new SuccessDataResult<List<UserImage>>(image);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<UserImage>>(exception.Message);
            }

            return _userImageDal.GetAll(p => p.UserId == id);
        }

    
    }
}
