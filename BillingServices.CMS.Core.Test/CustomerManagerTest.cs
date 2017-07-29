using System;
using Xunit;
using BillingServices.CMS.Core;
using BillingServices.CMS.Core.Interfaces;
using BillingServices.CMS.Core.Model;
using Moq;


namespace BillingServices.CMS.Core.Test
{
    public class CustomerManagerTest
    {
        [Fact]
        public void TestCustomerReturnsCustomerIfFound()
        {
            //Arrange
            Mock<IRespository> mockRepo = new Mock<IRespository>();
            string expectedId = "5";
            Customer Expectedcustomer = new Customer {Id = expectedId, FirstName = "Mark", LastName = "Anderson" };
            mockRepo.Setup(x => x.GetById(expectedId)).Returns(Expectedcustomer);

            //Act
            CustomerManager cm = new CustomerManager(mockRepo.Object);

            //Assert
            Assert.Equal(cm.findByCustomerId(expectedId), Expectedcustomer);

        }

        [Fact]
        public void TestCustomerReturnsCustomerNullIfNotFound()
        {
            //Arrange
            Mock<IRespository> mockRepo = new Mock<IRespository>();
            string StoredId = "5";
            string ParamId = "4";
            Customer Expectedcustomer = new Customer { Id = StoredId, FirstName = "Mark", LastName = "Anderson" };
            mockRepo.Setup(x => x.GetById(StoredId)).Returns(Expectedcustomer);
            CustomerManager cm = new CustomerManager(mockRepo.Object);
            //Act
            //Assert
            Assert.Equal(cm.findByCustomerId(ParamId), null);

        }

        [Fact]
        public void ReturnsValueOnAdd()
        {
            Mock<IRespository> mockRepo = new Mock<IRespository>();
            mockRepo.Setup(x => x.Add(It.IsAny<Customer>())).Returns("anyid");

            CustomerManager cm = new CustomerManager(mockRepo.Object);

            Assert.NotNull(cm.Add(It.IsAny<Customer>()));

        }


    }
}
