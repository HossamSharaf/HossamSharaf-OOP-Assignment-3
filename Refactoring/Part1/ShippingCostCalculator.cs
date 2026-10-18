namespace RefactoringLab;

public interface ICalculator
{
    public decimal Calculate(decimal weightkg);
}
public class ShippingCostCalculator
{
    public decimal Calculate(ICalculator carrier, decimal weightKg)
    {
        return carrier.Calculate(weightKg);
    }
}
public class AramexCarrier : ICalculator
{
    public decimal Calculate(decimal weight)
    {
        return weight * 12m;
    }
}
public class FedexCarrier : ICalculator
{
    public decimal Calculate(decimal weight)
    {
        return weight * 15m;
    }
}
public class DHLCarrier : ICalculator
{
    public decimal Calculate(decimal weight)
    {
        return weight * 18m;
    }
}
public class UpsCarrier : ICalculator
{
    public decimal Calculate(decimal weight)
    {
        return weight * 20m;
    }
}
