using System.Collections.Generic;
using Task3.Data;

namespace Task3.Databases
{
    public class SimpleGenomeDatabase
    {
        public List<GenomeData> genomeDatas { get; }

        public SimpleGenomeDatabase(List<GenomeData> genomeDatas)
        {
            this.genomeDatas = genomeDatas;
        }
    }
}
