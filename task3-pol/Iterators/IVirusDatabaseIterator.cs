using Task3.Data;

namespace Task3.Iterators
{
    public interface IVirusDatabaseIterator
    {
        bool Next();
        VirusData Current { get;}
    }
}
