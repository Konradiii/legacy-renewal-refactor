using System;

namespace LegacyRenewalApp;

public class DiscountCalculator
{
    public (decimal discount, string notes) Calculate(
        Customer customer,
        SubscriptionPlan plan,
        int seatCount,
        decimal baseAmount,
        bool usePoints)
    {
        decimal discount = 0m;
        string notes = "";

        // segment
        if (customer.Segment == "Silver")
        {
            discount += baseAmount * 0.05m;
            notes += "silver discount; ";
        }
        else if (customer.Segment == "Gold")
        {
            discount += baseAmount * 0.10m;
            notes += "gold discount; ";
        }
        else if (customer.Segment == "Platinum")
        {
            discount += baseAmount * 0.15m;
            notes += "platinum discount; ";
        }
        else if (customer.Segment == "Education" && plan.IsEducationEligible)
        {
            discount += baseAmount * 0.20m;
            notes += "education discount; ";
        }

        // loyalty
        if (customer.YearsWithCompany >= 5)
        {
            discount += baseAmount * 0.07m;
            notes += "long-term loyalty discount; ";
        }
        else if (customer.YearsWithCompany >= 2)
        {
            discount += baseAmount * 0.03m;
            notes += "basic loyalty discount; ";
        }

        // seats
        if (seatCount >= 50)
        {
            discount += baseAmount * 0.12m;
            notes += "large team discount; ";
        }
        else if (seatCount >= 20)
        {
            discount += baseAmount * 0.08m;
            notes += "medium team discount; ";
        }
        else if (seatCount >= 10)
        {
            discount += baseAmount * 0.04m;
            notes += "small team discount; ";
        }

        // points
        if (usePoints && customer.LoyaltyPoints > 0)
        {
            int points = Math.Min(200, customer.LoyaltyPoints);
            discount += points;
            notes += $"loyalty points used: {points}; ";
        }

        return (discount, notes);
    }
}