
using Task3.Data;
using Task3.Iterators;

namespace Task3.IteratorDecorators
{
    public class IteratorDecorator : IDatabaseIterator
    {
        private readonly IDatabaseIterator _inner;

        public IteratorDecorator(IDatabaseIterator inner)
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