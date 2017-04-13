using System;
using System.Collections.Generic;

namespace Passanger.Core.Domain
{
    public class ActiveRoute
    {
        public Guid Id { get; protected set; }
        public Route Route { get; protected set; }
        public IEnumerable<PassangerNode> PassangerNodes { get; protected set; }
    }
}
