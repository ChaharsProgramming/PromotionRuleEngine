using RuleEngine.SKU;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RuleEngine.Cart
{
    public class Cart : CartBase, ICart
    {
        public List<CartItem> cartItems { get; set; }
        public Cart()
        {
            cartItems = new List<CartItem>();
        }

        public void AddItem(SKUItem skuItem)
        {
            cartItems.Add(new CartItem { Item = skuItem, FinalPrice = skuItem.ItemPrice, IsPromotionApplied = false });
        }

        public void RemoveItem(string skuItemId)
        {
            cartItems.Remove(cartItems.FirstOrDefault(crt => skuItemId.Equals(crt.Item.ID)));
        }

        public override decimal TotalPrice()
        {
            return cartItems.Sum(i => i.FinalPrice);
        }
    }
}
