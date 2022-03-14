using RuleEngine;
using RuleEngine.Cart;
using RuleEngine.Inventory;
using RuleEngine.Promotion;
using RuleEngine.SKU;
using System;
using Xunit;

namespace RuleEngineTest
{
    public class IndividualItemPromotionTest
    {
        [Fact]
        public void TestApplyPromotion_WithIndividualItemPromotino_ReturnExpectedReducedPrice()
        {
            string inputPromo = "3 A for 130";
            var inventory = new Inventory();
            var cartItem = new CartItem(); 
            cartItem.IsPromotionApplied = false;
            cartItem.Item = new SKUItem("A", 50);
            cartItem.TotalPrice = 50;

            //var cart = new Cart() { cartItems = { cartItem, cartItem, cartItem } };
            inventory.AddSKUitem(new SKUItem("A", 50));
            inventory.AddSKUitem(new SKUItem("A", 50));
            inventory.AddSKUitem(new SKUItem("A", 50));

            inventory.AddItemToCart("A");
            inventory.AddItemToCart("A");
            inventory.AddItemToCart("A");
            


            Assert.Equal(Convert.ToDecimal(150), inventory._cart.TotalPrice());

            inventory.AddPromotion(inputPromo);
            inventory.Checkout();

            Assert.Equal(Convert.ToDecimal(130), inventory._cart.TotalPrice());
           
        }


        [Fact]
        public void TestApplyPromotion_WithIndividualItemPromotionWithFixedPriceZero_ThrowsPromotionRuleEngineException()
        {
            var inventory = new Inventory();
            var cartItem = new CartItem();
            cartItem.IsPromotionApplied = false;
            cartItem.Item = new SKUItem("A", 50);
            cartItem.TotalPrice = 50;

            IndividualItemPromotion individualPromotion = new("A", 0, 3);
            var cart = new Cart() { cartItems = { cartItem, cartItem, cartItem } };
            inventory.AddSKUitem(new SKUItem("A", 50));
            inventory.AddSKUitem(new SKUItem("A", 50));
            inventory.AddSKUitem(new SKUItem("A", 50));

            inventory.AddItemToCart("A");
            inventory.AddItemToCart("A");
            inventory.AddItemToCart("A");

            Assert.Throws<PromotionRuleEngineException>(() => individualPromotion.ApplyPromotion(cart));

        }
    }
}
