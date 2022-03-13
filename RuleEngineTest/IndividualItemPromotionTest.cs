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
        //private Mock<ICart> _Cart;
       //private Mock<IInventory> _inventory;

        public IndividualItemPromotionTest()
        {
            //_Cart = new Mock<ICart>();
            //_inventory = new Mock<IInventory>();

        }
        [Fact]
        public void TestApplyPromotion_WithValidInput_ReturnApplyPromotionSuceess()
        {
            var cartItem = new CartItem();
            var inventory = new Inventory();
            cartItem.IsPromotionApplied = true;
            cartItem.Item = new SKUItem("A", 50);
            cartItem.TotalPrice = 150;

            IndividualItemPromotion pr1 = new("A", 3, 130);
            //List<PromotionBase> promotions = new() { pr1 };
            var cart = new Cart() { cartItems = { cartItem } };
            inventory.AddItemToCart("A");


            Assert.Equal(Convert.ToDecimal(100), inventory._cart.TotalPrice());
            //_Cart.Setup(crt => crt.AddItem(new SKUItem("A", 50))).Returns("1");
            //_inventory.Setup(inv => inv.AddItemToCart("A")).Returns(new Inventory()
            //{ skuItems = { new SKUItem("A", 50) }, promotions = promotions, _cart = cart });
            pr1.ApplyPromotion(cart);

            Assert.Equal(Convert.ToDecimal(50), inventory._cart.TotalPrice());
           
        }
    }
}
