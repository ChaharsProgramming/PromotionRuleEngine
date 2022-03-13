using RuleEngine.Cart;
using RuleEngine.Inventory;
using RuleEngine.Promotion;
using RuleEngine.SKU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RuleEngineTest
{
    public class CombinedItemPromotionTest
    {

        [Fact]
        public void TestApplyPromotion_WithValidInput_ReturnApplyPromotionSuceess()
        {
            var inventory = new Inventory();
            var cartItem = new CartItem();
            cartItem.IsPromotionApplied = true;
            cartItem.Item = new SKUItem("C", 20);
            cartItem.TotalPrice = 150;

            var cartItem2 = new CartItem();
            cartItem2.IsPromotionApplied = true;
            cartItem2.Item = new SKUItem("D", 15);
            cartItem2.TotalPrice = 150;

            CombinedItemPromotion pr1 = new CombinedItemPromotion(new List<string> { "C", "D" }, 30);
            //List<PromotionBase> promotions = new() { pr1 };
            var cart = new Cart() { cartItems = { cartItem } };
            inventory.AddItemToCart("C");
            inventory.AddItemToCart("D");


            Assert.Equal(Convert.ToDecimal(100), inventory._cart.TotalPrice());
            //_Cart.Setup(crt => crt.AddItem(new SKUItem("A", 50))).Returns("1");
            //_inventory.Setup(inv => inv.AddItemToCart("A")).Returns(new Inventory()
            //{ skuItems = { new SKUItem("A", 50) }, promotions = promotions, _cart = cart });
            pr1.ApplyPromotion(cart);

            Assert.Equal(Convert.ToDecimal(50), inventory._cart.TotalPrice());

        }
    }
}
