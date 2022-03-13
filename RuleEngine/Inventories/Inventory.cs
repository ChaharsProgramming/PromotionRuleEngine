using RuleEngine.Cart;
using RuleEngine.SKU;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RuleEngine.Inventory
{
    public class Inventory : IInventory
    {
        public readonly ICart _cart;
        public List<SKUItem> skuItems { get; }
        public Inventory(Cart.ICart cart)
        {
            _cart = cart;
            skuItems = new List<SKUItem>();
        }
        public Inventory AddItemToCart(string item)
        {
            if (!string.IsNullOrWhiteSpace(item))
            {
                _cart.AddItem(skuItems.FirstOrDefault(i => item.Equals(i._id)));
            }
            return this;
        }

        public Inventory AddSKUitem(SKUItem sKUItem)
        {
            if (sKUItem != null)
            {
                skuItems.Add(sKUItem);
            }
            return this;
        }

        public ICart GetCart()
        {
            return _cart;
        }

        public SKUItem GetSKUItem(string skuItem)
        {
            return skuItems.FirstOrDefault(i => skuItem.Equals(i._id));
        }
    }
}
