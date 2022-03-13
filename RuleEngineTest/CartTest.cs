using RuleEngine.Cart;
using RuleEngine.SKU;
using System;
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
            Assert.Throws<NotImplementedException>(() => _cart.AddItem(new SKUItem()));
        }

        [Fact]
        public void TestRemoveCart_withValidSKUItem_ReturnSKUId()
        {
            Assert.Throws<NotImplementedException>(() => _cart.RemoveItem(new SKUItem()));
        }
    }
}
