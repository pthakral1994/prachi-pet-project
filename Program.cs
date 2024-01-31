using Assignment.Animal;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Virtual Pet Simulator!");
            Console.Write("Choose your pet type (Cat, Dog, Rabbit): ");
            string petType = Console.ReadLine()!;
            Console.Write("What's your pet's name? ");
            string petName = Console.ReadLine()!;

            Pet myPet = new Pet(petType, petName);
            Console.WriteLine($"\nWelcome {myPet.Name} the {myPet.Type} to your home!");

            while (true)
            {
                Console.WriteLine("\nChoose an action: \n1. Feed \n2. Play \n3. Rest \n4. Check Status \n5. Exit");
                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        myPet.Feed();
                        break;
                    case "2":
                        myPet.Play();
                        break;
                    case "3":
                        myPet.Rest();
                        break;
                    case "4":
                        myPet.CheckStatus();
                        continue;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid action.");
                        continue;
                }

                myPet.TimePasses();
                myPet.CheckStatus();
            }
        }
    }
}
