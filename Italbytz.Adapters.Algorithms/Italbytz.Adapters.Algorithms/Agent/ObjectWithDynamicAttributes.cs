using System;
using System.Collections.Generic;
using System.Text;

namespace Italbytz.Adapters.Algorithms.Agent
{
    public abstract class ObjectWithDynamicAttributes
    {
        public Dictionary<Object, Object> Attributes { get; set; } = new Dictionary<Object, Object>();

        public ObjectWithDynamicAttributes()
        {
        }

        public override string ToString() => DescribeType() + DescribeAttributes();

        private string DescribeAttributes()
        {
            var sb = new StringBuilder();
            sb.Append("[");
            var first = true;
            foreach (var attribute in Attributes)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.Append(", ");
                }

                sb.Append($"{attribute.Key}={attribute.Value}");
            }
            sb.Append("]");
            return sb.ToString();
        }

        public string DescribeType()
        {
            return GetType().Name;
        }
    }
}

