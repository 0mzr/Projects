using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pet_Game
{
    class Pet
    {
        protected int ovfCounter = 3;
    }
    class dragonClass : Pet // dragon
    {
        protected int hunger = 125; public void minusHunger(int x) { hunger -= x; }
        public string returnHunger() { string convertedHunger = Convert.ToString(hunger); return convertedHunger; }
        protected int hapiness = 75; public void minusHapiness(int x) { hapiness -= x; }
        public string returnHapiness() { string convertedHapiness = Convert.ToString(hapiness); return convertedHapiness; }
        protected int clean = 75; public void minusClean(int x) { clean -= x; }
        public string returnClean() { string convertedClean = Convert.ToString(clean); return convertedClean; }
        protected int energy = 125; public void minusEnergy(int x) { energy -= x; }
        public string returnEnergy() { string convertedHunger = Convert.ToString(energy); return convertedHunger; }
        public bool gameEnd()
        {
            if (hunger <= 0 || clean <= 0 || hapiness <= 0 || energy <= 0)
            {
                Console.Clear();
                Console.WriteLine("Game over. Your pet died.");
                Thread.Sleep(11000);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Feed()
        {
            hunger += 20;
            if (ovfCounter < 0)
            {
                Console.WriteLine("Game Over. You overfed your pet.");
            }
            else if (hunger > 100)
            {
                hunger = 100;
                Console.WriteLine($"Try not to overfeed your pet. They will explode if you overfeed him {ovfCounter} more times");
                ovfCounter--;
            }
            else
            {
                Console.WriteLine("You fed your pet. (+20 food)");
            }
        }
        public void Excercise()
        {
            clean -= 10;
            energy -= 20;
            hapiness += 30;
        }
        public void play()
        {
            hapiness += 40;
            energy -= 10;
            if (hapiness > 75)
            {
                hapiness = 75;
            }
        }
        public void wash()
        {
            Console.WriteLine("You washed your pet. (Cleanliness = 100)");
            clean = 100;
        }
        public void sleep()
        {
            Console.WriteLine("You put your pet to sleep. (energy = 100)");
            energy = 100;
        }
    }

    class unicornClass : Pet
    {
        protected int hunger = 100; public void minusHunger(int x) { hunger -= x; }
        public string returnHunger() { string convertedHunger = Convert.ToString(hunger); return convertedHunger; }
        protected int hapiness = 100; public void minusHapiness(int x) { hapiness -= x; }
        public string returnHapiness() { string convertedHapiness = Convert.ToString(hapiness); return convertedHapiness; }
        protected int clean = 100; public void minusClean(int x) { clean -= x; }
        public string returnClean() { string convertedClean = Convert.ToString(clean); return convertedClean; }
        protected int energy = 100; public void minusEnergy(int x) { energy -= x; }
        public string returnEnergy() { string convertedHunger = Convert.ToString(energy); return convertedHunger; }
        public bool gameEnd()
        {
            if (hunger <= 0 || clean <= 0 || hapiness <= 0 || energy <= 0)
            {
                Console.Clear();
                Console.WriteLine("Game over. Your pet died.");
                Thread.Sleep(11000);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Feed()
        {
            hunger += 20;
            if (ovfCounter < 0)
            {
                Console.WriteLine("Game Over. You overfed your pet.");
            }
            else if (hunger > 100)
            {
                hunger = 100;
                Console.WriteLine($"Try not to overfeed your pet. They will explode if you overfeed him {ovfCounter} more times");
                ovfCounter--;
            }
            else
            {
                Console.WriteLine("You fed your pet. (+20 food)");
            }
        }

        public void Excercise()
        {
            clean -= 10;
            energy -= 20;
            hapiness += 30;
        }
        public void play()
        {
            if (hapiness == 100)
            {
                hapiness -= 15;
            }
            hapiness += 15;
        }
        public void wash()
        {
            Console.WriteLine("You washed your pet. (Cleanliness = 100)");
            clean = 100;
        }
        public void sleep()
        {
            energy = 100;
        }
    }

    class phoenixClass : Pet
    {
        protected int hunger = 75; public void minusHunger(int x) { hunger -= x; }
        public string returnHunger() { string convertedHunger = Convert.ToString(hunger); return convertedHunger; }
        protected int hapiness = 125; public void minusHapiness(int x) { hapiness -= x; }
        public string returnHapiness() { string convertedHapiness = Convert.ToString(hapiness); return convertedHapiness; }
        protected int clean = 125; public void minusClean(int x) { clean -= x; }
        public string returnClean() { string convertedClean = Convert.ToString(clean); return convertedClean; }
        protected int energy = 75; public void minusEnergy(int x) { energy -= x; }
        public string returnEnergy() { string convertedHunger = Convert.ToString(energy); return convertedHunger; }
        public bool gameEnd()
        {
            if (hunger <= 0 || clean <= 0 || hapiness <= 0 || energy <= 0)
            {
                Console.Clear();
                Console.WriteLine("Game over. Your pet died.");
                Thread.Sleep(11000);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Feed()
        {
            hunger += 20;
            if (ovfCounter < 0)
            {
                Console.WriteLine("Game Over. You overfed your pet.");
            }
            else if (hunger > 100)
            {
                hunger = 100;
                Console.WriteLine($"Try not to overfeed your pet. They will explode if you overfeed him {ovfCounter} more times");
                ovfCounter--;
            }
            else
            {
                Console.WriteLine("You fed your pet. (+20 food)");
            }
        }
        public void Excercise()
        {
            clean -= 10;
            energy -= 20;
            hapiness += 30;
        }
        public void play()
        {
            if (hapiness == 100)
            {
                hapiness -= 15;
            }
            hapiness += 15;
        }
        public void wash()
        {
            Console.WriteLine("You washed your pet. (Cleanliness = 100)");
            clean = 100;
        }
        public void sleep()
        {
            energy = 100;
        }   
    }
}