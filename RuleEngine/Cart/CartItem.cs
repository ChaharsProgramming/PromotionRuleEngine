using RuleEngine.SKU;
using System;
namespace RuleEngine.Cart
{
    public class CartItem
    {
        public SKUItem Item { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsPromotionApplied { get; set; }
    }
}
