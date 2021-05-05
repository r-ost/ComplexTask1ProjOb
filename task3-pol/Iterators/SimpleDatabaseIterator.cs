using System;
using System.Collections.Generic;
using Task3.Data;
using Task3.Databases;

namespace Task3.Iterators
{
    public class SimpleDatabaseIterator : IVirusDatabaseIterator
    {
        private readonly IEnumerator<SimpleDatabaseRow> _enumerator;
        private readonly IGenomeDatabaseWrapper _genomeDatabaseWrapper;
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

        public SimpleDatabaseIterator(SimpleDatabase simpleDatabase, IGenomeDatabaseWrapper genomeDatabaseWrapper)
        {
            _enumerator = simpleDatabase.Rows.GetEnumerator();
            _genomeDatabaseWrapper = genomeDatabaseWrapper;

            _current = null;
        }


        public bool Next()
        {
            if (_enumerator.MoveNext() == false)
                return false;

            SimpleDatabaseRow currentRow = _enumerator.Current;

            List<GenomeData> genomes = new List<GenomeData>();


            var it = _genomeDatabaseWrapper.GetDatabaseIterator();
            //_genomeDatabaseIterator.Restart();
            while (it.Next())
            {
                if (currentRow != null && it.Current.Id == currentRow.GenomeId)
                {
                    genomes.Add(it.Current);
                }
            }
            
            //var genomes = _genomeDatabase.genomeDatas
            //              .Where(g => g.Id == currentRow.GenomeId)
            //              .ToList();

            if (currentRow != null)
            {
                VirusData currentRowVirusData = new VirusData
                (
                    currentRow.VirusName,
                    currentRow.DeathRate,
                    currentRow.InfectionRate,
                    genomes
                );

                _current = currentRowVirusData;
            }

            return true;
        }
    }
}
