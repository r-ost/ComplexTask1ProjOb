using System;
using System.Collections.Generic;
using Task3.Data;
using Task3.Databases;

namespace Task3.Iterators
{
    public class SimpleGenomeDatabaseIterator : IGenomeDatabaseIterator
    {
        private readonly IEnumerator<GenomeData> _enumerator;
        private GenomeData _current;

        public GenomeData Current
        {
            get
            {
                if (_current == null)
                    throw new InvalidOperationException();
                return _current;
            }
        }


        public SimpleGenomeDatabaseIterator(SimpleGenomeDatabase database)
        {
            _enumerator = database.genomeDatas.GetEnumerator();
        }

        public bool Next()
        {
            if (_enumerator.MoveNext() == false)
                return false;


            _current = _enumerator.Current;

            return true;
        }
    }
}