using Task3.Iterators;

namespace Task3.Databases
{
    public class SimpleGenomeDatabaseWrapper : IGenomeDatabaseWrapper
    {
        private readonly SimpleGenomeDatabase _genomeDatabase;

        public SimpleGenomeDatabaseWrapper(SimpleGenomeDatabase genomeDatabase)
        {
            _genomeDatabase = genomeDatabase;
        }

        public IGenomeDatabaseIterator GetDatabaseIterator()
        {
            return new SimpleGenomeDatabaseIterator(_genomeDatabase);
        }
    }
}