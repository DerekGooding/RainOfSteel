using RainOfSteel.Extensions;
using RainOfSteel.Model;

namespace RainOfSteel;

public class GameUI
{
    private readonly List<Mech> _mechs = [];

    public void Start()
    {
        Console.WriteLine("Welcome to Rain of Steel!");
        while (true)
        {
            Console.WriteLine("1. Create a new Mech");
            Console.WriteLine("2. Customize a Mech");
            Console.WriteLine("3. View Mech Stats");
            Console.WriteLine("4. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    CreateMech();
                    break;
                case "2":
                    CustomizeMech();
                    break;
                case "3":
                    ViewMechStats();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void CreateMech()
    {
        Console.WriteLine("Enter the name of the new Mech:");
        string name = Console.ReadLine() ?? "Unnamed Mech";

        Mech mech = new(name);
        _mechs.Add(mech);
        Console.WriteLine($"Mech {name} created!");
    }

    private void CustomizeMech()
    {
        Mech? mech = SelectMech();
        if (mech == null) return;

        Console.WriteLine("Enter the name of the new Component:");
        string componentName = Console.ReadLine() ?? "Unnamed Component";
        Console.WriteLine("Enter the damage of the Component:");
        int damage = Console.ReadLine().ValidateInt();
        Console.WriteLine("Enter the weight of the Component:");
        int weight = Console.ReadLine().ValidateInt();
        Console.WriteLine("Enter the energy consumption of the Component:");
        int energyConsumption = Console.ReadLine().ValidateInt();

        Component component = new(componentName, damage, weight, energyConsumption);
        mech.AddComponent(component);
        Console.WriteLine($"Component {componentName} added to {mech.Name}!");
    }

    private void ViewMechStats()
    {
        Mech? mech = SelectMech();
        if (mech == null) return;

        mech.DisplayStats();
    }

    private Mech? SelectMech()
    {
        if (_mechs.Count == 0)
        {
            Console.WriteLine("No mechs available.");
            return null;
        }

        Console.WriteLine("Select a Mech:");
        for (int i = 0; i < _mechs.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_mechs[i].Name}");
        }

        int index = Console.ReadLine().ValidateInt() - 1;
        if (index < 0 || index >= _mechs.Count)
        {
            Console.WriteLine("Invalid selection. Please try again.");
            return null;
        }

        return _mechs[index];
    }
}