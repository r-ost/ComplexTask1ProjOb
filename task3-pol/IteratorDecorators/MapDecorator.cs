using Task3.Iterators;
using Task3.Mapping;

namespace Task3.IteratorDecorators
{
    public class MapDecorator : IteratorDecorator
    {
        private readonly IVirusDataMap _mapper;
        public MapDecorator(IDatabaseIterator inner, IVirusDataMap mappper) : base(inner)
        {
            _mapper = mappper;
        }

        public override VirusData Current => _mapper.Map(base.Current);
    }
}