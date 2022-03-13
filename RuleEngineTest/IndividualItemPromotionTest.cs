using Moq;
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
    public class IndividualItemPromotionTest
    {
        //private readonly Inventory _inventory;
        //private readonly Cart _inventory;

        public IndividualItemPromotionTest()
        {
            //_Cart = new Mock<ICart>();
            //_inventory = new Mock<IInventory>();

        }
        [Fact]
        public void TestApplyPromotion_WithValidInput_ReturnApplyPromotionSuceess()
        {
            var inventory = new Inventory();
            var cartItem = new CartItem(); 
            cartItem.IsPromotionApplied = false;
            cartItem.Item = new SKUItem("A", 50);
            cartItem.TotalPrice = 50;

            IndividualItemPromotion pr1 = new("A", 130, 3);
            //List<PromotionBase> promotions = new() { pr1 };
            var cart = new Cart() { cartItems = { cartItem, cartItem, cartItem } };
            inventory.AddSKUitem(new SKUItem("A", 50));
            inventory.AddSKUitem(new SKUItem("A", 50));
            inventory.AddSKUitem(new SKUItem("A", 50));

            inventory.AddItemToCart("A");
            inventory.AddItemToCart("A");
            inventory.AddItemToCart("A");


            Assert.Equal(Convert.ToDecimal(150), inventory._cart.TotalPrice());

            pr1.ApplyPromotion(cart);

            Assert.Equal(Convert.ToDecimal(130), inventory._cart.TotalPrice());
           
        }
    }
}
