namespace Godsgifts;

public class Offering
{
    private OfferingTypes _type;
    private string _name;
    private float _price;

    public Offering(int type, string name, float price)
    {
        _type = (OfferingTypes)type;
        _name = name;
        _price = price;
    }

    public string GetName()
    {
        return _name;
    }

    public float GetValue()
    {
        return _price;
    }

    public OfferingTypes GetType()
    {
        return _type;
    }

    public override string ToString()
    {
        
        return (GetName() + " is a tremendous offering which type is " + _type +" and its value is  " + GetValue());
    }
    
    
}

public enum OfferingTypes
{
    Fruits, 
    Humans,
    Wine, 
    Goat, 
    Gold
}