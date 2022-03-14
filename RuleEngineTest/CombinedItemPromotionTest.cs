using RuleEngine;
using RuleEngine.Cart;
using RuleEngine.Inventory;
using RuleEngine.Promotion;
using RuleEngine.SKU;
using System;
using System.Collections.Generic;
using Xunit;

namespace RuleEngineTest
{
    public class CombinedItemPromotionTest
    {

        [Fact]
        public void TestApplyPromotion_WithCombinedItemPromotion_ReturnApplyPromotionPrice()
        {
            string inputPromo = "C D for 30";
            var inventory = new Inventory();
            var cartItem = new CartItem();
            cartItem.IsPromotionApplied = false;
            cartItem.Item = new SKUItem("C", 20);
            cartItem.TotalPrice = 20;

            var cartItem1 = new CartItem();
            cartItem1.IsPromotionApplied = false;
            cartItem1.Item = new SKUItem("D", 15);
            cartItem1.TotalPrice = 15;

            inventory.AddSKUitem(new SKUItem("C", 20));
            inventory.AddSKUitem(new SKUItem("D", 15));

            inventory.AddPromotion(inputPromo);

            inventory.AddItemToCart("C");
            inventory.AddItemToCart("D");

            Assert.Equal(Convert.ToDecimal(35), inventory._cart.TotalPrice());

           
            inventory.Checkout();

            Assert.Equal(Convert.ToDecimal(30), inventory._cart.TotalPrice());

        }

        [Fact]
        public void TestApplyPromotion_WithCombinedItemPromotionSenarioWithDiffFormat_ReturnApplyPromotionPrice()
        {
            string inputPromo = "C & D for 30";
            var inventory = new Inventory();
            var cartItem = new CartItem();
            cartItem.IsPromotionApplied = false;
            cartItem.Item = new SKUItem("C", 20);
            cartItem.TotalPrice = 20;

            var cartItem1 = new CartItem();
            cartItem1.IsPromotionApplied = false;
            cartItem1.Item = new SKUItem("D", 15);
            cartItem1.TotalPrice = 15;

            inventory.AddSKUitem(new SKUItem("C", 20));
            inventory.AddSKUitem(new SKUItem("D", 15));

            inventory.AddPromotion(inputPromo);

            inventory.AddItemToCart("C");
            inventory.AddItemToCart("D");

            Assert.Equal(Convert.ToDecimal(35), inventory._cart.TotalPrice());


            inventory.Checkout();

            Assert.Equal(Convert.ToDecimal(30), inventory._cart.TotalPrice());

        }

        [Fact]
        public void TestApplyPromotion_WithCombinedItemPromotionWithFixedPriceZero_ThrowPromotionRuleEngineException()
        {
           
            var inventory = new Inventory();
            var cartItem = new CartItem();
            cartItem.IsPromotionApplied = true;
            cartItem.Item = new SKUItem("C", 20);
            cartItem.TotalPrice = 0;

            var cartItem2 = new CartItem();
            cartItem2.IsPromotionApplied = false;
            cartItem2.Item = new SKUItem("D", 15);
            cartItem2.TotalPrice = 15;

            CombinedItemPromotion combinePromotion = new CombinedItemPromotion(new List<string> { "C", "D" }, 0);
            var cart = new Cart() { cartItems = { cartItem } };
            inventory.AddSKUitem(new SKUItem("C", 20));
            inventory.AddSKUitem(new SKUItem("D", 15));
            inventory.AddItemToCart("C");
            inventory.AddItemToCart("D");

            Assert.Throws<PromotionRuleEngineException>(()=> combinePromotion.ApplyPromotion(cart));

        }
    }
}
