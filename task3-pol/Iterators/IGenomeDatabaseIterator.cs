using Task3.Data;

namespace Task3.Iterators
{
    public interface IGenomeDatabaseIterator
    {
        bool Next();
        GenomeData Current { get; }
    }
}