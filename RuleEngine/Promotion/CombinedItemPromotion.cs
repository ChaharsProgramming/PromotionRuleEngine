using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var pendingSKUItems = SKUItems;
            var applicableCartItem = cart.cartItems.Where(crt => !crt.IsPromotionApplied);
            foreach (var item in applicableCartItem)
            {
                item.TotalPrice = FixedPrice / SKUItems.Count;
                item.IsPromotionApplied = true;
                pendingSKUItems.Remove(item.Item._id);
            }
            //throw new NotImplementedException();
        }
    }
}
