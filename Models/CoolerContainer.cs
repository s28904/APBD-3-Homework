using APBD_3.Interface;

namespace APBD_3.Models;

public class CoolerContainer : Container
{
    public double TempInContainer;
    public CoolerContainer(double wagaWlasna, double wysokoscKontenera, double glebokoscKontenera,double maksymalnaLadownosc, double tempInContainer, LoadType acceptableType) 
        : base(wagaWlasna,wysokoscKontenera,glebokoscKontenera,maksymalnaLadownosc,acceptableType)
    {
        TempInContainer = tempInContainer;
        GenerateContainerSerialNumber("C");
    }

    
    public override void LoadContainer(Load load)
    {
        if (load.LoadCategory!=LoadCategory.FROZEN)
        {
            Console.WriteLine("Bledny ladunek, ten kontener przyjmuje jedynie produkty chlodzone");
        }
        else
        {
            if (load.MinTemp != null)
            {
                if (load.MinTemp < TempInContainer || load.LoadType != AcceptableType)
                {
                    Console.WriteLine("Temperatura lub typ produktu nie spelnia wymagan, przerywanie operacji zaladunku");
                }
                else
                {
                    base.LoadContainer(load);
                }
            }
            else
            {
                Console.WriteLine("Minimalna temperatura nie zostala podana, przerywany zaladunek");
            }
        }
    }

    public override string ToString()
    {
        return base.ToString() + " | Temperatura:"+TempInContainer+" stopni";
    }
}