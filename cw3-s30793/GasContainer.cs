namespace cw3_s30793;

class GasContainer : Container
{
    public double AirPressure { get; set; }
         public GasContainer(double airPressure) : base("G")
         { AirPressure = airPressure; }
         
    public override void Load(double weight)
    {//
        if (loadWeight + weight > maxLoad)
        {
            HazardNotifier($"DANGEROUS OPERATION: Attempting to transfer container {serialNumber}");
            throw new OverfillException($"WARNING: The maximum load capacity of the container {serialNumber} has been exceeded.");
        }
        loadWeight += weight;
    }
    public override void Unload()
         { loadWeight *= 0.05;}
    
    public void HazardNotifier(string message)
    {
        Console.WriteLine(message);
    }
}