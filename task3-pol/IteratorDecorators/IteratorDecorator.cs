
using Task3.Data;
using Task3.Iterators;

namespace Task3.IteratorDecorators
{
    public class IteratorDecorator : IVirusDatabaseIterator
    {
        private readonly IVirusDatabaseIterator _inner;

        public IteratorDecorator(IVirusDatabaseIterator inner)
        {
            _inner = inner;
        }

        public virtual bool Next() => _inner.Next();

        public virtual VirusData Current 
        { 
            get => _inner.Current;
        }
    }
}