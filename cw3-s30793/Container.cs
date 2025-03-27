namespace cw3_s30793;

abstract class Container
{
    private static int _nextSerialNumber= 1;
    public string serialNumber { get; set; }
    public double loadWeight { get;  set; }
    public double height { get; set; }
    public double ownWeight { get; set; }
    public double depth { get; set; }
    public double maxLoad { get; set; }
    
    public Container(string type)
    {
        serialNumber = $"KON-{type}-{_nextSerialNumber++}";
        
    }
    

    public virtual void Load(double weight){
        if (loadWeight + weight > maxLoad)
        { throw new OverfillException($"WARNING: The maximum weight of the container {serialNumber} has been exceeded.");
        }
        loadWeight += weight;
    }

    public virtual void Unload()
    { loadWeight = 0; }
    
    
}
class OverfillException : Exception
{
    public OverfillException(string message) : base(message) { }
}