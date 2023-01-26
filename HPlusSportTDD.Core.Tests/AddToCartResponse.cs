namespace HPlusSportTDD.Core
{
    public  class AddToCartResponse
    {
        public AddToCartItem[]? Items { get; set; }
        public AddToCartItem Item { get; internal set; }
    }
}