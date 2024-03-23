namespace APBD_3.Models;

public class ContainerShip
{
    private double _speed;
    public List<Container> LoadedContainers;
    private int _maxContainerAmount;
    // tony
    private double _maxContainerWeight;
    public string ShipName;

    
    public ContainerShip(string shipName, double speed, int maxContainerAmount, double maxContainerWeight)
    {
        ShipName = shipName;
        LoadedContainers = new List<Container>();
        _speed = speed;
        _maxContainerAmount = maxContainerAmount;
        _maxContainerWeight = maxContainerWeight;
    }

    public bool LoadContainerOnShip(Container container)
    {
        double currentContainerWeight=0;
        foreach (Container cont in LoadedContainers)
        {
            currentContainerWeight += cont.MasaLadunku + cont.WagaWlasna;
        }

        double updatedContainerWeight = currentContainerWeight + container.MasaLadunku+container.WagaWlasna;
        if (LoadedContainers.Count() + 1> _maxContainerAmount)
        {
            Console.WriteLine("Ten statek nie moze zmiescic wiecej kontenerow");
            return false;
        }
        if ( updatedContainerWeight>=(_maxContainerWeight*1000))
        {
            Console.WriteLine("Ten kontener jest za ciezki zeby go zaladowac");
            return false;
        }
        LoadedContainers.Add(container);
        
        return true;
    }
    public bool LoadContainerOnShip(List<Container> containerList)
    {
        double currentContainerOnShipWeight=0;
        foreach (Container cont in LoadedContainers)
        {
            currentContainerOnShipWeight += cont.MasaLadunku;
        }

        double containerListWeight = 0;
        foreach (Container cont in containerList)
        {
            containerListWeight += cont.MasaLadunku;
        }
        
        double updatedContainerWeight = currentContainerOnShipWeight + containerListWeight;
        if (LoadedContainers.Count + containerList.Count > _maxContainerAmount)
        {
            Console.WriteLine("Ten statek nie moze zmiescic wiecej kontenerow");
            return false;
        } 
        if ( updatedContainerWeight>=(_maxContainerWeight*1000))
        {
            Console.WriteLine("Te kontenery sa za ciezkie");
            return false;
        }
            foreach (Container cont in containerList)
            {
                LoadedContainers.Add(cont);

            }

            return true;
    }

    public Container UnloadContainer(string containerId)
    {
        Container unloadedContainer = LoadedContainers.Find(cont => cont.NumerSeryjny == containerId);
        LoadedContainers.Remove(unloadedContainer);
        return unloadedContainer;
    }

    
   public void ReplaceContainer(string containerId, Container addedContainer)
   {
       
       Container replacedContainer = LoadedContainers.Find(cont => cont.NumerSeryjny == containerId);
       if (replacedContainer != null)
       {
           bool replaceContainerSuccess=LoadContainerOnShip(addedContainer);
           if (replaceContainerSuccess)
           {
               LoadedContainers.Remove(replacedContainer);
           }
       }
       else
       {
           Console.WriteLine("Nie odnaleziono kontenera!");
       }
   }

   public void MoveContainerToOtherShip(string containerId, ContainerShip containerShip)
   {
       Container containerToBeMoved = LoadedContainers.Find(cont => cont.NumerSeryjny == containerId);
           if (containerToBeMoved!=null)
           {
               bool loadedSuccessfuly=containerShip.LoadContainerOnShip(containerToBeMoved);
               if (loadedSuccessfuly)
               {
                   LoadedContainers.Remove(containerToBeMoved);
               }
           }
           else
           {
               Console.WriteLine("Blad, kontener o takim ID nie zostal odnaleziony");

           }
   }
   

    public void DisplayCargo()
    {
        Console.WriteLine("Zaladowane kontenery:");
        if (LoadedContainers.Count() > 0)
        {
            foreach (var container in LoadedContainers)
            {
                Console.WriteLine(container);   
            }    
        }
        else
        {
            Console.WriteLine("Statek jest pusty");
        }


    }

    public override string ToString()
    {
        return "Nazwa:" + ShipName + "| Prędkość:" + _speed + " wezłów" + "| Maksymalna liczba kontenerow:" +
               _maxContainerAmount + "| Maksymalna waga kontenerów:" + _maxContainerWeight+"ton";
    }
    
    
}