﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerDemo.Model
{
    public class Price
    {
        private IDiscountStrategy _discountStrategy = new NullDiscountStrategy();
        private decimal _rrp;
        private decimal _sellingPrice;

        public Price(decimal rrp, decimal sellingPrice) 
        {
            _rrp = rrp;
            _sellingPrice = sellingPrice;
        }

        public void SetDiscountStrategyTo(IDiscountStrategy discountStrategy) 
        {
            _discountStrategy = discountStrategy;
        }

        public decimal SellingPrice 
        {
            get { return _discountStrategy.ApplyExtraDiscountsTo(_sellingPrice); }
        }

        public decimal RRP 
        {
            get { return _rrp; }
        }

        public decimal Discount 
        {
            get 
            {
                if (RRP > SellingPrice)
                {
                    return RRP - SellingPrice;
                }
                else 
                {
                    return 0;
                }
            }
        }

        public decimal Savings 
        {
            get
            {
                if (RRP > SellingPrice)
                {
                    return 1 - SellingPrice / RRP;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
