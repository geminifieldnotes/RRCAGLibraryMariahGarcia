/*
* @author Mariah Garcia<mgarcia50@academic.rrc.ca>
* @version 1.0.0
*/

using System;

namespace Garcia.Mariah.Business
{
    public static class Financial
    {
        /// <summary>
        /// Returns the payment amount for an annuity based on periodic, fixed payments and a fixed interest rate.
        /// </summary>
        /// <param name="rate">Interst rate per period.</param>
        /// <param name="numberOfPaymentPeriods">The total number of payment periods in the annuity.</param>
        /// <param name="presentValue">the present value that a series of payments to be paid in the future is worth now.</param>
        /// <returns>payment The payment amount for an annuity.</returns>
        /// <exception cref="ArgumentOutOfRangeException">When the rate is less than 0 or greater than 1. </exception>
        /// <exception cref="ArgumentOutOfRangeException">When the number of payments is less than 0 or greater than 1. </exception>
        /// <exception cref="ArgumentOutOfRangeException">When the present value is less than or equal to 0. </exception>
        public static decimal GetPayment(decimal rate, int numberOfPaymentPeriods, decimal presentValue)
        {
            decimal futureValue = 0;
            decimal type = 0;
            decimal payment = 0;

            if(rate < 0)
            {
                throw new ArgumentOutOfRangeException("rate", "The argument cannot be less than 0.");
            } else if (rate > 1)
            {
                throw new ArgumentOutOfRangeException("rate", "The argument cannot be greater than 1.");
            };

            if(numberOfPaymentPeriods <= 0)
            {
                throw new ArgumentOutOfRangeException("numberOfPaymentPeriods", "The argument cannot be less than or equal to 0.");
            };

            if(presentValue <= 0)
            {
                throw new ArgumentOutOfRangeException("presentValue","The argument cannot be less than or equal to 0.");
            };

            if (rate == 0)
                payment = presentValue / numberOfPaymentPeriods;
            else
                payment = rate * (futureValue + presentValue * (decimal)Math.Pow((double)(1 + rate), (double)numberOfPaymentPeriods)) /
                              (((decimal)Math.Pow((double)(1 + rate), (double)numberOfPaymentPeriods) - 1) * (1 + rate * type));

            return Math.Round(payment, 2);
        }
    }
}