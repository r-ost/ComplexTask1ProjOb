using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Task3.Data;
using Task3.Databases;

namespace Task3.Iterators
{
    public class SimpleDatabaseIterator : IDatabaseIterator
    {
        private IEnumerator<SimpleDatabaseRow> _enumerator;
        private SimpleGenomeDatabase _genomeDatabase;
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
                          .Where(g => g.Id == currentRow.GenomeId)
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
