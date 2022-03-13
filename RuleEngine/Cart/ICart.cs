using RuleEngine.SKU;

namespace RuleEngine.Cart
{
    public interface ICart
    {
        public string AddItem(SKUItem skuItem);
        public string RemoveItem(string skuItemId);
        public bool IsItemExist(string skuItemId);
        public decimal TotalPrice();
    }
}
