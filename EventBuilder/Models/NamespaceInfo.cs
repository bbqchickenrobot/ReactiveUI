using System.Collections.Generic;

namespace EventBuilder.Models
{
    public class NamespaceInfo
    {
        public string Name { get; set; }
        public IEnumerable<PublicTypeInfo> Types { get; set; }
    }
}