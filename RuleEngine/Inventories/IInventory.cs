using RuleEngine.Cart;
using RuleEngine.SKU;

namespace RuleEngine.Inventory
{
    public interface IInventory
    {
        public Inventory AddSKUitem(SKUItem sKUItem);

        public Inventory AddItemToCart(string skuItem);

        public SKUItem GetSKUItem(string skuItem);

        public ICart GetCart();

    }
}
