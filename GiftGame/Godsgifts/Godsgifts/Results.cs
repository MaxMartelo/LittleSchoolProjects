using Microsoft.VisualBasic.CompilerServices;

namespace Godsgifts;

public class Results
{
    public Dictionary<Offering, int> _rewards;
    private uint _amount;
    private float _totalValue;
    private string _name;

    
    public Results(string name, Offering[] offerings)
    {
        _name = name;
        _totalValue = 0;
        _amount = 0;
        _rewards = new Dictionary<Offering, int>();
        foreach (var el in offerings)
        {
            _rewards.Add(el,0);
        }
    }

    public Dictionary<Offering, int> GetRewards()
    {
        return _rewards;
    }
    

    public void ReceiveOffering(Offering offering)
    {
        _rewards[offering] += 1;
        _totalValue += offering.GetValue();
        _amount += 1;
    }

    public override string ToString()
    {
        int nb_off = 0;
        foreach (int i in _rewards.Values)
        {
            nb_off += i;

        }
        return (_name + " Received " + nb_off +" gifts, worth in total " + _totalValue + ".");
    }

    public static Offering[] InitOfferings(string path, uint size)
    
    {
        if (!File.Exists(path))
            throw new ArgumentException("Invalid File");
        
        Offering[] offerings = new Offering[size]; 
        StreamReader fileToRead = new StreamReader(path);
        string[] copy = File.ReadAllLines(path);
        int maxSize = copy.Length / 3;
        if (size > maxSize)
            throw new ArgumentException("The size maximum is " + maxSize);
        
        fileToRead.Close();
        int x = 0;
        for (int i = 0; i <  size * 3; i+=3)
        {
            Offering off = new Offering(Int32.Parse(copy[i]), copy[i+1], float.Parse(copy[i + 2]));
            offerings[x] = off;
            x += 1;
        }
        return offerings;
    }

    public string[] Res(Results results)
    {
        string[] res = new string[results._rewards.Keys.Count];
        int i = 0;
        foreach (Offering offering in results._rewards.Keys)
        {
            res[i] = offering.GetName() + " : " + _rewards[offering];
            i += 1;
        }
        return res;
    }
    
    public static void SaveResults(Results results)
    {
       
        using (StreamWriter logFile = new StreamWriter("log.txt"))
        {
            logFile.WriteLine(results.ToString()); 
            string[] res = results.Res(results);
            foreach (var el in res)
            {
                logFile.WriteLine(el);
            }
        }
    }

    public static void PrintInfo(Results results)
    {
        Console.WriteLine(results.ToString());
        string[] res = results.Res(results);
        foreach (var el in res)
        {
            Console.WriteLine(el);
        }
    }

    public static void PrintRewards(Offering[] offerings)
    {
        foreach (var off in offerings)
        {
            Console.WriteLine("The gift " + off.GetName() + " if of type " + off.GetType() +", and is worth " + off.GetValue());
        }
    }

    public static Offering UpdateResults(Offering[] offerings, ref Results results)
    {
        var rand = new Random();
        int offIndex = rand.Next(offerings.Length);
        Offering offering = offerings[offIndex];
        results.ReceiveOffering(offering);
        Console.WriteLine("You win a " + offering.GetType());
        return offering;
    }
    
    
}