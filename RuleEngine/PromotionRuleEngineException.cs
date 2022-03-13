using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine
{
    public class PromotionRuleEngineException :Exception
    {
        public PromotionRuleEngineException() : base()
        {

        }

        public PromotionRuleEngineException(string message) : base(message)
        {

        }

        public PromotionRuleEngineException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
