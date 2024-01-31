namespace Assignment.Animal
{
    public class Pet
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