using RuleEngine.SKU;
using System;
using System.Collections.Generic;

namespace RuleEngine.Cart
{
    public class Cart : ICart
    {
        public List<CartItem> cartItems { get; set; }
        public Cart()
        {
            cartItems = new List<CartItem>();
        }

        public void AddItem(SKUItem skuItem)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(SKUItem skuItem)
        {
            throw new NotImplementedException();
        }
    }
}
