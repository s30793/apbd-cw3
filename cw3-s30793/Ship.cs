namespace cw3_s30793;

class Ship
{
    public int MaxContainerCount { get; private set; }
    public double MaxWeightCapacity { get; private set; }
    public string Name { get; private set; }
    public double MaxSpeed { get; private set; }
    
    private readonly List<Container> Containers;

    public Ship(string name, double maxSpeed, int maxContainerCount, double maxWeightCapacity)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainerCount = maxContainerCount;
        MaxWeightCapacity = maxWeightCapacity;
        Containers = new List<Container>();
    }
    
    public double GetTotalWeight()
         {
             double totalWeight = 0;
             foreach (var container in Containers)
             { totalWeight+=(container.loadWeight+container.ownWeight)/1000; }
             return totalWeight;
         }
    public void AddContainer(Container container)
    {
        if (Containers.Count >= MaxContainerCount)
        {
            throw new Error("CANNOT ADD CONTAINER: ship capacity exceeded.");
        }

        if (GetTotalWeight() + (container.loadWeight + container.ownWeight) / 1000.0 > MaxWeightCapacity)
        {
            throw new Error("CANNOT ADD CONTAINER: weight capacity exceeded.");
        }

        Containers.Add(container);
    }
    public void RemoveContainer(Container container)
    { Containers.Remove(container); }
//
    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        int index = Containers.FindIndex(c => c.serialNumber == serialNumber);
        if (index == -1)
            throw new Error("WARNING: Container not on the ship.");
        Containers[index] = newContainer;
    }

    public void SwapContainer(Container first, Container second)
    {
        if (!Containers.Contains(first))
        {
            throw new Error($"WARNING: The container {first.serialNumber} is not on the ship {Name}.");
        }
        RemoveContainer(first);
        AddContainer(second);
    }

    public void TransferContainer(Container transferContainer, Ship transferShip)
    { RemoveContainer(transferContainer);
        transferShip.AddContainer(transferContainer); }

    
    
    public void ShipInfo()
    {
        Console.WriteLine($"Ship: {Name}");
        Console.WriteLine($"Max Speed: {MaxSpeed} knots");
        Console.WriteLine($"Max Containers Count: {MaxContainerCount}");
        Console.WriteLine($"Max Weight: {MaxWeightCapacity} t");
        Console.WriteLine($"Container Count: {Containers.Count}");
        Console.WriteLine($"Containers:");

        foreach (var container in Containers)
        { Console.WriteLine($"{container.serialNumber}: {container.loadWeight} kg"); }
    }
    
}
public class Error : Exception
{
    public Error(string message) : base(message)
    {
    }
}