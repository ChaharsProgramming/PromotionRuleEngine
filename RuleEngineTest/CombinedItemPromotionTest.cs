using RuleEngine.Promotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RuleEngineTest
{
    public class CombinedItemPromotionTest
    {
        [Fact]
        public void TestApplyPromotion_WithValidInput_ReturnApplyPromotionSuceess()
        {
            var combinedItempromotion = new CombinedItemPromotion();

            Assert.Throws<NotImplementedException>(() => combinedItempromotion.ApplyPromotion());

        }
    }
}
