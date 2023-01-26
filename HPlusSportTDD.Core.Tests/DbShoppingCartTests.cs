using HPlusSportTDD.Core.Tests;
using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPlusSportTDD.Core
{
    internal class DbShoppingCartTests
    {
        

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void ShouldReturnArticlesInCart()
        {
           
            var initialItems = new AddToCartItem[]{
                //new AddToCartItem []
                //{
                //    //ArticleId = 42,
                //    //Quantity = 5
                //}
        };

            //var mockContext = new Mock<ShoppingCartContext>();
            //mockContext.Setup(ctx => ctx.Items().ReturnsDbSet(initialItems));

            var mockManager = new Mock<IShoppingCartManager>();
            mockManager.Setup(manager => manager.AddToCart(
                It.IsAny<AddToCartRequest>())).Returns(
                (AddToCartRequest request) => new AddToCartResponse()
                {
                    Items = new AddToCartItem[] { request.Item }
                }
                );

            // var manager = new ShoppingCartManager();

            //AddToCartResponse response = mockManager.Object.AddToCart(request);

            //Assert.IsNotNull(response);
            //Assert.Contains(item, response.Items);

        }

       


    }
}

