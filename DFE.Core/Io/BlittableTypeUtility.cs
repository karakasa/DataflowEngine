using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace DFE.Core.Io
{
    internal static class BlittableTypeUtility
    {
        private static Dictionary<Type, bool> _resultCache = new();
        private class IsBlittableGenericTypeNameCache<T>
        {
            public static readonly bool Blittable = IsBlittable(typeof(T));
        }
        public static bool IsBlittable<T>()
            => IsBlittableGenericTypeNameCache<T>.Blittable;
        private static bool IsBlittableNoCache(Type type)
        {
            try
            {
                object instance = FormatterServices.GetUninitializedObject(type);
                GCHandle.Alloc(instance, GCHandleType.Pinned).Free();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsBlittable(Type type)
        {
            if (_resultCache.TryGetValue(type, out var result))
                return result;

            return _resultCache[type] = IsBlittableNoCache(type);
        }
    }
}
