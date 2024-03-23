namespace APBD_3.Models;

public class Load
{
    public string Name { get; }
    public LoadType LoadType { get; }
    public LoadCategory LoadCategory { get; }
    public double LoadWeight { get; }
    public double? MinTemp { get; set; }
    
    public Load(string name, double loadWeight, LoadType loadType, LoadCategory loadCategory) : this(name, loadWeight, loadType, loadCategory, null)
    {
    }

    public Load(string name, double loadWeight, LoadType loadType, LoadCategory loadCategory, double? minTemp)
    {
        Name = name;
        LoadWeight = loadWeight;
        LoadType = loadType;
        LoadCategory = loadCategory;
        MinTemp = minTemp;
    }
    
}