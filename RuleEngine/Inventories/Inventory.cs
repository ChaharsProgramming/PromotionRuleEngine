using RuleEngine.SKU;
using System;

namespace RuleEngine.Inventory
{
    public class Inventory : IInventory
    {
        public Inventory()
        {
                
        }
        public Inventory AddItemToCart(string skuItem)
        {
            throw new NotImplementedException();
        }

        public Inventory AddSKUitem(SKUItem sKUItem)
        {
            throw new NotImplementedException();
        }

        public Cart.Cart GetCart()
        {
            throw new NotImplementedException();
        }

        public SKUItem GetSKUItem(string skuItem)
        {
            throw new NotImplementedException();
        }
    }
}
