using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task3.Iterators
{
    public class SimpleDatabaseIterator : IDatabaseIterator
    {
        private IEnumerator<SimpleDatabaseRow> _enumerator;
        private SimpleGenomeDatabase _genomeDatabase;
        private VirusData _current;

        public VirusData Current { get => _current; }

        public SimpleDatabaseIterator(SimpleDatabase simpleDatabase, SimpleGenomeDatabase genomeDatabase)
        {
            _enumerator = simpleDatabase.Rows.GetEnumerator();
            _genomeDatabase = genomeDatabase;
            _current = null;
        }


        public bool Next()
        {
            if (_enumerator.MoveNext() == false)
                return false;

            SimpleDatabaseRow currentRow = _enumerator.Current;
            
            var genomes = _genomeDatabase.genomeDatas
                      .Where(g => g.Genome == currentRow.GenomeId.ToString())
                      .ToList();

            VirusData currentRowVirusData = new VirusData
            (
                currentRow.VirusName,
                currentRow.DeathRate,
                currentRow.InfectionRate,
                genomes
            );

            _current = currentRowVirusData;

            return true;
        }
    }
}
