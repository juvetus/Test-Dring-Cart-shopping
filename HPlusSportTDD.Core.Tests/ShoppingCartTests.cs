using HPlusSportTDD.Core.Tests;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPlusSportTDD.Core
{
    internal class ShoppingCartTests
    {
        [SetUp] 
        public void SetUp()
        {

        }

        [Test]
        public void ShouldReturnArticleAddedToTheCart()
        {
            var item = new AddToCartItem()
            {
                ArticleId = 42,
                Quantity = 5
            };

            var request = new AddToCartRequest()
            {
                Item = item
            };

            var mockManager = new Mock<IShoppingCartManager>();
            mockManager.Setup(manager => manager.AddToCart(
                It.IsAny<AddToCartRequest>())).Returns(
                (AddToCartRequest request) => new AddToCartResponse()
                {
                    Items = new AddToCartItem[] { item } 
                }
                );
               
           // var manager = new ShoppingCartManager();

            AddToCartResponse  response  =  mockManager.Object.AddToCart(request);

            Assert.IsNotNull(response);
            Assert.Contains(item, response.Items);
           
        }

        [Test]
        public void ShouldReturnArticlesAddedToTheCart()
        {
            var item1 = new AddToCartItem()
            {
                ArticleId = 42,
                Quantity = 5
            };

            var request = new AddToCartRequest()
            {
                Item = item1
            };
            var manager = new ShoppingCartManager();

            AddToCartResponse response = manager.AddToCart(request);

            var item2 = new AddToCartItem()
            {
                ArticleId = 43,
                Quantity = 15
            };

             request = new AddToCartRequest()
            {
                Item = item2
            };
            response = manager.AddToCart(request);

            Assert.IsNotNull(response);
            Assert.Contains(item1, response.Items);
           Assert.Contains(item2, response.Items);

        }

        [Test]
        public void ShouldReturnCombineArticlesAddedToTheCart()
        {
            var item1 = new AddToCartItem()
            {
                ArticleId = 42,
                Quantity = 5
            };

            var request = new AddToCartRequest()
            {
                Item = item1
            };
            var manager = new ShoppingCartManager();

            AddToCartResponse response = manager.AddToCart(request);

            var item2 = new AddToCartItem()
            {
                ArticleId = 42,
                Quantity = 15
            };

            request = new AddToCartRequest()
            {
                Item = item2
            };
            response = manager.AddToCart(request);

            Assert.IsNotNull(response);
            Assert.That(Array.Exists(response.Items, item => item.ArticleId == 42 && item.Quantity== 15));

        }


        [Test]
        public void ShouldReturnAdditionalArticleAddedToTheCart()
        {
            var item1 = new AddToCartItem()
            {
                ArticleId = 42,
                Quantity = 5
            };

            var request = new AddToCartRequest()
            {
                Item = item1
            };
            var manager = new ShoppingCartManager();

            AddToCartResponse response = manager.AddToCart(request);

            var item2 = new AddToCartItem()
            {
                ArticleId = 43,
                Quantity = 15
            };

            request = new AddToCartRequest()
            {
                Item = item2
            };
            response = manager.AddToCart(request);

            var item3 = new AddToCartItem()
            {
                ArticleId = 44,
                Quantity = 10
            };

            request = new AddToCartRequest()
            {
                Item = item3
            };
            response = manager.AddToCart(request);

            Assert.IsNotNull(response);
            Assert.Contains(item1, response.Items);
            Assert.Contains(item2, response.Items);
            Assert.Contains(item3, response.Items);
        }


        [Test]
        public void ShouldReturnMultipleArticlesOfSameTypessAddedToTheCart()
        {
            var item = new AddToCartItem()
            {
                ArticleId = 42,
                Quantity = 5
            };

            var request = new AddToCartRequest()
            {
                Item = item
            };
            var manager = new ShoppingCartManager();

            AddToCartResponse response = manager.AddToCart(request);

            // Finding the existing article and updating the quantity
            var existingItem = response.Items.FirstOrDefault(x => x.ArticleId == 42);
            existingItem.Quantity += 10;

            request.Item = existingItem;
            response = manager.AddToCart(request);

            existingItem = response.Items.FirstOrDefault(x => x.ArticleId == 42);
            existingItem.Quantity += 15;

            request.Item = existingItem;
            response = manager.AddToCart(request);

            Assert.IsNotNull(response);
            Assert.Contains(existingItem, response.Items);
            Assert.AreEqual(30, response.Items.FirstOrDefault(x => x.ArticleId == 42).Quantity);
        }


    }
}
