//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Xunit;
//using Moq;
//using MyExpenseTracker.Services;
//using MyExpenseTracker.Models;
//using MyExpenseTracker.Repositories;

//namespace my_expense_tracker.Tests
//{
//    public class UserServiceTests
//    {
//        private readonly Mock<IUserRepository> _userRepositoryMock;
//        private readonly UserService _userService;

//        public UserServiceTests()
//        {
//            _userRepositoryMock = new Mock<IUserRepository>();
//            _userService = new UserService(_userRepositoryMock.Object);
//        }

//        [Fact]
//        public void RegisterUser_ShouldAddUser_WhenUserIsValid()
//        {
//            // Arrange
//            var user = new User { Username = "testuser", PasswordHash = "hashedpassword", Email = "test@example.com" };
//            _userRepositoryMock.Setup(repo => repo.AddUser(user)).Returns(user);

//            // Act
//            var result = _userService.RegisterUser(user);

//            // Assert
//            Assert.NotNull(result);
//            Assert.Equal(user.Username, result.Username);
//            _userRepositoryMock.Verify(repo => repo.AddUser(user), Times.Once);
//        }

//        [Fact]
//        public void ValidateUser_ShouldReturnUser_WhenCredentialsAreValid()
//        {
//            // Arrange
//            var user = new User { Username = "testuser", PasswordHash = "hashedpassword" };
//            _userRepositoryMock.Setup(repo => repo.FindUserById(user.Username)).Returns(user);

//            // Act
//            var result = _userService.ValidateUser("testuser", "hashedpassword");

//            // Assert
//            Assert.NotNull(result);
//            Assert.Equal(user.Username, result.Username);
//        }

//        [Fact]
//        public void ValidateUser_ShouldReturnNull_WhenCredentialsAreInvalid()
//        {
//            // Arrange
//            _userRepositoryMock.Setup(repo => repo.FindUserById(It.IsAny<string>())).Returns((User)null);

//            // Act
//            var result = _userService.ValidateUser("invaliduser", "wrongpassword");

//            // Assert
//            Assert.Null(result);
//        }
//    }
//}