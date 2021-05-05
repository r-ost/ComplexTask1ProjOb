using System;
using System.Collections.Generic;
using Task3.Databases;
using Task3.IteratorDecorators;
using Task3.IteratorDecorators.Comparison;
using Task3.IteratorDecorators.Mapping;
using Task3.Iterators;
using Task3.Subjects;
using Task3.Vaccines;

namespace Task3
{
    class Program
    {
        public class MediaOutlet
        {
            public void Publish(IVirusDatabaseIterator it)
            {
                while (it.Next())
                {
                    Console.WriteLine(it.Current);
                }
            }
        }

        public class Tester
        {
            public void Test()
            {
                var vaccines = new List<IVaccine>() { new AvadaVaccine(), new Vaccinator3000(), new ReverseVaccine() };

                foreach (var vaccine in vaccines)
                {
                    Console.WriteLine($"Testing {vaccine}");
                    var subjects = new List<ISubject>();
                    int n = 5;
                    for (int i = 0; i < n; i++)
                    {
                        subjects.Add(new Cat($"{i}"));
                        subjects.Add(new Dog($"{i}"));
                        subjects.Add(new Pig($"{i}"));
                    }

                    foreach (var subject in subjects)
                    {
                        // process of vaccination
                        subject.GetVaccinated(vaccine);
                    }

                    var genomeDatabase = Generators.PrepareGenomes();
                    var simpleDatabase = Generators.PrepareSimpleDatabase(genomeDatabase);
                    // iteration over SimpleGenomeDatabase using solution from 1)
                    // subjects should be tested here using GetTested function

                    var iteratorFactory = new IteratorFactory(new SimpleGenomeDatabaseWrapper(genomeDatabase));

                    // iterating over simpleDatabase
                    var it = iteratorFactory.GetIterator(simpleDatabase);
                    while (it.Next())
                    {
                        foreach (var subject in subjects)
                        {
                            subject.GetTested(it.Current);
                        }
                    }

                    int aliveCount = 0;
                    foreach (var subject in subjects)
                    {
                        if (subject.Alive) aliveCount++;
                    }
                    Console.WriteLine($"{aliveCount} alive!");
                }
            }
        }

        public static void Main(string[] args)
        {
            var genomeDatabase = Generators.PrepareGenomes();
            var simpleDatabase = Generators.PrepareSimpleDatabase(genomeDatabase);
            var excellDatabase = Generators.PrepareExcellDatabase(genomeDatabase);
            var overcomplicatedDatabase = Generators.PrepareOvercomplicatedDatabase(genomeDatabase);
            var mediaOutlet = new MediaOutlet();

            var iteratorFactory = new IteratorFactory(new SimpleGenomeDatabaseWrapper(genomeDatabase));

            // -----------------------------------------------------------------------------
            Console.WriteLine("simple database:\n\n\n");
            mediaOutlet.Publish(iteratorFactory.GetIterator(simpleDatabase));

            Console.WriteLine("\n\n\nexcel database:\n\n\n");
            mediaOutlet.Publish(iteratorFactory.GetIterator(excellDatabase));

            Console.WriteLine("\n\n\novercomplicated database:\n\n\n");
            mediaOutlet.Publish(iteratorFactory.GetIterator(overcomplicatedDatabase));
            // -----------------------------------------------------------------------------



            // -----------------------------------------------------------------------------
            Console.WriteLine("\n\n\nBez filtrow i mapowan:\n");
            var it = iteratorFactory.GetIterator(excellDatabase);
            mediaOutlet.Publish(it);
            Console.WriteLine("\n\n\n");


            Console.WriteLine("pierwszy podpunkt (f => f.DeathRate > 15):\n");
            it = new FilterDecorator(iteratorFactory.GetIterator(excellDatabase),
                                     new DeathRateBiggerThan(15));
            mediaOutlet.Publish(it);
            Console.WriteLine("\n\n\n");



            Console.WriteLine("drugi podpunkt (mapowanie: f => f.DeathRate += 10, filtrowanie: f => f.DeathRate > 15):\n");
            it = new FilterDecorator
                (
                new MapDecorator(iteratorFactory.GetIterator(excellDatabase), new AddToDeathRate(10)),
                new DeathRateBiggerThan(15)
                );
            mediaOutlet.Publish(it);
            Console.WriteLine("\n\n\n");


            Console.WriteLine("trzeci podpunkt (konkatenacja ExcellDatabase i OvercomplicatedDatabase):\n");
            it = new ConcatenateDecorator(iteratorFactory.GetIterator(excellDatabase),
                iteratorFactory.GetIterator(overcomplicatedDatabase));
            mediaOutlet.Publish(it);
            Console.WriteLine("\n\n\n");
            // -----------------------------------------------------------------------------



            // testing animals
            var tester = new Tester();
            tester.Test();
        }
    }
}
