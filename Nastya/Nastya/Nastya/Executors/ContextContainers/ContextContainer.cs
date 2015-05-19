using System;
using System.Xml.Serialization;
using Nastya.Nastya.Executors.ContextContainers.Context;

namespace Nastya.Nastya.Executors.ContextContainers
{
    [XmlInclude(typeof(CommonContextContainer<>))]
    [XmlInclude(typeof(UserContextsContainer<>))]
    public class ContextContainer
    {

        public String ContextId { get; set; }
    }
}
