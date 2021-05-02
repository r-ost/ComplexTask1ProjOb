using Task3.Data;
using Task3.IteratorDecorators.Mapping;
using Task3.Iterators;

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