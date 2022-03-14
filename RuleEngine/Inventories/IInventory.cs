using RuleEngine.Cart;
using RuleEngine.Promotion;
using RuleEngine.SKU;
using System.Collections.Generic;

namespace RuleEngine.Inventory
{
    public interface IInventory
    {
        public Inventory AddSKUitem(SKUItem sKUItem);

        public Inventory AddItemToCart(string skuItem);

        public SKUItem GetSKUItem(string skuItem);

        public ICart GetCart();

        public Inventory Checkout();

        //public Inventory AddPromotion(PromotionBase promotion);

        //public Inventory AddPromotion(string promotion);
    }
}
