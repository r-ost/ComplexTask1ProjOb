using System;
using System.Collections.Generic;
using System.Text;
using Task3.Databases;

namespace Task3.Iterators
{
    public class IteratorFactory
    {
        private SimpleGenomeDatabase _genomeDatabase;
        public IteratorFactory(SimpleGenomeDatabase genomeDatabase)
        {
            _genomeDatabase = genomeDatabase;
        }

        public IDatabaseIterator GetIterator(ExcellDatabase database)
        {
            return new ExcellDatabaseIterator(database, _genomeDatabase);
        }

        public IDatabaseIterator GetIterator(SimpleDatabase database)
        {
            return new SimpleDatabaseIterator(database, _genomeDatabase);
        }

        public IDatabaseIterator GetIterator(OvercomplicatedDatabase database)
        {
            return new OvercomplicatedDatabaseIterator(database, _genomeDatabase);
        }
    }
}
