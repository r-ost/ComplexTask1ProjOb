using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    interface IVaccine
    {
        public string Immunity { get; }
        public double DeathRate { get; }
        public void VaccinateSubject(Dog dog);
        public void VaccinateSubject(Cat cat);
        public void VaccinateSubject(Pig pig);
    }
}
