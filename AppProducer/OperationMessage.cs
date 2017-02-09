using Contracts;
using System;

namespace AppProducer
{
  class OperationMessage : Operation
  {
    public string What { get; set; }
    public DateTime When { get; set; }
  }
}
