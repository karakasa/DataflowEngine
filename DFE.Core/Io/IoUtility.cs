using System;
using System.Runtime.CompilerServices;

namespace DFE.Core.Io
{
    public static class IoUtility
    {
        public static bool IsSerializable<T>(T value)
            => IsSerializableType(typeof(T));
        public static bool IsSerializable(object value)
            => (value is null) ? true : IsSerializableType(value.GetType());
        public static bool IsSerializableType<T>()
            => IsSerializableType(typeof(T));
        public static bool IsSerializableType(Type type)
        {
            if (
                type == typeof(int) ||
                type == typeof(double) ||
                type == typeof(string) ||
                type == typeof(bool) ||
                type == typeof(byte)
                )
            {
                return true;
            }

            if (type.IsArray)
            {
                if (type.GetArrayRank() != 1) return false;
                return IsSerializableType(type.GetElementType());
            }

            if (typeof(IDfeSerializable).IsAssignableFrom(type))
                return true;

            if (CustomSerializerDispatcher.Exists(type))
                return true;

            if (BlittableTypeSerializer.EnableUnknownTypeSerialization &&
                BlittableTypeUtility.IsBlittable(type))
                return true;

            return false;
        }
        public static T Clone<T>(this T source)
            where T : IDfeSerializable
        {
            if (source is IDfeClonable clonable)
                return (T)clonable.Clone();

            return default;
        }
    }
}
