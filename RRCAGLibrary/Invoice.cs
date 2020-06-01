/*
* @author Mariah Garcia<mgarcia50@academic.rrc.ca>
* @version 1.0.0
*/

using System;

namespace Garcia.Mariah.Business
{
    public abstract class Invoice
    {
        private decimal _provincialSalesTaxRate;
        private decimal _goodsAndServicesTaxRate;
        private decimal _total;

        /// <summary>
        /// Initializes an instance of Invoice with a provincial and goods and services tax rates.
        /// </summary>
        /// <param name="provincialSalesTaxRate">The rate of provincial tax charged to a customer.</param>
        /// <param name="goodsAndServicesTaxRate">The rate of goods and services tax charged to a customer.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when provincialSalesTaxRate is less than 0 or greater than 1.</exception>
        /// <exception cref = "ArgumentOutOfRangeException" > Thrown when goodsAndServicesTaxRate is less than 0 or greater than 1.</exception>
        public Invoice(decimal provincialSalesTaxRate, decimal goodsAndServicesTaxRate)
        {
            if (provincialSalesTaxRate < 0)
            {
                throw new ArgumentOutOfRangeException("provincialSalesTaxRate", "The value cannot be less than 0.");
            }
            else if (provincialSalesTaxRate > 1)
            {
                throw new ArgumentOutOfRangeException("provincialSalesTaxRate", "The value cannot be greater than 1.");
            }
            _provincialSalesTaxRate = provincialSalesTaxRate;

            if (goodsAndServicesTaxRate < 0)
            {
                throw new ArgumentOutOfRangeException("goodsAndServicesTaxRate", "The value cannot be less than 0.");
            }
            else if (goodsAndServicesTaxRate > 1)
            {
                throw new ArgumentOutOfRangeException("goodsAndServicesTaxRate", "The value cannot be greater than 1.");
            }
            _goodsAndServicesTaxRate = goodsAndServicesTaxRate;

        }

        /// <summary>
        /// Gets and sets the provincial sales tax rate.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">When property is less than 0 or greater than 1.</exception>
        public decimal ProvincialSalesTaxRate
        {
            get => _provincialSalesTaxRate;
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value cannot be less than 0.");
                } else if (value > 1)
                {
                    throw new ArgumentOutOfRangeException("value", "The value cannot be greater than 1.");
                }
                _provincialSalesTaxRate = value;

            }
        }

        /// <summary>
        /// Gets and sets the goods and services tax rate.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">When property is less than 0 or greater than 1.</exception>
        public decimal GoodsAndServicesTaxRate
        {
            get => _goodsAndServicesTaxRate;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value cannot be less than 0.");
                }
                else if (value > 1)
                {
                    throw new ArgumentOutOfRangeException("value", "The value cannot be greater than 1.");
                }
                _goodsAndServicesTaxRate = value;

            }
        }

        /// <summary>
        /// Gets the amount of provincial sales tax charged to the customer.
        /// </summary>
        public abstract decimal ProvincialSalesTaxCharged
        {
            get;
        }

        /// <summary>
        /// Gets the amount of goods and services tax charged to the customer.
        /// </summary>
        public abstract decimal GoodsAndServicesTaxCharged
        {
            get;
        }

        /// <summary>
        /// Gets the subtotal of the Invoice.
        /// </summary>
        public abstract decimal Subtotal
        {
            get;
        }

        /// <summary>
        /// Gets the total of the Invoice (Subtotal + Taxes).
        /// </summary>
        public decimal Total
        {
            get => _total = Subtotal + ProvincialSalesTaxCharged + GoodsAndServicesTaxCharged;
        }
    }
}