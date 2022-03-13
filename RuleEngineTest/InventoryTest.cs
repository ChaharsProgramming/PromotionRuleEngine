using RuleEngine.Inventory;
using RuleEngine.SKU;
using System;
using Xunit;

namespace RuleEngineTest
{
    public class InventoryTest
    {
        private readonly Inventory _inventory;
        public InventoryTest()
        {
            _inventory = new Inventory();
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
