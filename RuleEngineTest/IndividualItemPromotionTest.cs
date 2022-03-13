using RuleEngine.Promotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RuleEngineTest
{
    public class IndividualItemPromotionTest
    {
        [Fact]
        public void TestApplyPromotion_WithValidInput_ReturnApplyPromotionSuceess()
        {
            var individualItempromotion = new IndividualItemPromotion();

            Assert.Throws<NotImplementedException>(() => individualItempromotion.ApplyPromotion());

        }
    }
}
