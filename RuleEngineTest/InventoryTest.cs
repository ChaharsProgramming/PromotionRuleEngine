using Moq;
using RuleEngine.Cart;
using RuleEngine.Inventory;
using RuleEngine.SKU;
using System;
using Xunit;

namespace RuleEngineTest
{
    public class InventoryTest
    {
        private readonly Inventory _inventory;
        private readonly Mock<ICart> mockCart;
        public InventoryTest()
        {
            mockCart = new Mock<ICart>();
            _inventory = new Inventory(mockCart.Object);
        }

        [Fact]
        public void TestAddItemToCart_withValidInput_ReturnInventory()
        {
            Assert.Throws<NotImplementedException>(() => _inventory.AddItemToCart(""));
        }

        [Fact]
        public void TestAddSKUitem_withValidInput_ReturnInventory()
        {
            Assert.Throws<NotImplementedException>(() => _inventory.AddSKUitem(new SKUItem()));
        }

        [Fact]
        public void TestGetCart_withValidItem_ReturnCart()
        {
            Assert.Throws<NotImplementedException>(() => _inventory.GetCart());
        }

        [Fact]
        public void TestGetSKUItem_withValidSKUItem_ReturnSKUItem()
        {
            Assert.Throws<NotImplementedException>(() => _inventory.GetSKUItem(""));
        }
    }
}
