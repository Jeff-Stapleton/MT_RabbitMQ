using System;

namespace Contracts
{
    public interface Operation
    {
        string What { get; }
        DateTime When { get; }
    }
}
