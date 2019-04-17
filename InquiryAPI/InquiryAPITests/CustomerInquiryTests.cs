using Domain.Interfaces;
using Domain.Models;
using InquiryAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace InquiryAPITests
{
    public class CustomerInquiryTests
    {
        [Fact]
        public async Task GetCustomer_Success()
        {
            // Arrange
            var mockRepo = new Mock<ICustomersRepository>();            
            var CustomerID = 1234567898;
            var customer = new Customer()
            {
                CustomerID = 1234567898,
                CustomerName = "John Smith",
                Email = "john.smith@mail.com",
                MobileNumber = 1234567890,
                Transactions = new List<Transaction>()
                    {
                        new Transaction()
                        {
                            Amount = 200,
                            CurrencyCode = Enums.CurrencyCode.USD,
                            Status = Enums.TransactionStatus.Success
                        }                       
                    }
            };
            mockRepo.Setup(repo => repo.GetCustomersTransactionsAsync(It.Is<CustomerInquiryRequest>(r => r.CustomerID == CustomerID)))
                .ReturnsAsync(customer);
            var controller = SetupController(mockRepo);

            // Act
            var result = await controller.Get(CustomerID, null);
            bool isOk = result.Result is OkObjectResult;

            // Assert
            Assert.True(isOk);
            var convertedResult = (OkObjectResult)result.Result;
            Assert.True(convertedResult.StatusCode == 200);
            Assert.Equal(convertedResult.Value, customer);
        }

        [Fact]
        public async Task GetCustomer_NotFound()
        {
            // Arrange
            var mockRepo = new Mock<ICustomersRepository>();
            var controller = SetupController(mockRepo); ;

            // Act
            var result = await controller.Get(null, "test@mail.com");
            bool isNotFound = result.Result is NotFoundResult;

            // Assert
            Assert.True(isNotFound);
            var convertedResult = (NotFoundResult)result.Result;
            Assert.True(convertedResult.StatusCode == 404);
        }


        [Fact]
        public async Task GetCustomer_InvalidQuery()
        {
            // Arrange
            var mockRepo = new Mock<ICustomersRepository>();
            var controller = SetupController(mockRepo); ;

            // Act
            var result = await controller.Get(null, null);
            bool isBadRequest = result.Result is BadRequestObjectResult;

            // Assert
            Assert.True(isBadRequest);
            var convertedResult = (BadRequestObjectResult)result.Result;
            Assert.True(convertedResult.StatusCode == 400);
        }

        private CustomerInquiryController SetupController(Mock<ICustomersRepository> mock)
        {
            var objectValidator = new Mock<IObjectModelValidator>();
            objectValidator.Setup(o => o.Validate(It.IsAny<ActionContext>(),
                                              It.IsAny<ValidationStateDictionary>(),
                                              It.IsAny<string>(),
                                              It.IsAny<CustomerInquiryRequest>()));
            var controller = new CustomerInquiryController(mock.Object);
            controller.ObjectValidator = objectValidator.Object;
            return controller;
        }

    }
}
