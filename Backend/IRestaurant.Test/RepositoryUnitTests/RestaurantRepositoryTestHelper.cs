using IRestaurant.DAL.Data;
using IRestaurant.DAL.Repositories;
using IRestaurant.DAL.Repositories.Implementations;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.Test.RepositoryUnitTests
{
    public class RestaurantRepositoryTestHelper
    {
        public Mock<IImageRepository> ImageRepository { get; private set; }

        public RestaurantRepositoryTestHelper()
        {
            ImageRepository = new Mock<IImageRepository>();
            ImageRepository.Setup(i => i.UploadImage(It.IsAny<IFormFile>(), It.IsAny<string>()))
                .ReturnsAsync((IFormFile iff, string _) => iff.FileName);
        }

        public IRestaurantRepository CreateRestaurantRepository(ApplicationDbContext dbContext)
        {
            var imageRepository = new Mock<IImageRepository>();
            return new RestaurantRepository(dbContext, imageRepository.Object);
        }

        public IRestaurantRepository CreateRestaurantRepository(ApplicationDbContext dbContext, IImageRepository imageRepository)
        {
            return new RestaurantRepository(dbContext, imageRepository);
        }
    }
}
