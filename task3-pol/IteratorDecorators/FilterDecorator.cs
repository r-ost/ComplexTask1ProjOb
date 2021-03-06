using Task3.IteratorDecorators.Comparison;
using Task3.Iterators;

namespace Task3.IteratorDecorators
{
    public class FilterDecorator : IteratorDecorator
    {
        private readonly IVirusDataComparison _comparer;

        public FilterDecorator(IVirusDatabaseIterator inner, IVirusDataComparison comparer) : base(inner)
        {
            _comparer = comparer;
        }


        public override bool Next()
        {
            if (base.Next() == false)
                return false;

            while (_comparer.Compare(Current) == false)
            {
                if (base.Next() == false)
                    return false;
            }

            return true;
        }
    }
}
