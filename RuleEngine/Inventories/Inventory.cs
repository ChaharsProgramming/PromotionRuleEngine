using RuleEngine.Cart;
using RuleEngine.Promotion;
using RuleEngine.SKU;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RuleEngine.Inventory
{
    public class Inventory : IInventory
    {
        public ICart _cart;
        public List<SKUItem> skuItems { get; }
        public List<PromotionBase> promotions { get; set; }

        public Inventory()
        {
            _cart = new Cart.Cart();
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

        public Inventory AddIndividualPromotion(PromotionBase promotion)
        {
            throw new NotImplementedException();
        }

        public Inventory AddBulkPromotion(List<PromotionBase> promotions)
        {
            throw new NotImplementedException();
        }
    }
}
