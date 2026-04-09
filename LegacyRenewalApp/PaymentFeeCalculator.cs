using System;

namespace LegacyRenewalApp
{
    public class PaymentFeeCalculator
    {
        public (decimal fee, string note) Calculate(string method, decimal amount)
        {
            if (method == "CARD")
                return (amount * 0.02m, "card payment fee; ");

            if (method == "BANK_TRANSFER")
                return (amount * 0.01m, "bank transfer fee; ");

            if (method == "PAYPAL")
                return (amount * 0.035m, "paypal fee; ");

            if (method == "INVOICE")
                return (0m, "invoice payment; ");

            throw new ArgumentException("Unsupported payment method");
        }
    }
}