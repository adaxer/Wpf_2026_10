namespace M01_Grundlagen;

public class Customer
{
    public string Name { get; set; }

    public string City { get; set; }

    public override string ToString()=> $"Customer {Name} from {City}";
}
