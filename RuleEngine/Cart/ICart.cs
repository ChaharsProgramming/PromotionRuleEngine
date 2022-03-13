using RuleEngine.SKU;
using System.Collections.Generic;

namespace RuleEngine.Cart
{
    public interface ICart
    {
        public List<CartItem> cartItems { get; set; }
        public string AddItem(SKUItem skuItem);
        public string RemoveItem(string skuItemId);
        public bool IsItemExist(string skuItemId);
        public decimal TotalPrice();
    }
}
