using System;

namespace VirtualPet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Virtual Pet!");

            Console.WriteLine("Choose a pet type (cat, dog, rabbit): ");
            string petType = Console.ReadLine()!;
            Console.WriteLine("Enter a name for your pet: ");
            string petName = Console.ReadLine()!;

            Pet myPet = new Pet(petType, petName);

            Console.WriteLine($"Congratulations! You have a new {myPet.PetType} named {myPet.PetName}.");

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Feed");
                Console.WriteLine("2. Play");
                Console.WriteLine("3. Rest");
                Console.WriteLine("4. Check pet status");
                Console.WriteLine("5. Exit");

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
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                myPet.PassTime();

                if (myPet.Health <= 2)
                {
                    Console.WriteLine($"{myPet.PetName} is very sick. Take it to the vet!");
                }

                if (myPet.Hunger <= 2)
                {
                    Console.WriteLine($"{myPet.PetName} is starving. Feed it immediately!");
                }

                if (myPet.Happiness <= 2)
                {
                    Console.WriteLine($"{myPet.PetName} is very unhappy. Spend time with it!");
                }

                if (myPet.Hunger >= 8 || myPet.Happiness >= 8)
                {
                    Console.WriteLine($"{myPet.PetName} is too full or too happy. Be careful!");
                }
            }
        }
    }

    class Pet
    {
        public string PetType { get; }
        public string PetName { get; }
        public int Hunger { get; private set; }
        public int Happiness { get; private set; }
        public int Health { get; private set; }

        public Pet(string type, string name)
        {
            PetType = type;
            PetName = name;
            Hunger = 5;
            Happiness = 5;
            Health = 5;
        }

        public void Feed()
        {
            Hunger -= 2;
            Health++;
            Console.WriteLine($"{PetName} is fed. Hunger decreased, and health improved.");
        }

        public void Play()
        {
            if (Hunger >= 3)
            {
                Happiness += 2;
                Hunger += 1;
                Console.WriteLine($"{PetName} is playing. Happiness increased, but hunger also increased.");
            }
            else
            {
                Console.WriteLine($"{PetName} is too hungry to play. Feed it first!");
            }
        }

        public void Rest()
        {
            Health++;
            Happiness--;
            Console.WriteLine($"{PetName} is resting. Health improved, but happiness decreased.");
        }

        public void CheckStatus()
        {
            Console.WriteLine($"{PetName}'s Status:");
            Console.WriteLine($"Hunger: {Hunger}/10");
            Console.WriteLine($"Happiness: {Happiness}/10");
            Console.WriteLine($"Health: {Health}/10");

            if (Hunger <= 2 || Happiness <= 2 || Health <= 2)
            {
                Console.WriteLine("Warning: Some stats are critically low!");
            }
            else if (Hunger >= 8 || Happiness >= 8 || Health >= 8)
            {
                Console.WriteLine("Warning: Some stats are very high!");
            }
        }

        public void PassTime()
        {
            Hunger++;
            Happiness--;
            Console.WriteLine("Time passes. Hunger increased, and happiness decreased.");
        }
    }
}