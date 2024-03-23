using APBD_3;
using APBD_3.Models;

public class Program
{
    public static void Main(string[] args)
    {
        Container coolerContainer1 = new CoolerContainer(1000, 123, 432, 100000, 5, LoadType.SAFE);
        Container liquidContainer1 = new LiquidContainer(123, 123, 432, 1000, LoadType.SAFE);
        Container coolerContainer2 =new CoolerContainer(1234, 123, 432, 1000, 5, LoadType.SAFE);
        Container gasContainer1 = new GasContainer(1234, 123, 432, 1000, LoadType.SAFE,30);
        
        List<Container> containersList = new List<Container>();
        containersList.Add(coolerContainer2);
        containersList.Add(gasContainer1);
        PrintContainers(containersList);
        
        
        ContainerShip ship1 =   new ContainerShip("Statek-1",100,30,300);
        Console.WriteLine(ship1);
        
        
        coolerContainer1.LoadContainer(new Load("Cebula",99000,LoadType.SAFE,LoadCategory.FROZEN,6));
        liquidContainer1.LoadContainer(new Load("Muszynianka", 899, LoadType.SAFE, LoadCategory.LIQUID));
        gasContainer1.LoadContainer(new Load("Hel",500,LoadType.SAFE,LoadCategory.GAS));
        PrintContainers(containersList);
        Console.WriteLine(gasContainer1);
        
        
        Console.WriteLine("\n\n===========================Zaladowanie kontenera na statek===========================");
        ship1.LoadContainerOnShip(coolerContainer1);
        ship1.LoadContainerOnShip(liquidContainer1);
        ship1.LoadContainerOnShip(containersList);
        ship1.DisplayCargo();
        
        Console.WriteLine("\n\n===========================Usuniecie kontenera ze statku===========================");
        ship1.UnloadContainer("KON-C-3");
        ship1.DisplayCargo();
        
        Console.WriteLine("\n\n===========================Rozladowanie kontenera===========================");
        Container container = new GasContainer(1000, 250, 800, 5000, LoadType.SAFE,15);
        container.LoadContainer(new Load("Gaz 1",3000,LoadType.SAFE,LoadCategory.GAS));
        Console.WriteLine(container);
        container.EmptyContainer();
        Console.WriteLine(container);
        
        Console.WriteLine("\n\n===========================Zastapienie kontenera innym kontenerem===========================");
        ship1.DisplayCargo();
        ship1.ReplaceContainer("KON-G-4",container);
        ship1.DisplayCargo();
        
        Console.WriteLine("\n\n===========================Przeniesienie konterena miedzy statkami===========================");
        ContainerShip ship2 = new ContainerShip("Statek-2", 60, 300, 600);
        ship1.MoveContainerToOtherShip("KON-L-2",ship2);
        Console.WriteLine("Statek-1:");
        ship1.DisplayCargo();
        Console.WriteLine("Statek-2:");
        ship2.DisplayCargo();

        
        Console.WriteLine(ship1);
        Console.WriteLine(ship2);
    }

    public static void PrintShips(List<ContainerShip> containerShips)
    {
        Console.WriteLine("Lista kontenerowcow:");
        if (containerShips.Count() == 0)
        {
            Console.WriteLine("Brak");
        }
        else
        {
            int i = 0;
            foreach (var ship in containerShips)
            {
                i++;
                Console.WriteLine(i+". "+ship);
            }
        }
    }

    public static void PrintContainers(List<Container> containersList)
    {
        Console.WriteLine("Lista kontenerow:");
        if (containersList.Count() == 0)
        {
            Console.WriteLine("Brak");
        }
        else
        {
            int i = 0;
            foreach (var ContainerItem in containersList)
            {
                i++;
                Console.WriteLine(i+". "+ContainerItem);
            }
        } 
    }

    public static void PrintProducts(List<Load> loadList)
    {
        Console.WriteLine("Lista produktow:");
        if (loadList.Count() == 0)
        {
            Console.WriteLine("Brak");
        }
        else
        {
            int i = 0;
            foreach (var ContainerItem in loadList)
            {
                i++;
                Console.WriteLine(i+". "+ContainerItem);
            }
        } 
    }

}