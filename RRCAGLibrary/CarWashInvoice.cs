/*
* @author Mariah Garcia<mgarcia50@academic.rrc.ca>
* @version 1.0.0
*/

using System;

namespace Garcia.Mariah.Business
{
    public class CarWashInvoice : Invoice
    {
        /// <summary>
        /// private fields.
        /// </summary>
        private decimal _packageCost;
        private decimal _fragranceCost;

        /// <summary>
        /// nitializes an instance of CarWashInvoice with a provincial and goods and services tax rates. 
        /// The package cost and fragrance cost are zero. 
        /// </summary>
        /// <param name="provincialSalesTaxRate">The rate of provincial tax charged to a customer.</param>
        /// <param name="goodsAndServicesTaxRate">The rate of goods and services tax charged to a customer.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when provincialSalesTaxRate is less than 0 or greater than 1.</exception>
        /// <exception cref = "System.ArgumentOutOfRangeException" > Thrown when goodsAndServicesTaxRate is less than 0 or greater than 1.</exception>
        public CarWashInvoice(decimal provincialSalesTaxRate, decimal goodsAndServicesTaxRate) : base(provincialSalesTaxRate, goodsAndServicesTaxRate)
        {
            if (provincialSalesTaxRate < 0)
            {
                throw new ArgumentOutOfRangeException("provincialSalesTaxRate", "The argument cannot be less than 0.");
            }
            else if (provincialSalesTaxRate > 1)
            {
                throw new ArgumentOutOfRangeException("provincialSalesTaxRate", "The argument cannot be greater than 1.");
            }
            base.ProvincialSalesTaxRate = provincialSalesTaxRate;

            if (goodsAndServicesTaxRate < 0)
            {
                throw new ArgumentOutOfRangeException("goodsAndServicesTaxRate", "The argument cannot be less than 0.");
            }
            else if (goodsAndServicesTaxRate > 1)
            {
                throw new ArgumentOutOfRangeException("goodsAndServicesTaxRate", "The argument cannot be greater than 1.");
            }
            base.GoodsAndServicesTaxRate = goodsAndServicesTaxRate;

            _packageCost = 0;
            _fragranceCost = 0;
        }

        /// <summary>
        /// Initializes an instance of CarWashInvoice with a provincial and goods, services tax rate, package cost and fragrance cost.
        /// </summary>
        /// <param name="provincialSalesTaxRate">The rate of provincial tax charged to a customer.</param>
        /// <param name="goodsAndServicesTaxRate">The rate of goods and services tax charged to a customer.</param>
        /// <param name="packageCost">The cost of the chosen package.</param>
        /// <param name="fragranceCost">The cost of the chosen fragrance</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when provincialSalesTaxRate is less than 0 or greater than 1.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when goodsAndServicesTaxRate is less than 0 or greater than 1.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when either packageCost or fragranceCost are less than 0.</exception>
        public CarWashInvoice(decimal provincialSalesTaxRate, decimal goodsAndServicesTaxRate, decimal packageCost, decimal fragranceCost) : base(provincialSalesTaxRate, goodsAndServicesTaxRate)
        {
            if (provincialSalesTaxRate < 0)
            {
                throw new ArgumentOutOfRangeException("provincialSalesTaxRate", "The argument cannot be less than 0.");
            }
            else if (provincialSalesTaxRate > 1)
            {
                throw new ArgumentOutOfRangeException("provincialSalesTaxRate", "The argument cannot be greater than 1.");
            }
            base.ProvincialSalesTaxRate = provincialSalesTaxRate;

            if (goodsAndServicesTaxRate < 0)
            {
                throw new ArgumentOutOfRangeException("goodsAndServicesTaxRate", "The argument cannot be less than 0.");
            }
            else if (goodsAndServicesTaxRate > 1)
            {
                throw new ArgumentOutOfRangeException("goodsAndServicesTaxRate", "The argument cannot be greater than 1.");
            }
            base.GoodsAndServicesTaxRate = goodsAndServicesTaxRate;

            if (packageCost < 0)
            {
                throw new ArgumentOutOfRangeException("packageCost", "The argument cannot be less than 0.");
            }
            _packageCost = packageCost;

            if (fragranceCost < 0)
            {
                throw new ArgumentOutOfRangeException("fragranceCost", "The argument cannot be less than 0.");
            }
            _fragranceCost = fragranceCost;
        }

        /// <summary>
        /// Gets and sets the amount charged for the chosen package.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">When the property is set to less than 0. </exception>
        public decimal PackageCost
        {
            get => _packageCost;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value cannot be less than 0.");
                }
                _packageCost = value;
            }
        }

        /// <summary>
        /// Gets and sets the amount charged for the chosen fragrance.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">When the property is set to less than 0. </exception>
        public decimal FragranceCost
        {
            get => _fragranceCost;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value cannot be less than 0.");
                }
                _fragranceCost = value;
            }

        }

        /// <summary>
        /// Gets the amount of provincial sales tax charged to the customer. No provincial sales tax is charged for a car wash.
        /// </summary>
        public override decimal ProvincialSalesTaxCharged => 0;

        /// <summary>
        /// Gets the amount of goods and services tax charged to the customer.
        /// </summary>
        public override decimal GoodsAndServicesTaxCharged
        {
            get
            {
                return (PackageCost + FragranceCost) * GoodsAndServicesTaxRate;
            }
        }

        /// <summary>
        /// Gets the subtotal of the Invoice.
        /// </summary>
        public override decimal Subtotal
        {
            get
            {
                return PackageCost + FragranceCost;
            }
        }

        /// <summary>
        /// Gets the total of the Invoice.
        /// </summary>
        public decimal Total
        {
            get
            {
                return Subtotal + ProvincialSalesTaxCharged + GoodsAndServicesTaxCharged;
            }
        }
    }
}