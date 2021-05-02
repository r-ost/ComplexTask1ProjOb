using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task3.Data;
using Task3.Databases;

namespace Task3.Iterators
{
    public class OvercomplicatedDatabaseIterator : IDatabaseIterator
    {
        private SimpleGenomeDatabase _genomeDatabase;
        private Queue<INode> _queue = new Queue<INode>();
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
                                 SimpleGenomeDatabase simpleGenomeDatabase)
        {
            _genomeDatabase = simpleGenomeDatabase;

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

                List<GenomeData> genomes = _genomeDatabase.genomeDatas
                                           .Where(g => g.Tags.Contains(currentNode.GenomeTag))
                                           .ToList();

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
