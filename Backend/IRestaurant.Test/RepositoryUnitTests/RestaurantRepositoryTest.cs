using IRestaurant.DAL.Data;
using IRestaurant.DAL.Repositories;
using IRestaurant.DAL.Repositories.Implementations;
using Microsoft.AspNetCore.Http;
using Moq;

namespace IRestaurant.Test.RepositoryUnitTests
{
    public class RestaurantRepositoryTest : RestaurantRepositoryTestBase
    {
        public override IRestaurantRepository CreateRestaurantRepository(ApplicationDbContext dbContext)
        {
            var imageRepository = new Mock<IImageRepository>();
            imageRepository.Setup(i => i.UploadImage(It.IsAny<IFormFile>(), It.IsAny<string>()))
                .ReturnsAsync((IFormFile iff, string _) => iff.FileName);

            return new RestaurantRepository(dbContext, imageRepository.Object);
        }
    }
}
