/*
* @author Mariah Garcia<mgarcia50@academic.rrc.ca>
* @version 1.0.0
*/

using System;
using System.Collections.Generic;

namespace Garcia.Mariah.Business
{
    public class SalesQuote
    {
        /// <summary>
        /// Fields for SalesQuote class.
        /// </summary>
        private decimal _vehicleSalePrice, _tradeInAmount, _salesTaxRate;
        private Accessories _accessoriesChosen;
        private ExteriorFinish _exteriorFinishChosen;

        /// <summary>
        /// Used variables for class methods.
        /// </summary>
        private decimal _accessoriesCost;
        private decimal _exteriorFinishCost;
        private decimal _salesTax;
        private decimal _total;
        private decimal _amountDue;
        private decimal _subtotal;

        /// <summary>
        /// Dictionary for Accessories costs.
        /// </summary>
        private Dictionary<Accessories, decimal> accessoriesDictionary = new Dictionary<Accessories, decimal>
        {
            { Accessories.None, 0.00M },
            { Accessories.StereoSystem, 505.05M },
            { Accessories.LeatherInterior, 1010.10M },
            { Accessories.ComputerNavigation, 1515.15M },
            { Accessories.StereoAndLeather, 1515.15M },
            { Accessories.StereoAndNavigation, 2020.20M },
            { Accessories.LeatherAndNavigation, 2525.25M }
        };

        /// <summary>
        /// Dictionary for ExteriorFinish costs.
        /// </summary>
        private Dictionary<ExteriorFinish, decimal> exteriorFinishDictionary = new Dictionary<ExteriorFinish, decimal>
        {
            { ExteriorFinish.None, 0.00M },
            { ExteriorFinish.Standard, 202.02M },
            { ExteriorFinish.Pearlized, 404.04M },
            { ExteriorFinish.Custom, 606.06M }
        };

        /// <summary>
        /// Instantiates a SalesQuote object with defined vehicle sale price, trade-in amount, tax rate, accessories, and exterior finish.
        /// </summary>
        /// <param name="vehicleSalePrice">Sale price of vehicle.</param>
        /// <param name="tradeInAmount">Amount paid to be subtracted in total cost.</param>
        /// <param name="salesTaxRate">Tax rate applied to subtotal.</param>
        /// <param name="accessoriesChosen">Type of accessory option chosen.</param>
        /// <param name="exteriorFinishChosen">Type of exterior finish option chosen.</param>
        /// <exception cref="ArgumentOutOfRangeException">When the vehicle sale price is less than or equal to 0. </exception>
        /// <exception cref="ArgumentOutOfRangeException">When the trade in amount is less than 0. </exception>
        /// <exception cref="ArgumentOutOfRangeException">When the sales tax rate is either less than 0 or greater than 1. </exception>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">When the accessories chosen is an invalid argument.</exception> 
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">When the exterior finish chosen is an invalid argument.</exception> 
        public SalesQuote(decimal vehicleSalePrice, decimal tradeInAmount, decimal salesTaxRate, Accessories accessoriesChosen, ExteriorFinish exteriorFinishChosen)
        {
            if (vehicleSalePrice <= 0)
            {
                throw new ArgumentOutOfRangeException("vehicleSalePrice", "The value cannot be less than or equal to 0.");
            }
            _vehicleSalePrice = vehicleSalePrice;

            if (tradeInAmount < 0)
            {
                throw new ArgumentOutOfRangeException("tradeInAmount", "The value cannot be less than 0.");
            }
            _tradeInAmount = tradeInAmount;

            if (salesTaxRate < 0)
            {
                throw new ArgumentOutOfRangeException("salesTaxRate", "The value cannot be less than 0.");
            } else if (salesTaxRate > 1)
            {
                throw new ArgumentOutOfRangeException("salesTaxRate", "The value cannot be greater than 1.");
            }
            _salesTaxRate = salesTaxRate;

            if (!Enum.IsDefined(typeof(Accessories), accessoriesChosen))
            {
                throw new System.ComponentModel.InvalidEnumArgumentException("The value is an invalid enumeration value.");
            }
            _accessoriesChosen = accessoriesChosen;

            if (!Enum.IsDefined(typeof(ExteriorFinish), exteriorFinishChosen))
            {
                throw new System.ComponentModel.InvalidEnumArgumentException("The value is an invalid enumeration value.");
            }
            _exteriorFinishChosen = exteriorFinishChosen;
        }

        /// <summary>
        /// Instantiates a SalesQuote object with defined vehicle sale price, trade0in amount, and sales tax rate.
        /// </summary>
        /// <param name="vehicleSalePrice">Sale price of vehicle.</param>
        /// <param name="tradeInAmount">Amount paid to be subtracted in total cost.</param>
        /// <param name="salesTaxRate">Tax rate applied to subtotal.</param>
        /// <exception cref="ArgumentOutOfRangeException">When the vehicle sale price is less than or equal to 0. </exception>
        /// <exception cref="ArgumentOutOfRangeException">When the trade in amount is less than 0. </exception>
        /// <exception cref="ArgumentOutOfRangeException">When the sales tax rate is either less than 0 or greater than 1. </exception>
        public SalesQuote(decimal vehicleSalePrice, decimal tradeInAmount, decimal salesTaxRate)
        {
            if (vehicleSalePrice <= 0)
            {
                throw new ArgumentOutOfRangeException("vehicleSalePrice", "The value cannot be less than or equal to 0.");
            }
            _vehicleSalePrice = vehicleSalePrice;

            if (tradeInAmount < 0)
            {
                throw new ArgumentOutOfRangeException("tradeInAmount", "The value cannot be less than 0.");
            }
            _tradeInAmount = tradeInAmount;

            if (salesTaxRate < 0)
            {
                throw new ArgumentOutOfRangeException("salesTaxRate", "The value cannot be less than 0.");
            }
            else if (salesTaxRate > 1)
            {
                throw new ArgumentOutOfRangeException("salesTaxRate", "The value cannot be greater than 1.");
            }
            _salesTaxRate = salesTaxRate;

            _accessoriesChosen = Accessories.None;
            _exteriorFinishChosen = ExteriorFinish.None;
        }

        /// <summary>
        /// Gets and sets the sale price of the vehicle.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">When the property is set to less than or equal to 0. </exception>
        public decimal VehicleSalePrice
        {
            get => _vehicleSalePrice;
            set {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value cannot be less than or equal to 0.");
                }
                _vehicleSalePrice = value;
            }
        }

        /// <summary>
        /// Gets and sets the trade in amount.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">When the property is set to less than 0. </exception>
        public decimal TradeInAmount
        {
            get => Math.Round(_tradeInAmount, 2);
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value cannot be less than 0.");
                }

                _tradeInAmount = Math.Round(value, 2);

            }
        }

        /// <summary>
        /// Gets and sets the accessories that were chosen.
        /// </summary>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">When the accessory chosen is an invalid argument.</exception> 
        public Accessories AccessoriesChosen
        {
            get => _accessoriesChosen;

            set
            {
                if (!Enum.IsDefined(typeof(Accessories), AccessoriesChosen))
                {
                    throw new System.ComponentModel.InvalidEnumArgumentException("The value is an invalid enumeration value.");
                }
                else
                {
                    _accessoriesChosen = AccessoriesChosen;
                }
            }
        }

        /// <summary>
        /// Gets and sets the exterior finish that were chosen.
        /// </summary>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">When the exterior finish chosen is an invalid argument.</exception> 
        public ExteriorFinish ExteriorFinishChosen
        {
            get => _exteriorFinishChosen;

            set
            {
                if (!Enum.IsDefined(typeof(ExteriorFinish), ExteriorFinishChosen))
                {
                    throw new System.ComponentModel.InvalidEnumArgumentException("The value is an invalid enumeration value.");
                }
                else
                {
                    _exteriorFinishChosen = ExteriorFinishChosen;
                }
            }
        }

        /// <summary>
        /// Gets the cost of accessories chosen.
        /// </summary>
        public decimal AccessoriesCost
        {
            get
            {
                _accessoriesCost = accessoriesDictionary[_accessoriesChosen];
                return Math.Round(_accessoriesCost, 2);
            }
        }

        /// <summary>
        /// Gets the cost of the exterior finish chosen.
        /// </summary>
        public decimal ExteriorFinishCost
        {
            get
            {
                _exteriorFinishCost = exteriorFinishDictionary[_exteriorFinishChosen];
                return Math.Round(_exteriorFinishCost, 2);
            }
        }

        /// <summary>
        ///  Gets the sum of the vehicle’s sale price and the Accessory and Finish Cost (rounded to two decimal places).
        /// </summary>
        public decimal SubTotal
        {
            get
            {
                _subtotal = VehicleSalePrice + AccessoriesCost + ExteriorFinishCost;
                return Math.Round(_subtotal, 2);
            }
        }

        /// <summary>
        /// Gets the amount of tax to charge based on the subtotal (rounded to two decimal places).
        /// </summary>
        public decimal SalesTax
        {
            get
            {
                _salesTax = SubTotal * _salesTaxRate;
                return Math.Round(_salesTax, 2);
            }
        }

        /// <summary>
        /// Gets the sum of the subtotal and taxes.
        /// </summary>
        public decimal Total
        {
            get
            {
                _total = SubTotal + SalesTax;
                return Math.Round(_total, 2);
            }
        }

        /// <summary>
        /// Gets the result of subtracting the trade-in amount from the total.
        /// </summary>
        public decimal AmountDue
        {
            get
            {
                _amountDue = Total - TradeInAmount;
                return Math.Round(_amountDue, 2);
            }
        }
    }
}