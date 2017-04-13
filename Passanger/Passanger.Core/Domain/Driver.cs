using System;
using System.Collections.Generic;
using System.Text;

namespace Passanger.Core.Domain
{
    public class Driver
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public Vehicle Vehicle { get; protected set; }
        public IEnumerable<Route> Routes { get; protected set; }
        public IEnumerable<ActiveRoute> ActiveRoutes { get; protected set; }
    }
}
