using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class ReverseVaccine : IVaccine
    {
        public string Immunity => "ACTGAGACAT";

        public double DeathRate => 0.05f;

        private Random randomElement = new Random(0);

        private double _deathChance = 0;

        public void VaccinateSubject(Dog dog)
        {
            char[] tempChars = Immunity.ToCharArray();
            Array.Reverse(tempChars);

            dog.Immunity = tempChars.ToString();
        }

        public void VaccinateSubject(Cat cat)
        {
            cat.Alive = false;
            Console.WriteLine($"Cat {cat.ID} is dead by vaccination.");
        }

        public void VaccinateSubject(Pig pig)
        {
            char[] tempChars = Immunity.ToCharArray();
            Array.Reverse(tempChars);
            pig.Immunity = Immunity + tempChars.ToString();
            _deathChance += DeathRate;

            if (randomElement.NextDouble() < _deathChance)
            {
                pig.Alive = false;
                Console.WriteLine($"Pig {pig.ID} is dead by vaccination.");
            }
        }



        public override string ToString()
        {
            return "ReverseVaccine";
        }
    }
}
