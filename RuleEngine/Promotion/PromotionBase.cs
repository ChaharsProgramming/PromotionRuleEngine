namespace RuleEngine.Promotion
{
    public abstract class PromotionBase
    {
        public string PromotionName { get; }
        public abstract void ApplyPromotion(Cart.ICart cart);
    }
}
