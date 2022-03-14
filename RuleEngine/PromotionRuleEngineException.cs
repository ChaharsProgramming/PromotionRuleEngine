using System;

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
