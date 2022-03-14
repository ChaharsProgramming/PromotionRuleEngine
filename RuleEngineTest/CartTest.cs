using RuleEngine.Cart;
using RuleEngine.SKU;
using Xunit;

namespace RuleEngineTest
{
    public class CartTest
    {
        private readonly Cart _cart;
        public CartTest()
        {
            _cart = new Cart();
        }

        [Fact]
        public void TestAddCart_withValidSKUItem_ReturnSKUId()
        {
            var result = _cart.AddItem(new SKUItem("dummy", 1));
            Assert.NotNull(_cart);
            Assert.Equal("dummy", result);
        }

        [Fact]
        public void TestRemoveCart_withValidSKUItem_ReturnSKUId()
        {
            var result=  _cart.RemoveItem("dummy");
            Assert.Equal("dummy", result);
        }

        [Fact]
        public void TestTotalPrice_withValidSKUItem_ReturnSKUId()
        {
            _cart.AddItem(new SKUItem("dummy1", 1));
            _cart.AddItem(new SKUItem("dummy2", 2));
            _cart.AddItem(new SKUItem("dummy3", 3));
            Assert.Equal(3, _cart.cartItems.Count);

            var totalprice = _cart.TotalPrice();
            Assert.Equal(6,totalprice);

        }
    }
}
