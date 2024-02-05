using System;

namespace VirtualPet
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

    class Pet
    {
        public string Type { get; private set; }
        public string Name { get; private set; }
        public int Hunger { get; private set; } = 5;
        public int Happiness { get; private set; } = 5;
        public int Health { get; private set; } = 5;

        public Pet(string type, string name)
        {
            Type = type;
            Name = name;
        }

        public void Feed()
        {
            Hunger = Math.Max(1, Hunger - 2);
            Health = Math.Min(10, Health + 1);
            Console.WriteLine($"{Name} has been fed. Hunger decreased, health slightly increased.");
        }

        public void Play()
        {
            Happiness = Math.Min(10, Happiness + 2);
            Hunger = Math.Min(10, Hunger + 1);
            Console.WriteLine($"{Name} is happy playing. Happiness increased, hunger slightly increased.");
        }

        public void Rest()
        {
            Health = Math.Min(10, Health + 2);
            Happiness = Math.Max(1, Happiness - 1);
            Console.WriteLine($"{Name} is resting. Health improved, happiness slightly decreased.");
        }

        public void TimePasses()
        {
            Hunger = Math.Min(10, Hunger + 1);
            Happiness = Math.Max(1, Happiness - 1);
            if (Hunger >= 8 || Happiness <= 2)
            {
                Health = Math.Max(1, Health - 1);
                Console.WriteLine($"Warning: {Name} needs care. Health is deteriorating.");
            }
        }

        public void CheckStatus()
        {
            Console.WriteLine($"\n{Name}'s Status: \nHunger: {Hunger}/10 \nHappiness: {Happiness}/10 \nHealth: {Health}/10");
            if (Hunger >= 8) Console.WriteLine("Warning: Hunger is critically high, feed your pet soon.");
            if (Happiness <= 2) Console.WriteLine("Warning: Happiness is critically low, play with your pet.");
            if (Health <= 3) Console.WriteLine("Warning: Health is critically low, ensure your pet is well-fed and happy.");
        }

    }
}
