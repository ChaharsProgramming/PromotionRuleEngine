using Moq;
using RuleEngine.Cart;
using RuleEngine.Inventory;
using RuleEngine.SKU;
using System;
using System.Collections.Generic;
using Xunit;

namespace RuleEngineTest
{
    public class InventoryTest
    {
        private readonly Inventory _inventory;
        private readonly Mock<ICart> _mockCart;
        public InventoryTest()
        {
            _mockCart = new Mock<ICart>();
            _inventory = new Inventory();

            //arrange
            _inventory.AddSKUitem(new SKUItem("A", 50));
            _inventory.AddSKUitem(new SKUItem("B", 30));
            _inventory.AddSKUitem(new SKUItem("C", 20));
            _inventory.AddSKUitem(new SKUItem("D", 15));
        }

        [Fact]
        public void TestAddItemToCart_withValidInput_ReturnInventory()
        {
            var result = _inventory.AddItemToCart("A");
           
            Assert.Equal(1, result._cart.cartItems.Count);
        }

        [Fact]
        public void TestGetCart_withValidItem_ReturnCart()
        {
            _inventory.AddItemToCart("A");
            _mockCart.Setup(crt => crt.IsItemExist("A")).Returns(true);
            //arrange
            var result = _inventory.GetCart();
            //assert
            
            Assert.True(result.IsItemExist("A"));
        }

        [Fact]
        public void TestGetSKUItem_withValidSKUItem_ReturnSKUItem()
        {
            //act
            var result = _inventory.GetSKUItem("A");

            //Assert
            Assert.Equal("A", result._id);
            Assert.Equal(50, result._itemPrice);
        }

        [Fact]
        public void TestAddIndividualPromotion()
        {
            Assert.Throws<NotImplementedException>(() => _inventory.AddIndividualPromotion(null));
        }

        [Fact]
        public void TestAddBulkPromotion()
        {
            Assert.Throws<NotImplementedException>(() => _inventory.AddBulkPromotion(null));
        }
    }
}
