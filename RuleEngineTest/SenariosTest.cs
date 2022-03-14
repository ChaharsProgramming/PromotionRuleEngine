using RuleEngine;
using RuleEngine.Cart;
using RuleEngine.Inventory;
using RuleEngine.SKU;
using System;
using System.Collections.Generic;
using Xunit;

namespace RuleEngineTest
{
    public class SenariosTest
    {
        [Fact]
        public void TestCheckOutSenariosA()
        {
            string inputPromo = "1 A for 50";
            string inputPromo2 = "1 B for 30";
            string inputPromo3 = "1 C for 20";
            List<string> promolist = new List<string>() { inputPromo ,inputPromo2 ,inputPromo3 };
            var inventory = new Inventory();
            inventory.AddSKUitem(new SKUItem("A", 50));
            inventory.AddSKUitem(new SKUItem("B", 30));
            inventory.AddSKUitem(new SKUItem("C", 20));

            inventory.AddItemToCart("A");
            inventory.AddItemToCart("B");
            inventory.AddItemToCart("C");

            Assert.Equal(Convert.ToDecimal(100), inventory._cart.TotalPrice());

            foreach(var item in promolist)
            {
                inventory.AddPromotion(item);
            }       
            inventory.Checkout();

            Assert.Equal(Convert.ToDecimal(100), inventory._cart.TotalPrice());

        }

        [Fact]
        public void TestCheckOutSenariosB()
        {
            string inputPromo = $"5 A for {130 + 2*50}";
            string inputPromo2 = $"5 B for {45 + 45 + 30}";
            string inputPromo3 = $"1 C for 20";
            List<string> promolist = new List<string>() { inputPromo, inputPromo2, inputPromo3 };
            var inventory = new Inventory();
            
            inventory.AddSKUitem(new SKUItem("A", 130 + 2 * 50));
            inventory.AddSKUitem(new SKUItem("A", 130 + 2 * 50));
            inventory.AddSKUitem(new SKUItem("A", 130 + 2 * 50));
            inventory.AddSKUitem(new SKUItem("A", 130 + 2 * 50));
            inventory.AddSKUitem(new SKUItem("A", 130 + 2 * 50));

            inventory.AddSKUitem(new SKUItem("B", 45 + 45 + 30));
            inventory.AddSKUitem(new SKUItem("B", 45 + 45 + 30));
            inventory.AddSKUitem(new SKUItem("B", 45 + 45 + 30));
            inventory.AddSKUitem(new SKUItem("B", 45 + 45 + 30));
            inventory.AddSKUitem(new SKUItem("B", 45 + 45 + 30));

            inventory.AddSKUitem(new SKUItem("C", 28));

            inventory.AddItemToCart("A");
            inventory.AddItemToCart("A");
            inventory.AddItemToCart("A");
            inventory.AddItemToCart("A");
            inventory.AddItemToCart("A");

            inventory.AddItemToCart("B");
            inventory.AddItemToCart("B");
            inventory.AddItemToCart("B");
            inventory.AddItemToCart("B");
            inventory.AddItemToCart("B");

            inventory.AddItemToCart("C");

            Assert.Equal(Convert.ToDecimal(1778), inventory._cart.TotalPrice());

            foreach (var item in promolist)
            {
                inventory.AddPromotion(item);
            }
            inventory.Checkout();

            Assert.Equal(Convert.ToDecimal(370), inventory._cart.TotalPrice());

        }

        [Fact]
        public void TestCheckOutSenariosC()
        {
            string inputPromo = $"3 A for {130}";
            string inputPromo2 = $"5 B for {45 + 45 + 1 * 30}";
            string inputPromo3 = $"1 C for ";
            string inputPromo4 = $"1 D for 30";
            List<string> promolist = new List<string>() { inputPromo, inputPromo2, inputPromo3, inputPromo4 };
            var inventory = new Inventory();

            inventory.AddSKUitem(new SKUItem("A", 130));
            inventory.AddSKUitem(new SKUItem("A", 130));
            inventory.AddSKUitem(new SKUItem("A", 130));

            inventory.AddSKUitem(new SKUItem("B", 45 + 45 + 1 * 30));
            inventory.AddSKUitem(new SKUItem("B", 45 + 45 + 1 * 30));
            inventory.AddSKUitem(new SKUItem("B", 45 + 45 + 1 * 30));
            inventory.AddSKUitem(new SKUItem("B", 45 + 45 + 1 * 30));
            inventory.AddSKUitem(new SKUItem("B", 45 + 45 + 1 * 30));

            inventory.AddSKUitem(new SKUItem("C", 0));
            inventory.AddSKUitem(new SKUItem("D", 30));

            inventory.AddItemToCart("A");
            inventory.AddItemToCart("A");
            inventory.AddItemToCart("A");

            inventory.AddItemToCart("B");
            inventory.AddItemToCart("B");
            inventory.AddItemToCart("B");
            inventory.AddItemToCart("B");
            inventory.AddItemToCart("B");

            inventory.AddItemToCart("C");

            inventory.AddItemToCart("D");

            Assert.Equal(Convert.ToDecimal(1020), inventory._cart.TotalPrice());

            Assert.Throws<PromotionRuleEngineException>(()=>promolist.ForEach(s=>inventory.AddPromotion(s)));
           
        }
    }
}
