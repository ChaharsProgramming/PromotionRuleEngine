using RuleEngine.SKU;
using System.Collections.Generic;
using System.Linq;

namespace RuleEngine.Cart
{
    public class Cart : ICart
    {
        public List<CartItem> cartItems { get; set; }
        public Cart()
        {
            cartItems = new List<CartItem>();
        }

        public string AddItem(SKUItem skuItem)
        {
            cartItems.Add(new CartItem { Item = skuItem, TotalPrice = skuItem._itemPrice, IsPromotionApplied = false });
            return skuItem._id;
        }

        public string RemoveItem(string skuItemId)
        {
            cartItems.Remove(cartItems.FirstOrDefault(crt => skuItemId.Equals(crt.Item._id)));
            return skuItemId;
        }

        public bool IsItemExist(string skuItemId)
        {
            if(cartItems.Contains(cartItems.FirstOrDefault(crt => skuItemId.Equals(crt.Item._id))))
            {
                return true;
            }
            return false;
        }

        public decimal TotalPrice()
        {
            return cartItems.Sum(i => i.TotalPrice);
        }
    }
}
