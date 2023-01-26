namespace HPlusSportTDD.Core
{
    public class AddToCartRequest
    {
        public AddToCartRequest()
        {
        }

        public AddToCartItem Item { get; internal set; }
        public List<AddToCartItem> Items { get; internal set; }
    }
}