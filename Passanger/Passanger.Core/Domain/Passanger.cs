using System;

namespace Passanger.Core.Domain
{
    public class Passanger
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public Node Adress { get; protected set; }
    }
}
