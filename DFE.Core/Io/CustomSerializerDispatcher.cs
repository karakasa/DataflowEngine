using System;
using System.Collections.Generic;
using System.Text;

namespace DFE.Core.Io
{
    public static class CustomSerializerDispatcher
    {
        private static Dictionary<Type, ITypeSerializer> _serializers = new();

        public static bool Exists(Type type)
            => _serializers.ContainsKey(type);
    }
}
