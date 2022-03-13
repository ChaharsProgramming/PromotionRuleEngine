namespace RuleEngine.SKU
{
    public class SKUItem : SKUBase
    {
        public string _id { get; set; }
        public decimal _itemPrice { get; set; }

        public SKUItem(string id, decimal itemPrice)
        {
            _id = id;
            _itemPrice = itemPrice;             
        }

        public override void UpdateUnitPrice(decimal price)
        {
            _itemPrice = price;
        }
    }
}
