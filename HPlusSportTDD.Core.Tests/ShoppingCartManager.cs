using HPlusSportTDD.Core.Tests;

namespace HPlusSportTDD.Core
{
    public class ShoppingCartManager : IShoppingCartManager
    {
        private List<AddToCartItem> _items;
        public ShoppingCartManager()
        {
            _items = new List<AddToCartItem>();
        }

        public AddToCartResponse AddToCart(AddToCartRequest request)
        {

            _items.Add(request.Item);

            return new AddToCartResponse()
            {
                Items = _items.ToArray(),

            };
        }

        public AddToCartResponse addToCart(AddToCartResponse request)
        {
            _items.Add(request.Item);
            return new AddToCartResponse() { Item= request.Item };
        }

        //public AddToCartResponse addToCart(AddToCartResponse request)
        //{
        //    _items.Add(request.Item);

        //    return new AddToCartResponse()
        //    {
        //        Items = _items.ToArray(),

        //    };
        //}

        public AddToCartItem[] GetCart()
        {
           return _items.ToArray();
        }   
    }
}


