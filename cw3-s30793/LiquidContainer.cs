namespace cw3_s30793;

class LiquidContainer : Container {//
    public bool IsDangerous { get;  set; }
    
    public LiquidContainer(bool isDangerous) : base("L")
    { IsDangerous = isDangerous;
    } public override void Load(double weight)
    {
        double maxPossible;
        if (IsDangerous) maxPossible = maxLoad*0.5;
        else maxPossible = maxLoad*0.9;
        
        if (loadWeight + weight > maxPossible)
        {
            HazardNotifier($"DANGEROUS OPERATION: Attempting to transfer container {serialNumber}");
            throw new OverfillException($"WARNING: The maximum load capacity of the container {serialNumber} has been exceeded.");
        }
        loadWeight += weight;
    }
    public void HazardNotifier(string message)
    { Console.WriteLine(message); }
}