using System;
using System.Collections.Generic;
using System.Linq;
using Task3.Data;
using Task3.Databases;

namespace Task3.Iterators
{
    public class OvercomplicatedDatabaseIterator : IVirusDatabaseIterator
    {
        private readonly IGenomeDatabaseWrapper _genomeDatabaseWrapper;
        private readonly Queue<INode> _queue = new Queue<INode>();
        private VirusData _current;

        public VirusData Current 
        {
            get
            {
                if (_current == null)
                    throw new InvalidOperationException();
                return _current;
            }
        }


        public OvercomplicatedDatabaseIterator(OvercomplicatedDatabase overcomplicatedDatabase,
            IGenomeDatabaseWrapper genomeDatabaseWrapper)
        {
            _genomeDatabaseWrapper = genomeDatabaseWrapper;

            _current = null;
            _queue.Enqueue(overcomplicatedDatabase.Root);
        }

        public bool Next()
        {
            if (_queue.Count != 0)
            {
                INode currentNode = _queue.Dequeue();

                foreach (var child in currentNode.Children)
                {
                    _queue.Enqueue(child);
                }

                List<GenomeData> genomes = new List<GenomeData>();


                var it = _genomeDatabaseWrapper.GetDatabaseIterator();
                //_genomeDatabaseIterator.Restart();
                while (it.Next())
                {
                    if (it.Current.Tags.Contains(currentNode.GenomeTag))
                    {
                        genomes.Add(it.Current);
                    }
                }

                VirusData virusData = new VirusData
                (
                    currentNode.VirusName,
                    currentNode.DeathRate,
                    currentNode.InfectionRate,
                    genomes
                );

                _current = virusData;

                return true;
            }
            else
                return false;
        }
    }
}
