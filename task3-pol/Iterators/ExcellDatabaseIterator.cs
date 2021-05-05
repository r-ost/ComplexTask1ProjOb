using System;
using System.Collections.Generic;
using Task3.Data;
using Task3.Databases;

namespace Task3.Iterators
{
    public class ExcellDatabaseIterator : IVirusDatabaseIterator
    {
        private readonly ExcellDatabase _excellDatabase;
        private readonly IGenomeDatabaseWrapper _genomeDatabase;

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

        public ExcellDatabaseIterator(ExcellDatabase excellDatabase, IGenomeDatabaseWrapper genomeDatabase)
        {
            _index = -1;
            _excellDatabase = excellDatabase;
            _genomeDatabase = genomeDatabase;

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

            List<GenomeData> genomes = new List<GenomeData>();

            var it = _genomeDatabase.GetDatabaseIterator(); //_genomeDatabaseIterator.Restart();
            while (it.Next())
            {
                if (it.Current.Id.ToString() == _genomeIDs[_index])
                    genomes.Add(it.Current);
            }


            double.TryParse(_deathRates[_index].Replace('.', ','), out var deathRate);
            double.TryParse(_infectionRates[_index].Replace('.', ','), out var infectionRate);

            VirusData virusData = new VirusData
            (
                _names[_index],
                deathRate,
                infectionRate,
                genomes
            );

            _current = virusData;

            return true;
        }
    }
}
