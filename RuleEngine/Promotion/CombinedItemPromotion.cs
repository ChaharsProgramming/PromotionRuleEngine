using System;
using System.Collections.Generic;
using System.Linq;

namespace RuleEngine.Promotion
{
    public class CombinedItemPromotion : PromotionBase
    {
        public List<string> SKUItems { get; set; }
        public int FixedPrice{ get; set; }


        public CombinedItemPromotion(List<string> skuItems, int fixedPrice)
        {
            SKUItems = skuItems;
            FixedPrice = fixedPrice;
        }
        public override void ApplyPromotion(Cart.ICart cart)
        {
            if (FixedPrice <= 0) throw new PromotionRuleEngineException("Price can not be zero!", new ArgumentNullException());
            var pendingSKUItems = SKUItems;
            var applicableCartItem = cart.cartItems.Where(crt => !crt.IsPromotionApplied);
            foreach (var item in applicableCartItem)
            {
                item.TotalPrice = FixedPrice / cart.cartItems.Count;
                item.IsPromotionApplied = true;
                pendingSKUItems.Remove(item.Item._id);
            }
        }
   }
}
