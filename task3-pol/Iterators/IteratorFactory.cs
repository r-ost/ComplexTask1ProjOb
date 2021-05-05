using Task3.Databases;

namespace Task3.Iterators
{
    public class IteratorFactory
    {
        private readonly IGenomeDatabaseWrapper _genomeDatabaseWrapper;
        public IteratorFactory(IGenomeDatabaseWrapper genomeDatabaseWrapper)
        {
            _genomeDatabaseWrapper = genomeDatabaseWrapper;
        }


        public IVirusDatabaseIterator GetIterator(ExcellDatabase database)
        {
            return new ExcellDatabaseIterator(database, _genomeDatabaseWrapper);
        }

        public IVirusDatabaseIterator GetIterator(SimpleDatabase database)
        {
            return new SimpleDatabaseIterator(database, _genomeDatabaseWrapper);
        }

        public IVirusDatabaseIterator GetIterator(OvercomplicatedDatabase database)
        {
            return new OvercomplicatedDatabaseIterator(database, _genomeDatabaseWrapper);
        }
    }
}
