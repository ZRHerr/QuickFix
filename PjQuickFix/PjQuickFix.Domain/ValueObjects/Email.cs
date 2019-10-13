using DotNetCore.Objects;
using System.Collections.Generic;

namespace PjQuickFix.Domain
{
    public sealed class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;
        }

        public string Address { get; }

        protected override IEnumerable<object> GetEquals()
        {
            yield return Address;
        }
    }
}
