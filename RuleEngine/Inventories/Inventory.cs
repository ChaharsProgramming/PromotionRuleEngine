using RuleEngine.Cart;
using RuleEngine.Promotion;
using RuleEngine.SKU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RuleEngine.Inventory
{
    public class Inventory : IInventory
    {
        public ICart _cart;
        public List<SKUItem> skuItems { get; }
        public List<PromotionBase> promotions { get; set; }

        public Inventory()
        {
            _cart = new Cart.Cart();
            skuItems = new List<SKUItem>();
            promotions = new List<PromotionBase>();


        }
        public Inventory AddItemToCart(string item)
        {
            if (!string.IsNullOrWhiteSpace(item))
            {
                _cart.AddItem(skuItems.FirstOrDefault(i => item.Equals(i._id)));
            }
            return this;
        }

        public Inventory AddSKUitem(SKUItem sKUItem)
        {
            if (sKUItem != null)
            {
                skuItems.Add(sKUItem);
            }
            return this;
        }

        public ICart GetCart()
        {
            return _cart;
        }

        public SKUItem GetSKUItem(string skuItem)
        {
            return skuItems.FirstOrDefault(i => skuItem.Equals(i._id));
        }

        public Inventory AddPromotion(string promotion)
        {
            if (Regex.IsMatch(promotion, @"^\d"))
            {
                AddPromotion(AddPromotionForIndividualFixedItemPromotion(promotion));
            }
            else
            {
                AddPromotion(AddPromotionForCombinedItemPromotion(promotion));
            }
            return this;
        }

        public Inventory Checkout()
        {
            promotions.ForEach(p => p.ApplyPromotion(_cart));
            return this;
        }

        private Inventory AddPromotion(PromotionBase promotion)
        {
            try
            {
                if (promotion != null) promotions.Add(promotion);
                return this;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private CombinedItemPromotion AddPromotionForCombinedItemPromotion(string promotion)
        {

            try
            {
                //string A B C D for 130
                List<string> promotionDetails = GetCombinedPromotionDetail(promotion);

                var skuitem = promotionDetails.Take(promotionDetails.Count() - 1).ToList();
                var price = Convert.ToInt32(promotionDetails.Last());
                //new CombinedItemPromotion(skuitem, price).ApplyPromotion(_cart);
                return new CombinedItemPromotion(skuitem, price);
            }
            catch (Exception ex)
            {
                throw new PromotionRuleEngineException("Please check the provide input",ex);
            }
        }

        private IndividualItemPromotion AddPromotionForIndividualFixedItemPromotion(string promotion)
        {
            try
            {
                List<string> promotionDetails = GetIndividualPromotionDetail(promotion);

                var skuitems = promotionDetails[1].Replace("'s", "");
                var noOfItems = Convert.ToInt32(promotionDetails.First());
                var price = Convert.ToInt32(promotionDetails.Last());
                //new IndividualItemPromotion(skuitems, price, noOfItems).ApplyPromotion(_cart);
                return new IndividualItemPromotion(skuitems, price, noOfItems);
            }
            catch (Exception ex)
            {

                throw new PromotionRuleEngineException("Please check the provide input", ex); ;
            }
        }

        private static List<string> GetIndividualPromotionDetail(string promotion)
        {
            //string 3 A's FOR 130
            return promotion.Split(" ")
               .Where(p => !string.IsNullOrEmpty(p.Trim())
               && !"of".Equals(p)
               && !"for".Equals(p)).ToList();
        }

        private static List<string> GetCombinedPromotionDetail(string promotion)
        {
            return promotion.Split(" ")
                            .Where(p => !string.IsNullOrEmpty(p.Trim())
                            && !"&".Equals(p)
                            && !"for".Equals(p)).ToList();
        }

    }
}
