using Task3.Iterators;

namespace Task3.IteratorDecorators
{
    public class ConcatenateDecorator : IteratorDecorator
    {
        private readonly IDatabaseIterator _concatenated;
        private bool _nextDatabase = false;

        public ConcatenateDecorator(IDatabaseIterator inner, IDatabaseIterator concatenated) : base(inner)
        {
            _concatenated = concatenated;
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