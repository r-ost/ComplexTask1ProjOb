#nullable enable
using System;
using System.Collections.Generic;
using System.Text;
using Task3.Data;

namespace Task3.Iterators
{
    public interface IDatabaseIterator
    {
        bool Next();
        VirusData Current { get;}
    }
}
