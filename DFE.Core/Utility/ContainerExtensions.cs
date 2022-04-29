using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DFE.Core.Utility
{
    internal static class ContainerExtensions
    {
        public static void EnsureCapacity<T>(this List<T> list, int capacity)
        {
            if (list.Capacity < capacity) 
                list.Capacity = capacity;
        }
        public static void CloneTo<T>(this List<T> source, List<T> target)
            where T : ICloneable
        {
            target.EnsureCapacity(source.Count);
            target.Clear();
            target.AddRange(source.Select(static val => (T)val.Clone()));
        }
        public static void CloneToValueType<T>(this List<T> source, List<T> target)
            where T : struct
        {
            target.EnsureCapacity(source.Count);
            target.Clear();
            target.AddRange(source);
        }
        public static void Dispose<T>(this List<T> source)
            where T : IDisposable
        {
            foreach (var value in source)
                value.Dispose();
        }
    }
}
