using System.Transactions;
using APBD_3.Interface;

namespace APBD_3.Models;

public class LiquidContainer : Container, IHazardNotifier
{

    public LiquidContainer(double wagaWlasna, double wysokoscKontenera, double glebokoscKontenera, double maksymalnaLadownosc, LoadType acceptableType) 
        : base(wagaWlasna,wysokoscKontenera,glebokoscKontenera,maksymalnaLadownosc,acceptableType)
    {
       GenerateContainerSerialNumber("L");
    }
    public void HazardousNotification()
    {
        Console.WriteLine( "Niebezpieczna sytuacja z kontenerem - "+NumerSeryjny);
    }
    public override void LoadContainer(Load load)
    {
        
        if (load.LoadCategory!=LoadCategory.LIQUID)
        {
            Console.WriteLine("Bledny ladunek, ten kontener przyjmuje jedynie produkty w postaci cieczy");
        }
        else
        {
            double stosunekMasyDoMaxLadownosci = ((MasaLadunku + load.LoadWeight) / MaksymalnaLadownosc);
            if ( (stosunekMasyDoMaxLadownosci > 0.9 && load.LoadType == LoadType.SAFE) || (stosunekMasyDoMaxLadownosci > 0.5 && load.LoadType == LoadType.DANGEROUS))
            {
                HazardousNotification();
            }else if (load.LoadType!=AcceptableType )
            {
                HazardousNotification();
            }
            else
            {
                base.LoadContainer(load);
                
            }
        }
        
    }
    
}