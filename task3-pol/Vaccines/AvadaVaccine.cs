using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class AvadaVaccine : IVaccine
    {
        public string Immunity => "ACTAGAACTAGGAGACCA";

        public double DeathRate => 0.2f;
        
        private Random randomElement = new Random(0);

        public void VaccinateSubject(Dog dog)
        {
            dog.Immunity = Immunity;
        }

        public void VaccinateSubject(Cat cat)
        {
            if (randomElement.NextDouble() < DeathRate) // umiera
            {
                cat.Alive = false;
                Console.WriteLine($"Cat {cat.ID} is dead by vaccination.");
                return;
            }

            cat.Immunity = Immunity.Substring(3);
        }

        public void VaccinateSubject(Pig pig)
        {
            pig.Alive = false;
            Console.WriteLine($"Pig {pig.ID} is dead by vaccination.");
        }


        public override string ToString()
        {
            return "AvadaVaccine";
        }
    }
}
