using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Promotion
{
    public class IndividualItemPromotion : PromotionBase
    {
        public string SKUItem { get; set; }
        public int FixedPrice { get; set; }
        public int NoOfItems { get; set; }

        public IndividualItemPromotion(string skuItem, int fixedPrice, int noOfItems)
        {
            SKUItem = skuItem;
            NoOfItems = noOfItems;
            FixedPrice = fixedPrice;
        }
       
        public override void ApplyPromotion(Cart.ICart cart)
        {
            if (FixedPrice <= 0) throw new PromotionRuleEngineException("Price can not be zero!", new ArgumentNullException());
            decimal reducedPrice = 0;
            var discountedItemPrice = FixedPrice / NoOfItems;
            var applicableCartItem = cart.cartItems.Where(crt => !crt.IsPromotionApplied && SKUItem == crt.Item._id);

            reducedPrice = FixedPrice - NoOfItems * discountedItemPrice;
            foreach (var item in applicableCartItem)
            {
                

                item.TotalPrice = discountedItemPrice + reducedPrice;
                item.IsPromotionApplied = true;
                reducedPrice = 0;
            }

            //throw new NotImplementedException();
        }

       
    }

}
