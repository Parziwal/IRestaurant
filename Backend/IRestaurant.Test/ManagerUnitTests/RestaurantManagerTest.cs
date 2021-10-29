using Hellang.Middleware.ProblemDetails;
using IRestaurant.BL.Managers;
using IRestaurant.DAL.DTO.Foods;
using IRestaurant.DAL.DTO.Images;
using IRestaurant.DAL.DTO.Restaurants;
using IRestaurant.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace IRestaurant.Test.ManagerUnitTests
{
    public class RestaurantManagerTest
    {
        private RestaurantManagerTestHelper helper = new RestaurantManagerTestHelper();

        [Fact]
        public async Task GetRestaurantOverviewList()
        {
            //Arrange
            var expectedRestaurantOverviewPagedList = helper.GetRestaurantOverviewPagedList();

            var userRepository = new Mock<IUserRepository>();
            var foodRepository = new Mock<IFoodRepository>();
            var httpContext = new Mock<IHttpContextAccessor>();
            var restaurantRepository = new Mock<IRestaurantRepository>();
            restaurantRepository.Setup(r => r.GetRestaurantOverviewList(It.IsAny<RestaurantSearchDto>()))
                .ReturnsAsync(expectedRestaurantOverviewPagedList);

            var manager = new RestaurantManager(restaurantRepository.Object, userRepository.Object, foodRepository.Object, httpContext.Object);

            //Act
            var restaurantOverviewPagedList = await manager.GetRestaurantOverviewList(new RestaurantSearchDto());

            //Assert
            Assert.Equal(expectedRestaurantOverviewPagedList, restaurantOverviewPagedList);
        }

        [Fact]
        public async Task GetRestaurantDetails_RestaurantAvailable()
        {
            //Arrange
            int restaurantId = 1;
            var expectedRestaurantDetails = helper.GetRestaurantDetailsDto();
            string userId = "475c5e32-049c-4d7b-a963-02ebdc15a94b";

            var userRepository = new Mock<IUserRepository>();
            var foodRepository = new Mock<IFoodRepository>();
            var restaurantRepository = new Mock<IRestaurantRepository>();
            restaurantRepository.Setup(r => r.IsRestaurantAvailableForUsers(restaurantId))
                .ReturnsAsync(true);
            restaurantRepository.Setup(r => r.GetRestaurantDetails(restaurantId))
                .ReturnsAsync(expectedRestaurantDetails);
            var httpContext = new Mock<IHttpContextAccessor>();
            httpContext.SetupGet(h => h.HttpContext.User)
                .Returns(helper.GetUserClaimPrinciple(userId));

            var manager = new RestaurantManager(restaurantRepository.Object, userRepository.Object, foodRepository.Object, httpContext.Object);

            //Act
            var restaurantDetails = await manager.GetRestaurantDetails(restaurantId);

            //Assert
            Assert.Equal(expectedRestaurantDetails, restaurantDetails);
        }

        [Fact]
        public async Task GetRestaurantDetails_RestaurantNotAvailable()
        {
            //Arrange
            int restaurantId = 1;
            string userId = "475c5e32-049c-4d7b-a963-02ebdc15a94b";

            var restaurantRepository = new Mock<IRestaurantRepository>();
            var userRepository = new Mock<IUserRepository>();
            var foodRepository = new Mock<IFoodRepository>();
            var httpContext = new Mock<IHttpContextAccessor>();
            httpContext.SetupGet(h => h.HttpContext.User)
                .Returns(helper.GetUserClaimPrinciple(userId));

            var manager = new RestaurantManager(restaurantRepository.Object, userRepository.Object, foodRepository.Object, httpContext.Object);

            //Act

            //Assert
            var exception = await Assert.ThrowsAsync<ProblemDetailsException>(
                async () => await manager.GetRestaurantDetails(restaurantId)
            );
            Assert.Equal(StatusCodes.Status400BadRequest, exception.Details.Status);
        }

        [Fact]
        public async Task GetRestaurantDetails_RestaurantNotAvailable_UserIsRestaurantOwner()
        {
            //Arrange
            int restaurantId = 1;
            var expectedRestaurantDetails = helper.GetRestaurantDetailsDto();
            string userId = "475c5e32-049c-4d7b-a963-02ebdc15a94b";

            var foodRepository = new Mock<IFoodRepository>();
            var restaurantRepository = new Mock<IRestaurantRepository>();
            restaurantRepository.Setup(r => r.IsRestaurantAvailableForUsers(restaurantId))
                .ReturnsAsync(false);
            restaurantRepository.Setup(r => r.GetRestaurantDetails(restaurantId))
                .ReturnsAsync(expectedRestaurantDetails);
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(u => u.UserHasRestaurant(userId))
                .ReturnsAsync(true);
            userRepository.Setup(u => u.GetMyRestaurantId(userId))
                .ReturnsAsync(restaurantId);
            var httpContext = new Mock<IHttpContextAccessor>();
            httpContext.SetupGet(h => h.HttpContext.User)
                .Returns(helper.GetUserClaimPrinciple(userId));

            var manager = new RestaurantManager(restaurantRepository.Object, userRepository.Object, foodRepository.Object, httpContext.Object);

            //Act
            var restaurantDetails = await manager.GetRestaurantDetails(restaurantId);

            //Assert
            Assert.Equal(expectedRestaurantDetails, restaurantDetails);
        }

        [Fact]
        public async Task GetMyRestaurant_RestaurantNotAvailable_UserIsRestaurantOwner()
        {
            //Arrange
            int restaurantId = 1;
            var expectedRestaurantDetails = helper.GetRestaurantDetailsDto();
            string userId = "475c5e32-049c-4d7b-a963-02ebdc15a94b";

            var foodRepository = new Mock<IFoodRepository>();
            var restaurantRepository = new Mock<IRestaurantRepository>();
            restaurantRepository.Setup(r => r.IsRestaurantAvailableForUsers(restaurantId))
                .ReturnsAsync(false);
            restaurantRepository.Setup(r => r.GetRestaurantDetails(restaurantId))
                .ReturnsAsync(expectedRestaurantDetails);
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(u => u.UserHasRestaurant(userId))
                .ReturnsAsync(true);
            userRepository.Setup(u => u.GetMyRestaurantId(userId))
                .ReturnsAsync(restaurantId);
            var httpContext = new Mock<IHttpContextAccessor>();
            httpContext.SetupGet(h => h.HttpContext.User)
                .Returns(helper.GetUserClaimPrinciple(userId));

            var manager = new RestaurantManager(restaurantRepository.Object, userRepository.Object, foodRepository.Object, httpContext.Object);

            //Act
            var restaurantDetails = await manager.GetMyRestaurantDetails();

            //Assert
            Assert.Equal(expectedRestaurantDetails, restaurantDetails);
        }

        [Fact]
        public async Task EditMyRestaurant_UserIsRestaurantOwner()
        {
            //Arrange
            int restaurantId = 1;
            var expectedRestaurantDetails = helper.GetRestaurantDetailsDto();
            string userId = "475c5e32-049c-4d7b-a963-02ebdc15a94b";

            var foodRepository = new Mock<IFoodRepository>();
            var restaurantRepository = new Mock<IRestaurantRepository>();
            restaurantRepository.Setup(r => r.EditRestaurant(restaurantId, It.IsAny<EditRestaurantDto>()))
                .ReturnsAsync(expectedRestaurantDetails);
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(u => u.GetMyRestaurantId(userId))
                .ReturnsAsync(restaurantId);
            var httpContext = new Mock<IHttpContextAccessor>();
            httpContext.SetupGet(h => h.HttpContext.User)
                .Returns(helper.GetUserClaimPrinciple(userId));

            var manager = new RestaurantManager(restaurantRepository.Object, userRepository.Object, foodRepository.Object, httpContext.Object);

            //Act
            var editedRestaurantDetails = await manager.EditMyRestaurant(new EditRestaurantDto());

            //Assert
            Assert.Equal(expectedRestaurantDetails, editedRestaurantDetails);
        }

        [Fact]
        public async Task UploadMyRestaurantImage_UserIsRestaurantOwner()
        {
            //Arrange
            int restaurantId = 1;
            string expectedRelativePath = "images/restaurant/test.jpg";
            string userId = "475c5e32-049c-4d7b-a963-02ebdc15a94b";

            var foodRepository = new Mock<IFoodRepository>();
            var restaurantRepository = new Mock<IRestaurantRepository>();
            restaurantRepository.Setup(r => r.UploadRestaurantImage(restaurantId, It.IsAny<UploadImageDto>()))
                .ReturnsAsync(expectedRelativePath);
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(u => u.GetMyRestaurantId(userId))
                .ReturnsAsync(restaurantId);
            var httpContext = new Mock<IHttpContextAccessor>();
            httpContext.SetupGet(h => h.HttpContext.User)
                .Returns(helper.GetUserClaimPrinciple(userId));

            var manager = new RestaurantManager(restaurantRepository.Object, userRepository.Object, foodRepository.Object, httpContext.Object);

            //Act
            var relativePath = await manager.UploadMyRestaurantImage(new UploadImageDto());

            //Assert
            Assert.Equal(expectedRelativePath, relativePath);
        }

        [Fact]
        public async Task DeleteMyRestaurantImage_UserIsRestaurantOwner()
        {
            //Arrange
            int restaurantId = 1;
            string userId = "475c5e32-049c-4d7b-a963-02ebdc15a94b";

            var foodRepository = new Mock<IFoodRepository>();
            var restaurantRepository = new Mock<IRestaurantRepository>();
            restaurantRepository.Setup(r => r.DeleteRestaurantImage(restaurantId))
                .Verifiable();
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(u => u.GetMyRestaurantId(userId))
                .ReturnsAsync(restaurantId);
            var httpContext = new Mock<IHttpContextAccessor>();
            httpContext.SetupGet(h => h.HttpContext.User)
                .Returns(helper.GetUserClaimPrinciple(userId));

            var manager = new RestaurantManager(restaurantRepository.Object, userRepository.Object, foodRepository.Object, httpContext.Object);

            //Act
            await manager.DeleteMyRestaurantImage();

            //Assert
            restaurantRepository.Verify();
        }

        [Fact]
        public async Task GetMyRestaurantSettings_UserIsRestaurantOwner()
        {
            //Arrange
            int restaurantId = 1;
            var expectedRestaurantSettings = helper.GetRestaurantSettings();
            string userId = "475c5e32-049c-4d7b-a963-02ebdc15a94b";

            var foodRepository = new Mock<IFoodRepository>();
            var restaurantRepository = new Mock<IRestaurantRepository>();
            restaurantRepository.Setup(r => r.GetRestaurantSettings(restaurantId))
                .ReturnsAsync(expectedRestaurantSettings);
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(u => u.GetMyRestaurantId(userId))
                .ReturnsAsync(restaurantId);
            var httpContext = new Mock<IHttpContextAccessor>();
            httpContext.SetupGet(h => h.HttpContext.User)
                .Returns(helper.GetUserClaimPrinciple(userId));

            var manager = new RestaurantManager(restaurantRepository.Object, userRepository.Object, foodRepository.Object, httpContext.Object);

            //Act
            var restaurantSettings = await manager.GetMyRestaurantSettings();

            //Assert
            Assert.Equal(expectedRestaurantSettings, restaurantSettings);
        }

        [Fact]
        public async Task ShowMyRestaurantForUsers_RestaurantDataIsValid_UserIsRestaurantOwner()
        {
            //Arrange
            int restaurantId = 1;
            var restaurantDetails = helper.GetRestaurantDetailsDto();
            string userId = "475c5e32-049c-4d7b-a963-02ebdc15a94b";

            var foodRepository = new Mock<IFoodRepository>();
            var restaurantRepository = new Mock<IRestaurantRepository>();
            restaurantRepository.Setup(r => r.GetRestaurantDetails(restaurantId))
                .ReturnsAsync(restaurantDetails);
            restaurantRepository.Setup(r => r.ChangeShowForUsersStatus(restaurantId, true))
                .Verifiable();
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(u => u.GetMyRestaurantId(userId))
                .ReturnsAsync(restaurantId);
            var httpContext = new Mock<IHttpContextAccessor>();
            httpContext.SetupGet(h => h.HttpContext.User)
                .Returns(helper.GetUserClaimPrinciple(userId));

            var manager = new RestaurantManager(restaurantRepository.Object, userRepository.Object, foodRepository.Object, httpContext.Object);

            //Act
            await manager.ShowMyRestaurantForUsers();

            //Assert
            restaurantRepository.Verify();
        }

        [Fact]
        public async Task ShowMyRestaurantForUsers_RestaurantNameIsNotValid_UserIsRestaurantOwner()
        {
            //Arrange
            int restaurantId = 1;
            var notValidRestaurantDetails = helper.GetRestaurantDetailsDto();
            notValidRestaurantDetails.Name = "";
            string userId = "475c5e32-049c-4d7b-a963-02ebdc15a94b";

            var foodRepository = new Mock<IFoodRepository>();
            var restaurantRepository = new Mock<IRestaurantRepository>();
            restaurantRepository.Setup(r => r.GetRestaurantDetails(restaurantId))
                .ReturnsAsync(notValidRestaurantDetails);
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(u => u.GetMyRestaurantId(userId))
                .ReturnsAsync(restaurantId);
            var httpContext = new Mock<IHttpContextAccessor>();
            httpContext.SetupGet(h => h.HttpContext.User)
                .Returns(helper.GetUserClaimPrinciple(userId));

            var manager = new RestaurantManager(restaurantRepository.Object, userRepository.Object, foodRepository.Object, httpContext.Object);

            //Act

            //Assert
            var exception = await Assert.ThrowsAsync<ProblemDetailsException>(
                async () => await manager.ShowMyRestaurantForUsers()
            );
            Assert.Equal(StatusCodes.Status400BadRequest, exception.Details.Status);
        }

        [Fact]
        public async Task HideMyRestaurantFromUsers_UserIsRestaurantOwner()
        {
            //Arrange
            int restaurantId = 1;
            string userId = "475c5e32-049c-4d7b-a963-02ebdc15a94b";

            var foodRepository = new Mock<IFoodRepository>();
            var restaurantRepository = new Mock<IRestaurantRepository>();
            restaurantRepository.Setup(r => r.ChangeShowForUsersStatus(restaurantId, false))
                .Verifiable();
            restaurantRepository.Setup(r => r.ChangeOrderAvailableStatus(restaurantId, false))
                .Verifiable();
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(u => u.GetMyRestaurantId(userId))
                .ReturnsAsync(restaurantId);
            var httpContext = new Mock<IHttpContextAccessor>();
            httpContext.SetupGet(h => h.HttpContext.User)
                .Returns(helper.GetUserClaimPrinciple(userId));

            var manager = new RestaurantManager(restaurantRepository.Object, userRepository.Object, foodRepository.Object, httpContext.Object);

            //Act
            await manager.HideMyRestaurantFromUsers();

            //Assert
            restaurantRepository.Verify();
        }

        [Fact]
        public async Task TurnOnMyRestaurantOrderStatus_RestaurantAvailable_HasFood_UserIsRestaurantOwner()
        {
            //Arrange
            int restaurantId = 1;
            string userId = "475c5e32-049c-4d7b-a963-02ebdc15a94b";
            var restaurantMenuWithOneFood = helper.GetRestaurantMenuWithOneFood();

            var foodRepository = new Mock<IFoodRepository>();
            foodRepository.Setup(f => f.GetRestaurantMenu(restaurantId))
                .ReturnsAsync(restaurantMenuWithOneFood);
            var restaurantRepository = new Mock<IRestaurantRepository>();
            restaurantRepository.Setup(r => r.IsRestaurantAvailableForUsers(restaurantId))
                .ReturnsAsync(true);
            restaurantRepository.Setup(r => r.ChangeOrderAvailableStatus(restaurantId, true))
                .Verifiable();
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(u => u.GetMyRestaurantId(userId))
                .ReturnsAsync(restaurantId);
            var httpContext = new Mock<IHttpContextAccessor>();
            httpContext.SetupGet(h => h.HttpContext.User)
                .Returns(helper.GetUserClaimPrinciple(userId));

            var manager = new RestaurantManager(restaurantRepository.Object, userRepository.Object, foodRepository.Object, httpContext.Object);

            //Act
            await manager.TurnOnMyRestaurantOrderOption();

            //Assert
            restaurantRepository.Verify();
        }

        [Fact]
        public async Task TurnOnMyRestaurantOrderStatus_RestaurantNotAvailable_HasFood_UserIsRestaurantOwner()
        {
            //Arrange
            int restaurantId = 1;
            string userId = "475c5e32-049c-4d7b-a963-02ebdc15a94b";
            var restaurantMenuWithOneFood = helper.GetRestaurantMenuWithOneFood();

            var foodRepository = new Mock<IFoodRepository>();
            foodRepository.Setup(f => f.GetRestaurantMenu(restaurantId))
                .ReturnsAsync(restaurantMenuWithOneFood);
            var restaurantRepository = new Mock<IRestaurantRepository>();
            restaurantRepository.Setup(r => r.IsRestaurantAvailableForUsers(restaurantId))
                .ReturnsAsync(false);
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(u => u.GetMyRestaurantId(userId))
                .ReturnsAsync(restaurantId);
            var httpContext = new Mock<IHttpContextAccessor>();
            httpContext.SetupGet(h => h.HttpContext.User)
                .Returns(helper.GetUserClaimPrinciple(userId));

            var manager = new RestaurantManager(restaurantRepository.Object, userRepository.Object, foodRepository.Object, httpContext.Object);

            //Act

            //Assert
            var exception = await Assert.ThrowsAsync<ProblemDetailsException>(
                async () => await manager.TurnOnMyRestaurantOrderOption()
            );
            Assert.Equal(StatusCodes.Status400BadRequest, exception.Details.Status);
        }

        [Fact]
        public async Task TurnOnMyRestaurantOrderStatus_RestaurantAvailable_NotHaveFood_UserIsRestaurantOwner()
        {
            //Arrange
            int restaurantId = 1;
            string userId = "475c5e32-049c-4d7b-a963-02ebdc15a94b";
            var emptyRestaurantMenu = new List<FoodDto>();

            var foodRepository = new Mock<IFoodRepository>();
            foodRepository.Setup(f => f.GetRestaurantMenu(restaurantId))
                .ReturnsAsync(emptyRestaurantMenu);
            var restaurantRepository = new Mock<IRestaurantRepository>();
            restaurantRepository.Setup(r => r.IsRestaurantAvailableForUsers(restaurantId))
                .ReturnsAsync(true);
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(u => u.GetMyRestaurantId(userId))
                .ReturnsAsync(restaurantId);
            var httpContext = new Mock<IHttpContextAccessor>();
            httpContext.SetupGet(h => h.HttpContext.User)
                .Returns(helper.GetUserClaimPrinciple(userId));

            var manager = new RestaurantManager(restaurantRepository.Object, userRepository.Object, foodRepository.Object, httpContext.Object);

            //Act

            //Assert
            var exception = await Assert.ThrowsAsync<ProblemDetailsException>(
                async () => await manager.TurnOnMyRestaurantOrderOption()
            );
            Assert.Equal(StatusCodes.Status400BadRequest, exception.Details.Status);
        }

        [Fact]
        public async Task TurnOffMyRestaurantOrderStatus_UserIsRestaurantOwner()
        {
            //Arrange
            int restaurantId = 1;
            string userId = "475c5e32-049c-4d7b-a963-02ebdc15a94b";

            var foodRepository = new Mock<IFoodRepository>();
            var restaurantRepository = new Mock<IRestaurantRepository>();
            restaurantRepository.Setup(r => r.ChangeOrderAvailableStatus(restaurantId, false))
                .Verifiable();
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(u => u.GetMyRestaurantId(userId))
                .ReturnsAsync(restaurantId);
            var httpContext = new Mock<IHttpContextAccessor>();
            httpContext.SetupGet(h => h.HttpContext.User)
                .Returns(helper.GetUserClaimPrinciple(userId));

            var manager = new RestaurantManager(restaurantRepository.Object, userRepository.Object, foodRepository.Object, httpContext.Object);

            //Act
            await manager.TurnOffMyRestaurantOrderOption();

            //Assert
            restaurantRepository.Verify();
        }

        [Fact]
        public async Task GetUserFavouriteRestaurantList()
        {
            //Arrange
            string userId = "475c5e32-049c-4d7b-a963-02ebdc15a94b";
            var expectedRestaurantOverviewPagedList = helper.GetRestaurantOverviewPagedList();

            var userRepository = new Mock<IUserRepository>();
            var foodRepository = new Mock<IFoodRepository>();
            var restaurantRepository = new Mock<IRestaurantRepository>();
            restaurantRepository.Setup(r => r.GetGuestFavouriteRestaurantList(userId, It.IsAny<RestaurantSearchDto>()))
                .ReturnsAsync(expectedRestaurantOverviewPagedList);
            var httpContext = new Mock<IHttpContextAccessor>();
            httpContext.SetupGet(h => h.HttpContext.User)
               .Returns(helper.GetUserClaimPrinciple(userId));

            var manager = new RestaurantManager(restaurantRepository.Object, userRepository.Object, foodRepository.Object, httpContext.Object);

            //Act
            var restaurantOverviewPagedList = await manager.GetGuestFavouriteRestaurantList(new RestaurantSearchDto());

            //Assert
            Assert.Equal(expectedRestaurantOverviewPagedList, restaurantOverviewPagedList);
        }

        [Fact]
        public async Task AddRestaurantToGuestFavourite()
        {
            //Arrange
            int restaurantId = 1;
            string userId = "475c5e32-049c-4d7b-a963-02ebdc15a94b";

            var foodRepository = new Mock<IFoodRepository>();
            var userRepository = new Mock<IUserRepository>();
            var httpContext = new Mock<IHttpContextAccessor>();
            var restaurantRepository = new Mock<IRestaurantRepository>();
            restaurantRepository.Setup(r => r.AddRestaurantToGuestFavourite(restaurantId, userId))
                .Verifiable();
            httpContext.SetupGet(h => h.HttpContext.User)
                .Returns(helper.GetUserClaimPrinciple(userId));

            var manager = new RestaurantManager(restaurantRepository.Object, userRepository.Object, foodRepository.Object, httpContext.Object);

            //Act
            await manager.AddRestaurantToGuestFavourite(restaurantId);

            //Assert
            restaurantRepository.Verify();
        }

        [Fact]
        public async Task RemoveRestaurantFromGuestFavourite()
        {
            //Arrange
            int restaurantId = 1;
            string userId = "475c5e32-049c-4d7b-a963-02ebdc15a94b";

            var foodRepository = new Mock<IFoodRepository>();
            var userRepository = new Mock<IUserRepository>();
            var httpContext = new Mock<IHttpContextAccessor>();
            var restaurantRepository = new Mock<IRestaurantRepository>();
            restaurantRepository.Setup(r => r.RemoveRestaurantFromGuestFavourite(restaurantId, userId))
                .Verifiable();
            httpContext.SetupGet(h => h.HttpContext.User)
                .Returns(helper.GetUserClaimPrinciple(userId));

            var manager = new RestaurantManager(restaurantRepository.Object, userRepository.Object, foodRepository.Object, httpContext.Object);

            //Act
            await manager.RemoveRestaurantFromGuestFavourite(restaurantId);

            //Assert
            restaurantRepository.Verify();
        } 
    }
}
