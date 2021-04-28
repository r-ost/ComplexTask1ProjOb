using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3.Iterators
{
    public class ExcellDatabaseIterator : IDatabaseIterator
    {
        private ExcellDatabase _excellDatabase;
        private SimpleGenomeDatabase _genomeDatabase;
        private string[] _names;
        private string[] _deathRates;
        private string[] _infectionRates;
        private string[] _genomeIDs;

        private VirusData _current;
        private int _index;

        public VirusData Current
        {
            get
            {
                if (_index == -1)
                {
                    throw new InvalidOperationException();
                }
                return _current;
            }
        }

        public ExcellDatabaseIterator(ExcellDatabase excellDatabase, SimpleGenomeDatabase simpleGenomeDatabase)
        {
            _index = -1;

            InitializeRows();
        }

        private void InitializeRows()
        {
            _names = _excellDatabase.Names.Split(";");
            _deathRates = _excellDatabase.DeathRates.Split(";");
            _infectionRates = _excellDatabase.InfectionRates.Split(";");
            _genomeIDs = _excellDatabase.GenomeIds.Split(";");

            int length = _names.Length;
            if (_deathRates.Length != length || _infectionRates.Length != length ||
                _genomeIDs.Length != length)
            {
                throw new ArgumentException("Database strings are not the same length.");
            }
        }

        public bool Next()
        {
            _index++;

            if (_index >= _names.Length)
                return false;

            List<GenomeData> genomes = _genomeDatabase.genomeDatas
                                       .Where(g => g.Id.ToString() == _genomeIDs[_index])
                                       .ToList();

            VirusData virusData = new VirusData
            (
                _names[_index],
                double.Parse(_deathRates[_index]),
                double.Parse(_infectionRates[_index]),
                genomes
            );

            _current = virusData;

            return true;
        }
    }
}
