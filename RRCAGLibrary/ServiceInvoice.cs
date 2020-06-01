/*
* @author Mariah Garcia<mgarcia50@academic.rrc.ca>
* @version 1.0.0
*/

using System;

namespace Garcia.Mariah.Business
{
    public class ServiceInvoice : Invoice
    {

        /// <summary>
        /// Initializes an instance of ServiceInvoice with a provincial and goods and services tax rates.
        /// </summary>
        /// <param name="provincialSalesTaxRate">The rate of provincial tax charged to a customer.</param>
        /// <param name="goodsAndServicesTaxRate">The rate of goods and services tax charged to a customer.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when provincialSalesTaxRate is less than 0 or greater than 1.</exception>
        /// <exception cref = "ArgumentOutOfRangeException" > Thrown when goodsAndServicesTaxRate is less than 0 or greater than 1.</exception>
        public ServiceInvoice(decimal provincialSalesTaxRate, decimal goodsAndServicesTaxRate) : base(provincialSalesTaxRate, goodsAndServicesTaxRate)
        {
            if (provincialSalesTaxRate < 0)
            {
                throw new ArgumentOutOfRangeException("provincialSalesTaxRate", "The value cannot be less than 0.");
            }
            else if (provincialSalesTaxRate > 1)
            {
                throw new ArgumentOutOfRangeException("provincialSalesTaxRate", "The value cannot be greater than 1.");
            }
            base.ProvincialSalesTaxRate = provincialSalesTaxRate;

            if (goodsAndServicesTaxRate < 0)
            {
                throw new ArgumentOutOfRangeException("goodsAndServicesTaxRate", "The value cannot be less than 0.");
            }
            else if (goodsAndServicesTaxRate > 1)
            {
                throw new ArgumentOutOfRangeException("goodsAndServicesTaxRate", "The value cannot be greater than 1.");
            }
            base.GoodsAndServicesTaxRate = goodsAndServicesTaxRate;
        }

        /// <summary>
        /// Gets the amount charged for labour.
        /// </summary>
        public decimal LabourCost
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the amount charged for parts.
        /// </summary>
        public decimal PartsCost
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the amount charged for shop materials.
        /// </summary>
        public decimal MaterialCost
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the amount of provincial sales tax charged to the customer. Provincial Sales Tax is not applied to labour cost.
        /// </summary>
        public override decimal ProvincialSalesTaxCharged
        {
            get
            {
                if(!Enum.IsDefined(typeof(CostType), CostType.Labour))
                {
                    return (PartsCost + MaterialCost) * ProvincialSalesTaxRate;
                }
                else
                {
                    return ((LabourCost * 0) + (PartsCost + MaterialCost)) * ProvincialSalesTaxRate;
                }
            }
        }

        /// <summary>
        /// Gets the amount of goods and services tax charged to the customer.
        /// </summary>
        public override decimal GoodsAndServicesTaxCharged
        {
            get
            {
                return (LabourCost + PartsCost + MaterialCost) * GoodsAndServicesTaxRate;
            }
        }

        /// <summary>
        /// Gets the subtotal of the Invoice.
        /// </summary>
        public override decimal Subtotal
        {
            get
            {
                return LabourCost + MaterialCost + PartsCost;
            }
        }

        /// <summary>
        /// Gets the total of the Invoice.
        /// </summary>
        new public decimal Total
        {
            get
            {
                return Math.Round(Subtotal + ProvincialSalesTaxCharged + GoodsAndServicesTaxCharged);
            }
        }

        /// <summary>
        /// Increments a specified cost by the specified amount.
        /// </summary>
        /// <param name="type"> The type of cost being incremented.</param>
        /// <param name="amount">The amount the cost is beinf incremented by.</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">When the cost type is an invalid argument.</exception>
        /// <exception cref="ArgumentOutOfRangeException">When the amount is less than or equal to 0. </exception>
        public void AddCost(CostType type, decimal amount)
        {
            if(!Enum.IsDefined(typeof(CostType), type))
            {
                throw new System.ComponentModel.InvalidEnumArgumentException("The value is an invalid enumeration value.");
            };

            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException("amount", "The argument cannot be less than or equal to 0.");
            }

            switch (type)
            {
                case CostType.Labour:
                    {
                        LabourCost += amount;
                        break;
                    }
                case CostType.Material:
                    {
                        MaterialCost += amount;
                        break;
                    }
                case CostType.Part:
                    {
                        PartsCost += amount;
                        break;
                    }
            }
        }
    }
}