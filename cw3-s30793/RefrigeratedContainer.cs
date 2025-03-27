namespace cw3_s30793;

class RefrigeratedContainer : Container
{
    public double RequiredTemp { get;  set; }
    public double CurrentTemp { get;  set; }
    public string ProductType { get; set; }

    private Dictionary<string?, double> RequiredProductTemp = new Dictionary<string?, double>()
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 }
    };

    public RefrigeratedContainer(string productType) : base("C")
    {
        if (RequiredProductTemp.ContainsKey(productType)) RequiredTemp = RequiredProductTemp[productType];
        else
        {
            throw new UnknownProductException("WARNINIG: Unknown product type: " + productType);
        }

        ProductType = productType;
        RequiredTemp = RequiredProductTemp[productType];
    }

    public void CheckTemp(double temperature)
    {
        if (temperature < RequiredTemp)
        {
            throw new WrongTemperatureException($"WARNING: The temperature cannot be lower than {RequiredTemp}°C for product: {ProductType}");
        }
    }

    public class UnknownProductException : Exception
    {
        public UnknownProductException(string message) : base(message)
        {
        }
    }//

    public class WrongTemperatureException : Exception
    {
        public WrongTemperatureException(string message) : base(message) 
        {
        }
    }
}