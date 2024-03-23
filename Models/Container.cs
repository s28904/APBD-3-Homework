using APBD_3.Exception;

namespace APBD_3.Models;

public abstract class Container 
{
    // kg
    public double MasaLadunku { get; set; }
    public double WagaWlasna { get; }
    public double MaksymalnaLadownosc { get; }

    // cm
    private double _wysokoscKontenera;
    private double _glebokoscKontenera;

    public string NumerSeryjny { get; set; }

    private static int _kontenerId = 0;
    public LoadType AcceptableType;
    
  
    public Container(double wagaWlasna, double wysokoscKontenera, double glebokoscKontenera, double maksymalnaLadownosc, LoadType acceptableType)
    {
        WagaWlasna = wagaWlasna;
        _wysokoscKontenera = wysokoscKontenera;
        _glebokoscKontenera = glebokoscKontenera;
        MaksymalnaLadownosc = maksymalnaLadownosc;
        AcceptableType = acceptableType;
        _kontenerId++;
    }

    public virtual void EmptyContainer()
    {
        MasaLadunku = 0;
    }

    public void GenerateContainerSerialNumber(string containerType)
    {
        NumerSeryjny = "KON-" + containerType.ToUpper() +"-"+ _kontenerId;
    }

    public virtual void LoadContainer(Load load)
    {
        if (load.LoadWeight > MaksymalnaLadownosc)
        {
            throw new OverfillException("Ladunek za ciezki dla tego kontenera");
        }
        MasaLadunku = load.LoadWeight;
        Console.WriteLine("Ladunek zostal poprawnie zaladowany do kontenera "+NumerSeryjny);
        
    }


    public override string ToString()
    {
        return "Kontener " + NumerSeryjny + ": Masa Ladunku:" + MasaLadunku + "kg" + " | Waga Wlasna:" + WagaWlasna +
               "kg"
               + " | Maksymalna Ladownosc:" + MaksymalnaLadownosc + "kg"
               + " | Wysokosc Kontenera:" + _wysokoscKontenera + "cm"
               + " | Glebokosc Kontenera:" + _glebokoscKontenera + "cm";
    }
}