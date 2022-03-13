using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Promotion
{
    public abstract class PromotionBase
    {
        public string PromotionName { get; }
        public abstract void ApplyPromotion(Cart.ICart cart);
    }
}
