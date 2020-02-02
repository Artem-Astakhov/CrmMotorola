using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrmBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBL.Model.Tests
{
    [TestClass()]
    public class CartTests
    {
        [TestMethod()]
        public void CartTest()
        {
            //arrange
            var customer = new Customer()
            {
                CustomerId = 1,
                Name = "test"
            };
            var product = new Product()
            {
                ProductId = 1,
                Name = "pr1",
                Price = 100,
                Count = 1,
                Color = "White"
            };

            var product1 = new Product()
            {
                ProductId = 2,
                Name = "pr2",
                Price = 10,
                Count = 10,
                Color = "Black"
            };

            var cart = new Cart(customer);
            

            var expectedResult = new List<Product>()
            {
                product1, product
            };

            //act
            
            cart.Add(product1);
            cart.Add(product);

            var cartResult = cart.GetAll();

            //assert

            Assert.AreEqual(expectedResult.Count, cartResult.Count);
            for (int i =0; i< expectedResult.Count; i++) 
            {
                Assert.AreEqual(expectedResult[i], cartResult[i]);
            }
        }

        
    }
}