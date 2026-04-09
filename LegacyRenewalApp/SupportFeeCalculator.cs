namespace LegacyRenewalApp;

public class SupportFeeCalculator
{
    public decimal Calculate(string planCode, bool includeSupport)
    {
        if (!includeSupport) return 0;

        if (planCode == "START") return 250m;
        if (planCode == "PRO") return 400m;
        if (planCode == "ENTERPRISE") return 700m;

        return 0;
    }
}