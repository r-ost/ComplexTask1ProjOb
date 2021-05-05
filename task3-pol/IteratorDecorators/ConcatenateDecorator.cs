using Task3.Data;
using Task3.Iterators;

namespace Task3.IteratorDecorators
{
    public class ConcatenateDecorator : IteratorDecorator
    {
        private readonly IVirusDatabaseIterator _concatenated;
        private bool _nextDatabase;

        public ConcatenateDecorator(IVirusDatabaseIterator inner, IVirusDatabaseIterator concatenated) : base(inner)
        {
            _concatenated = concatenated;
            _nextDatabase = false;
        }


        public override bool Next()
        {
            if (_nextDatabase)
            {
                return _concatenated.Next();
            }
            else
            {
                if (base.Next() == false)
                {
                    _nextDatabase = true;
                    _concatenated.Next();
                }

                return true;
            }
        }

        public override VirusData Current 
        {
            get
            {
                if (_nextDatabase == false)
                    return base.Current;
                else
                    return _concatenated.Current;
            }
        }
    }
}