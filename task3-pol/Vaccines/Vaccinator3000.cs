using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class Vaccinator3000 : IVaccine
    {
        public string Immunity => "ACTG";
        public double DeathRate => 0.1f;

        private Random randomElement = new Random(0);

        private string Vaccinate(int drawsCount)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < drawsCount; i++)
                sb.Append(Immunity[randomElement.Next(Immunity.Length)]);

            return sb.ToString();
        }

        public void VaccinateSubject(Dog dog)
        {
            dog.Immunity = Vaccinate(3000);

            if (randomElement.NextDouble() < DeathRate)
            {
                dog.Alive = false;
                Console.WriteLine($"Dog {dog.ID} is dead by vaccination.");

            }
        }

        public void VaccinateSubject(Cat cat)
        {
            cat.Immunity = Vaccinate(300);
            
            if (randomElement.NextDouble() < DeathRate)
            {
                cat.Alive = false;
                Console.WriteLine($"Cat {cat.ID} is dead by vaccination.");
            }
        }

        public void VaccinateSubject(Pig pig)
        {
            pig.Immunity = Vaccinate(15);
            
            if (randomElement.NextDouble() < 3 * DeathRate)
            {
                pig.Alive = false;
                Console.WriteLine($"Pig {pig.ID} is dead by vaccination.");
            }
        }


        public override string ToString()
        {
            return "Vaccinator3000";
        }
    }
}
