using Mono.Cecil;
using System.Collections.Generic;

namespace EventBuilder.Models
{
    public class PublicTypeInfo
    {
        public string Name { get; set; }
        public string Abstract { get; set; }
        public TypeDefinition Type { get; set; }
        public ParentInfo Parent { get; set; }
        public IEnumerable<PublicEventInfo> Events { get; set; }
        public IEnumerable<ParentInfo> ZeroParameterMethods { get; set; }
        public IEnumerable<SingleParameterMethod> SingleParameterMethods { get; set; }
        public IEnumerable<MultiParameterMethod> MultiParameterMethods { get; set; }
    }
}