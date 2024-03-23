using APBD_3.Interface;

namespace APBD_3.Models;

public class GasContainer : Container,IHazardNotifier
{
    private double _cisnienie;

    public GasContainer(double wagaWlasna, double wysokoscKontenera, double glebokoscKontenera,double maksymalnaLadownosc, LoadType acceptableType, double cisnienie) 
        : base(wagaWlasna,wysokoscKontenera,glebokoscKontenera,maksymalnaLadownosc,acceptableType)
    {
        GenerateContainerSerialNumber("G");
        _cisnienie = cisnienie;
    }

    public void HazardousNotification()
    {
        Console.WriteLine( "Niebezpieczna sytuacja z kontenerem - "+NumerSeryjny);
    }
    public override void EmptyContainer()
    {
        base.MasaLadunku *= 0.05;
    }

    public override void LoadContainer(Load load)
    {
        if (load.LoadCategory!=LoadCategory.GAS)
        {
            Console.WriteLine("Bledny ladunek, ten kontener przyjmuje jedynie produkty w postaci gazu");
        }
        else
        {
            if ( load.LoadType != AcceptableType ||
                load.LoadCategory != LoadCategory.GAS || MasaLadunku!=0) 
            {
                HazardousNotification();
            }
            else
            {
                base.LoadContainer(load);
            }    
        }
        
    }

    public override string ToString()
    {
        return base.ToString() + " | Cisnienie:"+_cisnienie+" atmosfer";
    }
}