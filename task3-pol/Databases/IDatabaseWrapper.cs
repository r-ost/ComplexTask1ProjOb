using Task3.Iterators;

namespace Task3.Databases
{
    public interface IGenomeDatabaseWrapper
    {
        IGenomeDatabaseIterator GetDatabaseIterator();
    }
}