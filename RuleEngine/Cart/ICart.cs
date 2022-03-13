using RuleEngine.SKU;

namespace RuleEngine.Cart
{
    public interface ICart
    {
        public void AddItem(SKUItem skuItem);
        public void RemoveItem(string skuItemId);
    }
}
