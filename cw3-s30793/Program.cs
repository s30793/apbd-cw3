namespace cw3_s30793;

class Program
{
    public static void Main()
    {
        Ship ship1 = new Ship("CargoShip1", 20,3, 600);
        Ship ship2 = new Ship("CargoShip2", 10, 5,400);

        LiquidContainer liquid = new LiquidContainer(true) { maxLoad = 1000 };
        GasContainer gas = new GasContainer(10) { maxLoad = 800 };
        RefrigeratedContainer refridgerated = new RefrigeratedContainer("Meat") { maxLoad = 500 };

        liquid.Load(300);
        gas.Load(400);
        refridgerated.Load(400);

        ship1.AddContainer(liquid);
        ship2.AddContainer(gas);
        ship1.AddContainer(refridgerated);
        ship2.SwapContainer(gas, liquid);
        ship1.ReplaceContainer("KON-L-1", gas);
        
        
        ship1.ShipInfo();
        Console.WriteLine();;
        ship2.ShipInfo();
        
        Console.WriteLine("\nThe operation was successful.");
    }
}
